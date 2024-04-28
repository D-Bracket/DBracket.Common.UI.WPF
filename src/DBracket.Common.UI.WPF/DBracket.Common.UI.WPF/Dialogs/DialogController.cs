using DBracket.Common.UI.WPF.Bases;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Dialogs
{
    /// <summary>Controller to display dialogs (is bound to a specific host)</summary>
    public class DialogController : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        /// <summary>Controller to display dialogs (is bound to a specific host)</summary>
        public DialogController()
        {
                
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public bool OpenDialog(UserControl view, DialogViewModelBase viewModel, DialogSettings settings)
        {
            if (IsOpened)
            {
                return false;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                IsOpened = true;
                OpenDialogRequest?.Invoke(view, viewModel, settings);
            });
            return true;

        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        /// <summary>True, when a dialog is displayed</summary>
        public bool IsOpened { get => _isOpened; set { _isOpened = value; OnMySelfChanged(); } }
        private bool _isOpened;
        #endregion

        #region "--------------------------------- Events ----------------------------------"
        /// <summary>Thrown, when a dialog should be opened</summary>
        internal event OpenDialogHandler? OpenDialogRequest;
        internal delegate void OpenDialogHandler(UserControl dialogView, DialogViewModelBase viewModel, DialogSettings settings);

        internal event CloseDialogHandler? CloseDialogRequest;
        internal delegate void CloseDialogHandler(object? dialogResult);


        #endregion
        #endregion
    }
}