using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Charts.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            Columns.Add(new ChartDataPoint(0));
            this.PropertyChanged += HandleTest;
            Task.Run(() =>
            {
                Test();
            });
        }

        private void HandleTest(object? sender, PropertyChangedEventArgs e)
        {

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
                for (int i = 0; i < Columns.Count; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var newValue = rnd.NextDouble() * 300;
                        Columns[i] = new Charts.Data.ChartDataPoint(newValue);
                        Value = newValue;
                    });
                }
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
        public ObservableCollection<ChartDataPoint> Columns { get => _columns; set { _columns = value; OnMySelfChanged(); } }
        private ObservableCollection<ChartDataPoint> _columns = new();

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