using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Commands;
using DBracket.Common.UI.WPF.Themes;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

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

        private void LoadImages()
        {
            var directory = $@"\\DBracketNAS\Svens Dokumente\Medien\XXX\#Random Images\Neuer Ordner (2)";
            var files = Directory.GetFiles(directory);
            var tmp = new ObservableCollection<ImageContainer>();
            foreach (var file in files)
            {
                tmp.Add(new ImageContainer(file));
            }

            Items = tmp;
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

                case "Test":
                    LoadImages();
                    break;
            }
        }

        private void ExecuteMenuCommand(object? obj)
        {
            var t = obj.ToString();
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public double Value { get => _value; set { _value = value; OnMySelfChanged(); } }
        private double _value;

        public bool IsFlyoutOpened { get => _isFlyoutOpened; set { _isFlyoutOpened = value; OnMySelfChanged(); } }
        private bool _isFlyoutOpened;

        public ObservableCollection<ImageContainer> Items { get => _items; set { _items = value; OnMySelfChanged(); } }
        private ObservableCollection<ImageContainer> _items = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"
        /// <summary>Commands from the UI</summary>
        public ICommand MenuCommand => new RelayCommand(ExecuteMenuCommand);
        #endregion
        #endregion
    }
}