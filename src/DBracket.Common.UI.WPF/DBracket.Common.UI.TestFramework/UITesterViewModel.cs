using DBracket.Common.UI.TestFramework.Protocol;
using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Dialogs.Control;
using DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter;
using DBracket.Common.UI.WPF.Dialogs.YesNoDialog;
using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    /// <summary>ViewModel for controller to record and execute intigration tests for WPF applications</summary>
    internal class UITesterViewModel : ViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private ObservableCollection<Window> _windowsToTest;
        private DialogController _dialogController;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UITesterViewModel(DialogController dialogController, ObservableCollection<Window> windowsToTest)
        {
            _dialogController = dialogController;
            _windowsToTest = windowsToTest;
            if (ConfigurationFilePath is not null)
            {
                try
                {
                    TestConfigurations = WindowContainer.LoadConfiguration(ConfigurationFilePath);
                }
                catch (Exception ex)
                {
                    TestConfigurations = new ObservableCollection<WindowContainer>();
                }
                // TODO: Check if UITester knows window type, to execute tests
            }


            UIReportCenter.EventReceived += HandleEventReceived;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void LoadTestConfiguration(WindowContainer? windowContainer)
        {
            windowContainer.LoadTestConfiguration(ConfigurationFilePath);
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private void HandleEventReceived(UIEvent uiEvent)
        {
            EventLog.Insert(0, uiEvent);
        }

        private bool HandleAddTestConfigurationRequest(YesNoDialogResults result, string comment)
        {
            return true;
        }
        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "AddTestSequence":
                    SelectedWindowToTest.TestSequences.Add(new TestSequence() { Name = "New_TestSequence" });
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
                    if (SelectedEvent is not null)
                        SelectedEvent.ReExecute();
                    break;

                case "AddTestConfiguration":
                    var tmp = new ObservableCollection<string>()
                    {
                        "Test1",
                        "Test2",
                        "Test3",
                        "Test4",
                    };

                    _dialogController.ShowCreateObjectDialog(
                        new WindowContainer(new Window()),
                        "Test",
                        new ObservableCollection<PropertyInputPresenterBase>()
                        {
                            new TextBoxInput(nameof(WindowContainer.Name), "Name", 50),
                            new ComboBoxInput(nameof(WindowContainer.Name), "Name", tmp, "", false),
                        },
                        HandleTest);
                    break;
            }
        }

        private bool HandleTest(bool wasCanceled, object? createdObject)
        {
            return true;
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<WindowContainer> TestConfigurations { get => _testConfigurations; set { _testConfigurations = value; OnMySelfChanged(); } }
        private ObservableCollection<WindowContainer> _testConfigurations;

        public WindowContainer? SelectedWindowToTest { get => _selectedWindowToTest; set { _selectedWindowToTest = value; LoadTestConfiguration(value); OnMySelfChanged(); } }
        private WindowContainer? _selectedWindowToTest;

        public TestSequence? SelectedTestSequence { get => _selectedTestSequence; set { _selectedTestSequence = value; OnMySelfChanged(); } }
        private TestSequence? _selectedTestSequence;

        //public bool IsTestSequenceSelected { get => _isTestSequenceSelected; set { _isTestSequenceSelected = value; OnMySelfChanged(); } }
        //private bool _isTestSequenceSelected;

        public Test? SelectedTest { get => _selectedTest; set { _selectedTest = value; OnMySelfChanged(); } }
        private Test? _selectedTest;

        public UIEvent SelectedEvent { get => _selectedEvent; set { _selectedEvent = value; OnMySelfChanged(); } }
        private UIEvent _selectedEvent;

        public string ConfigurationFilePath { get => _configurationFilePath; set { _configurationFilePath = value; OnMySelfChanged(); } }
        private string _configurationFilePath = @"C:\Temp\MainWindow.json";

        public ObservableCollection<UIEvent> EventLog { get => _eventLog; set { _eventLog = value; OnMySelfChanged(); } }
        private ObservableCollection<UIEvent> _eventLog = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}