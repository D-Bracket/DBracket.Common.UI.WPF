using DBracket.Common.UI.WPF.Bases;
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

        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public double Value { get => _value; set { _value = value; OnMySelfChanged(); } }
        private double _value;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}