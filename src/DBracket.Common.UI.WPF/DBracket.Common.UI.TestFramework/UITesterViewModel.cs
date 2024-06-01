using DBracket.Common.UI.TestFramework.Protocol;
using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.TestFramework
{
    /// <summary>ViewModel for controller to record and execute intigration tests for WPF applications</summary>
    internal class UITesterViewModel : ViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UITesterViewModel(ObservableCollection<WindowContainer> windowsToTest)
        {
            WindowsToTest = windowsToTest;

            UIReportCenter.EventReceived += HandleEventReceived;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private void HandleEventReceived(UIEvent uiEvent)
        {
            EventLog.Insert(0, uiEvent);
        }
        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "AddTestSequence":
                    SelectedWindowToTest.TestSequences.Add(new TestSequence() { Name = "New_TestSequence"});
                    break;               
                
                case "AddTest":
                    SelectedTestSequence.Tests.Add(new Test() { Name = "New_Test"});
                    break;

                case "ExecuteEvent":
                    if (SelectedEvent is not null)
                        SelectedEvent.ReExecute();
                    break;
            }
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<WindowContainer> WindowsToTest { get => _windowsToTest; set { _windowsToTest = value; OnMySelfChanged(); } }
        private ObservableCollection<WindowContainer> _windowsToTest;

        public WindowContainer SelectedWindowToTest { get => _selectedWindowToTest; set { _selectedWindowToTest = value; OnMySelfChanged(); } }
        private WindowContainer _selectedWindowToTest;

        public TestSequence SelectedTestSequence { get => _selectedTestSequence; set { _selectedTestSequence = value; OnMySelfChanged(); } }
        private TestSequence _selectedTestSequence;

        public Test SelectedTest { get => _selectedTest; set { _selectedTest = value; OnMySelfChanged(); } }
        private Test _selectedTest;

        public UIEvent SelectedEvent { get => _selectedEvent; set { _selectedEvent = value; OnMySelfChanged(); } }
        private UIEvent _selectedEvent;

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