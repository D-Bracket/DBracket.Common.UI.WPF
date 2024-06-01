using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    /// <summary>Controller to record and execute intigration tests for WPF applications</summary>
    public partial class UITester : Window
    {
        #region "----------------------------- Private Fields ------------------------------"
        private ObservableCollection<WindowContainer> _windowsToTest;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UITester(ObservableCollection<WindowContainer> windowsToTest)
        {
            _windowsToTest = windowsToTest;

            InitializeComponent();

            DataContext = new UITesterViewModel(windowsToTest);
            windowsToTest.First()._window.Show();
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static void Initialize()
        {
            UIReportCenter.Initialize();
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}