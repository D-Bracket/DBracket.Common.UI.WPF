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
            ObservableCollection<IEvent> _eventLog = new();
            ReportCenter.EventReported += HandleExecuteTestEventReceived;

            foreach (var testSequence in SelectedConfiguration.TestSequences)
            {
                foreach (var test in testSequence.Tests)
                {
                    if (test.Events is null || test.Events.Count == 0)
                        continue;

                    var startEvent = test.Events.First().Event as UIEvent;
                    startEvent.ReExecute();
                }
            }
            SelectedConfiguration._window.Close();

            foreach (var @event in _eventLog)
            {

            }

            //if (SelectedEvent is not null)
            //    SelectedEvent.ReExecute();
            //break;

            void HandleExecuteTestEventReceived(IEvent reportedEvent)
            {
                _eventLog.Add(reportedEvent);
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

        public ObservableCollection<IEvent> EventLog { get => _eventLog; set { _eventLog = value; OnMySelfChanged(); } }
        private ObservableCollection<IEvent> _eventLog = new();

        public bool IsRecording { get => _isRecording; set { _isRecording = value; OnMySelfChanged(); } }
        private bool _isRecording;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}