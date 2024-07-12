using DBracket.Common.TestFramework;
using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Commands;
using DBracket.Common.UI.WPF.Sample.PathExamples.ViewModel;
using DBracket.Common.UI.WPF.Sample.Views.Base;
using DBracket.Common.UI.WPF.Themes;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace DBracket.Common.UI.WPF.Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region "----------------------------- Private Fields ------------------------------"
        private ControlPresenterView _presenterView = new();
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

        private void NavigateBase(string path)
        {
            if (path.StartsWith("Controls"))
            {
                path = path.Replace("Controls_", "");
                switch(path) 
                {
                    case "Buttons":
                        PresenterContent = _presenterView;
                        break;

                    default:
                        // Open Controls Page
                        break;
                }
            }
            else
            {
                // Navigate Base Page
            }
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "Test1":
                    var newEvent = new Event(new Guid("e9b33e01-53cc-4b1f-b098-419cdf017329"))
                    {
                        Name = "Logic",
                        Description = "Logic did something",
                        EventType= "Logic"
                    };
                    ReportCenter.ReportEvent(newEvent);

                    break;

                //case "OpenFlyout":
                //    IsFlyoutOpened = true;
                //    break;

                //case "CloseFlyout":
                //    IsFlyoutOpened = false;
                //    break;

                //case "Test":
                //    LoadImages();
                //    break;
            }
        }



        private void ExecuteMenuCommand(string? command)
        {
            if (command.StartsWith("DBracket.Common.UI.WPF"))
            {
                NavigateBase(command.Replace("DBracket.Common.UI.WPF_", ""));
            }
            else if (command == "Prototypes")
            {

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
        
        public object PresenterContent { get => _presenterContent; set { _presenterContent = value; OnMySelfChanged(); } }
        private object _presenterContent;

        public ObservableCollection<ImageContainer> Items { get => _items; set { _items = value; OnMySelfChanged(); } }
        private ObservableCollection<ImageContainer> _items = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"
        /// <summary>Commands from the UI</summary>
        public ICommand MenuCommand => new StringCommand(ExecuteMenuCommand);
        #endregion
        #endregion
    }
}