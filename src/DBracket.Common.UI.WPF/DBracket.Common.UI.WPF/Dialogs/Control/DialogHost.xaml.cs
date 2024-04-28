using DBracket.Common.UI.WPF.Bases;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DBracket.Common.UI.WPF.Dialogs.Control
{
    /// <summary>
    /// Interaktionslogik für DialogHost.xaml
    /// </summary>
    public partial class DialogHost : UserControl, INotifyPropertyChanged
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public DialogHost()
        {
            InitializeComponent();
            Visibility = System.Windows.Visibility.Collapsed;

            Grid.SetRowSpan(this, 5);

            _dialogController = new DialogController();
            _dialogController.OpenDialogRequest += HandleOpenDialogRequest;
            _dialogController.CloseDialogRequest += HandleCloseDialogRequest;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private void HandleOpenDialogRequest(UserControl dialogView, DialogViewModelBase viewModel, DialogSettings settings)
        {
            if (settings.StrechHorizontally)
            {
                PART_HorizontalLine_Left.Background = new SolidColorBrush(Colors.White);
                PART_HorizontalLine_Left.Opacity = 1;
                PART_HorizontalLine_Right.Background = new SolidColorBrush(Colors.White);
                PART_HorizontalLine_Right.Opacity = 1;
                DialogPresenter.SetValue(Grid.ColumnProperty, 0);
                DialogPresenter.SetValue(Grid.ColumnSpanProperty, 10);
            }
            else
            {
                PART_HorizontalLine_Left.Background = new SolidColorBrush(Colors.Black);
                PART_HorizontalLine_Left.Opacity = 0.4;
                PART_HorizontalLine_Right.Background = new SolidColorBrush(Colors.Black);
                PART_HorizontalLine_Right.Opacity = 0.4;
                DialogPresenter.SetValue(Grid.ColumnProperty, 1);
                DialogPresenter.SetValue(Grid.ColumnSpanProperty, 1);
            }

            dialogView.DataContext = viewModel;
            ViewModel = viewModel;
            var container = new DialogContainer(dialogView, settings);
            DialogPresenter.Content = container;
            Visibility = System.Windows.Visibility.Visible;
        }

        private void HandleCloseDialogRequest(object? dialogResult)
        {
            Visibility = System.Windows.Visibility.Collapsed;
            DialogPresenter.Content = null;
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public DialogController DialogController => _dialogController;
        private DialogController _dialogController;

        public DialogViewModelBase? ViewModel { get => _viewModel; set { _viewModel = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewModel))); } }
        private DialogViewModelBase? _viewModel;
        #endregion

        #region "--------------------------------- Events ----------------------------------"
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion
        #endregion
    }
}