using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog;
using DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter;
using DBracket.Common.UI.WPF.Dialogs.YesNoDialog;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Dialogs.Control
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

        public bool CloseDialog()
        {
            if (IsOpened)
            {
                IsOpened = false;
                CloseDialogRequest?.Invoke();
                return true;
            }
            return false;
        }

        public void ShowYesNoDialog(string header, string message, YesNoDialogOptions options, bool showCommentBox,
            Func<YesNoDialogResults, string, bool> callBack, int maxLength = 250, bool strechHorizontally = false)
        {
            var settings = new DialogSettings();
            settings.StrechHorizontally = strechHorizontally;

            var view = new YesNoDialogView();
            var viewModel = new YesNoDialogViewModel(header, message, options, showCommentBox, maxLength);
            viewModel.OptionChosen += new YesNoDialogViewModel.DialogResultHandler(delegate (YesNoDialogResults result, string comment)
            {
                CloseDialog();
                callBack(result, comment);
            });

            OpenDialog(view, viewModel, settings);
        }


        public void ShowCreateObjectDialog(
            object objectToCreate,
            string header,
            ObservableCollection<PropertyInputPresenterBase> listOfParameters,
            Func<bool, object?, bool> callBack,
            bool IsCancelButtonVisible = true)
        {
            var settings = new DialogSettings();
            settings.StrechHorizontally = false;

            var view = new CreateObjectDialogView();
            var viewModel = new CreateObjectDialogViewModel(objectToCreate, header, listOfParameters, IsCancelButtonVisible);
            viewModel.InputsReceivedReport += new CreateObjectDialogViewModel.DialogResultHandler(delegate (bool wasCanceled, object? createObject)
            {
                CloseDialog();
                callBack(wasCanceled, createObject);
            });

            OpenDialog(view, viewModel, settings);
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
        internal delegate void CloseDialogHandler();


        #endregion
        #endregion
    }
}