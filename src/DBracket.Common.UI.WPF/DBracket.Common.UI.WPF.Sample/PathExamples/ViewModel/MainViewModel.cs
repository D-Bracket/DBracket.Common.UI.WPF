using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Themes;
using System.Windows;

namespace DBracket.Common.UI.WPF.Sample.PathExamples.ViewModel
{
    internal sealed class MainViewModel : ViewModelBase
    {

        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public MainViewModel()
        {
            var t = new ThemeController();
            Task.Run(() =>
            {
                Test();
            });
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void Test()
        {
            var rnd = new Random();
            Task.Delay(1000).Wait();
            while (true)
            {
                if (Application.Current is null)
                    break;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var newValue = rnd.NextDouble() * 300;
                    Value = newValue;
                });

                //for (int i = 0; i < Columns.Count; i++)
                //{

                //}
                Task.Delay(1000).Wait();
            }
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(object? command)
        {
            switch (command)
            {
                case "OpenFlyout":
                    IsFlyoutOpened = true;
                    break;

                case "CloseFlyout":
                    IsFlyoutOpened = false;
                    break;
            }
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public double Value { get => _value; set { _value = value; OnMySelfChanged(); } }
        private double _value;

        public bool IsFlyoutOpened { get => _isFlyoutOpened; set { _isFlyoutOpened = value; OnMySelfChanged(); } }
        private bool _isFlyoutOpened;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}