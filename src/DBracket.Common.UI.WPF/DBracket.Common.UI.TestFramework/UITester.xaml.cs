using DBracket.Common.UI.TestFramework.Protocol;
using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    /// <summary>Controller to record and execute intigration tests for WPF applications</summary>
    public partial class UITester : Window
    {
        #region "----------------------------- Private Fields ------------------------------"
        private ObservableCollection<Window> _windowsToTest;
        private UITesterViewModel _viewModel;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UITester(ObservableCollection<Window> windowsToTest)
        {
            _windowsToTest = windowsToTest;

            InitializeComponent();

            _viewModel = new UITesterViewModel(DialogHost.DialogController, windowsToTest);
            DataContext = _viewModel;
            windowsToTest.First().Show();

            TestTree.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>((object sender, RoutedPropertyChangedEventArgs<object> args) =>
            {
                if (args.NewValue is TestSequence testSequence)
                {
                    _viewModel.SelectedTestSequence = testSequence;
                    _viewModel.SelectedTest = null;
                }
                else if (args.NewValue is Test test)
                {
                    _viewModel.SelectedTestSequence = test.TestSequence;
                    _viewModel.SelectedTest = test;
                }
            });
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