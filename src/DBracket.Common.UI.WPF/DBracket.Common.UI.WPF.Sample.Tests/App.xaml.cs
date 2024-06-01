using DBracket.Common.UI.TestFramework;
using DBracket.Common.UI.WPF.Sample.Views;
using System.Windows;

namespace DBracket.Common.UI.WPF.Sample.Tests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            UITester.Initialize();
            var windowsToTest = new System.Collections.ObjectModel.ObservableCollection<WindowContainer>
            {
                new WindowContainer(new MainWindow())
            };

            var tester = new UITester(windowsToTest);
            tester.Show();
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