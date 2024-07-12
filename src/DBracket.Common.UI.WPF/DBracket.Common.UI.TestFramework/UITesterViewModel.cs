using DBracket.Common.TestFramework;
using DBracket.Common.UI.TestFramework.Protocol;
using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Dialogs.Control;
using DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter;
using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    /// <summary>ViewModel for controller to record and execute intigration tests for WPF applications</summary>
    internal class UITesterViewModel : ViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private ObservableCollection<Type> _windowTypesToTest;
        private DialogController _dialogController;
        private AppSettings _appSettings;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UITesterViewModel(DialogController dialogController, ObservableCollection<Type> windowTypesToTest)
        {
            _dialogController = dialogController;
            _windowTypesToTest = windowTypesToTest;

            _appSettings = new AppSettings();

            try
            {
                TestConfigurations = TestConfiguration.LoadConfigurations(_appSettings.ConfigurationPath);
            }
            catch (Exception ex)
            {
                TestConfigurations = new ObservableCollection<TestConfiguration>();
            }
            // TODO: Check if UITester knows window type, to execute tests


            ReportCenter.EventReported += HandleEventReceived;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        //private void LoadTestConfiguration(WindowContainer? windowContainer)
        //{
        //    windowContainer.LoadTestConfiguration(ConfigurationFilePath);
        //}
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private void HandleEventReceived(IEvent @event)
        {
            EventLog.Insert(0, @event);
        }

        private void HandleTestEventReceived(IEvent @event)
        {
            if (SelectedTest is null)
                return;

            SelectedTest.Events.Add(new EventToTest(@event));
        }

        private bool HandleCreateConfiguration(bool wasCanceled, object? createdObject)
        {
            if (wasCanceled == false)
            {
                var configuration = createdObject as TestConfiguration;
                var windowType = configuration.WindowType;
                configuration._window = Activator.CreateInstance(windowType) as Window;
                var filePath = $"{_appSettings.ConfigurationPath}{configuration.Name}.json";
                TestConfiguration.CreateConfigurationFile(filePath, configuration);
                TestConfigurations.Add(configuration);
            }

            return true;
        }

        private Window CreateWindowByType(Type windowType)
        {
            return Activator.CreateInstance(windowType) as Window;
        }
        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "SaveConfiguration":
                    SelectedConfiguration.SaveConfiguration(SelectedConfiguration);
                    break;

                case "AddTestSequence":
                    SelectedConfiguration.TestSequences.Add(new TestSequence() { Name = "New_TestSequence" });
                    break;

                case "AddTest":
                    var newTest = new Test()
                    {
                        Name = "New_Test",
                        TestSequence = SelectedTestSequence
                    };
                    SelectedTestSequence.Tests.Add(newTest);
                    break;

                case "ExecuteEvent":
                    ExecuteTest();
                    break;

                case "AddTestConfiguration":
                    _dialogController.ShowCreateObjectDialog(
                        new TestConfiguration(),
                        "Test",
                        new ObservableCollection<PropertyInputPresenterBase>()
                        {
                            new TextBoxInput(nameof(TestConfiguration.Name), "Name", 50),
                            new ComboBoxInput(nameof(TestConfiguration.WindowType), "Type", _windowTypesToTest, "FullName", false),
                        },
                        HandleCreateConfiguration);
                    break;

                case "OpenWindowToTest":
                    if (SelectedConfiguration is not null)
                    {
                        SelectedConfiguration._window = Activator.CreateInstance(SelectedConfiguration.WindowType) as Window;
                        SelectedConfiguration._window.Show();
                    }
                    break;

                case "RecordEvents":
                    if (IsRecording)
                    {
                        IsRecording = false;
                        ReportCenter.EventReported -= HandleTestEventReceived;
                    }
                    else
                    {
                        IsRecording = true;
                        ReportCenter.EventReported += HandleTestEventReceived;
                    }
                    break;

                case "AddAssertion":
                    if (SelectedEvent is null)
                        return;

                    SelectedEvent.Assertions.Add(new EventAssertion(SelectedEvent.Event));
                    break;

                case "ExpandAll":
                    foreach (var result in Results)
                    {
                        result.IsExpanded = true;
                        foreach (var testSequence in result.TestSequences)
                        {
                            testSequence.IsExpanded = true;
                            foreach (var test in testSequence.Tests)
                            {
                                test.IsExpanded = true;
                            }
                        }
                    }
                    break;

                case "CollapseAll":
                    foreach (var result in Results)
                    {
                        result.IsExpanded = false;
                        foreach (var testSequence in result.TestSequences)
                        {
                            testSequence.IsExpanded = false;
                            foreach (var test in testSequence.Tests)
                            {
                                test.IsExpanded = false;
                            }
                        }
                    }
                    break;
            }
        }

        private void ExecuteTest()
        {
            if (SelectedConfiguration is null)
                return;

            if (SelectedConfiguration._window is not null)
                SelectedConfiguration._window.Close();
            SelectedConfiguration._window = CreateWindowByType(SelectedConfiguration.WindowType);
            SelectedConfiguration._window.Show();
            ObservableCollection<IEvent> eventLog = new();
            ReportCenter.EventReported += HandleExecuteTestEventReceived;

            var testConfigurationResult = new TestConfigurationResult(SelectedConfiguration);
            Results.Add(testConfigurationResult);

            foreach (var testSequence in SelectedConfiguration.TestSequences)
            {
                var testSequenceResult = new TestSequenceResult(testSequence);
                testConfigurationResult.TestSequences.Add(testSequenceResult);

                foreach (var test in testSequence.Tests)
                {
                    eventLog.Clear();
                    var testResult = new TestResult(test);
                    testSequenceResult.Tests.Add(testResult);

                    if (test.Events is null || test.Events.Count == 0)
                        continue;

                    foreach (var @event in test.Events)
                    {
                        if (@event.Event is not UIEvent uiEvent)
                            continue;

                        uiEvent.ReExecute();
                    }


                    // Save Results
                    var index = 0;
                    for (int i = 0; i < test.Events.Count; i++)
                    {
                        // Get index of the event from the result log
                        if (test.Events[i].Event is UIEvent uiEvent)
                        {
                            index = GetUIEventIndex(eventLog, uiEvent.Name);
                        }
                        else if (test.Events[i].Event is Event @event)
                        {
                            index = GetEventIndex(eventLog, @event.Id);
                        }



                        if (index == -1)
                        {
                            // Event not in results
                            // Add empty event to results
                            testResult.Events.Add(new EventResult(test.Events[i], null));
                        }
                        else if (index != i)
                        {
                            // Event is on new position
                            if (i > index)
                            {
                                // Event came before the reference event -> events have been deleted
                                // Add xxx
                            }
                            else
                            {
                                // Event came after the reference event -> new events have been added
                                // Add xxx
                            }
                        }
                        else
                        {
                            // The event is on the expected position
                            testResult.Events.Add(new EventResult(test.Events[i], eventLog[i]));
                        }
                    }
                }
            }
            SelectedConfiguration._window.Close();




            // Check Assertions
            foreach (var @event in eventLog)
            {

            }



            //if (SelectedEvent is not null)
            //    SelectedEvent.ReExecute();
            //break;

            void HandleExecuteTestEventReceived(IEvent reportedEvent)
            {
                eventLog.Add(reportedEvent);
            }

            bool CheckAssertions(EventToTest assertionEvent, IEvent @event)
            {
                foreach (var assertion in assertionEvent.Assertions)
                {
                    var detail = @event.Details.FirstOrDefault(x => x.Name == assertion.EventDetail.Name);
                    if (detail is null)
                        throw new Exception();

                    var parameter = detail.Parameters.FirstOrDefault(x => x.Name == assertion.Parameter.Name);
                    if (parameter is null)
                        throw new Exception();

                    var isDouble = double.TryParse(parameter.Value, out var doubleValue);
                    if (isDouble)
                    {
                        var result = doubleValue <= assertion.UpperLimit && doubleValue >= assertion.LowerLimit;
                        if (result == false)
                            return false;
                    }
                }

                return true;
            }


            int GetEventIndex(IList<IEvent> events, Guid id)
            {
                foreach (var recordedEvent in events)
                {
                    if (recordedEvent is Event @event)
                    {
                        if (@event.Id == id)
                            return events.IndexOf(recordedEvent);
                    }
                }
                return -1;
            }


            int GetUIEventIndex(IList<IEvent> events, string name)
            {
                foreach (var recordedEvent in events)
                {
                    if (recordedEvent is UIEvent uiEvent)
                    {
                        if (uiEvent.Name == name)
                            return events.IndexOf(recordedEvent);
                    }
                }
                return -1;
            }
        }



        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<TestConfiguration> TestConfigurations { get => _testConfigurations; set { _testConfigurations = value; OnMySelfChanged(); } }
        private ObservableCollection<TestConfiguration> _testConfigurations;

        public TestConfiguration? SelectedConfiguration { get => _selectedConfiguration; set { _selectedConfiguration = value; OnMySelfChanged(); } }
        private TestConfiguration? _selectedConfiguration;

        public TestSequence? SelectedTestSequence { get => _selectedTestSequence; set { _selectedTestSequence = value; OnMySelfChanged(); } }
        private TestSequence? _selectedTestSequence;

        //public bool IsTestSequenceSelected { get => _isTestSequenceSelected; set { _isTestSequenceSelected = value; OnMySelfChanged(); } }
        //private bool _isTestSequenceSelected;

        public Test? SelectedTest { get => _selectedTest; set { _selectedTest = value; OnMySelfChanged(); } }
        private Test? _selectedTest;

        public EventToTest SelectedEvent { get => _selectedEvent; set { _selectedEvent = value; OnMySelfChanged(); } }
        private EventToTest _selectedEvent;

        public EventDetail SelectedEventDetail { get => _selectedEventDetail; set { _selectedEventDetail = value; OnMySelfChanged(); } }
        private EventDetail _selectedEventDetail;

        public ObservableCollection<IEvent> EventLog { get => _eventLog; set { _eventLog = value; OnMySelfChanged(); } }
        private ObservableCollection<IEvent> _eventLog = new();

        public bool IsRecording { get => _isRecording; set { _isRecording = value; OnMySelfChanged(); } }
        private bool _isRecording;




        public ObservableCollection<TestConfigurationResult> Results { get => _results; set { _results = value; OnMySelfChanged(); } }
        private ObservableCollection<TestConfigurationResult> _results = new();

        public TestResult? SelectedTestResult { get => _selectedTestResult; set { _selectedTestResult = value; OnMySelfChanged(); } }
        private TestResult? _selectedTestResult;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}