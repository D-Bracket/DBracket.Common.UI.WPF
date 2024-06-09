using DBracket.Common.UI.WPF.Dialogs.Control;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.WPF.Bases
{
    /// <summary>Baseclass for Dialog ViewModels</summary>
    public abstract class DialogViewModelBase : ViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        /// <summary>Triggeres the event, that the dialog input is done and that the dialog should be closed</summary>
        /// <param name="createdObject">Optional object, that was created in the dialog</param>
        protected void RaiseDialogSuccessEvent(object? createdObject = null)
        {
            DialogSuccessReport?.Invoke(createdObject);
        }

        /// <summary>Shows an error under the dialog</summary>
        /// <param name="title">Title of the error</param>
        /// <param name="description">Description of the error</param>
        protected void ShowError(string title, string description)
        {
            ErrorTitle = title;
            ErrorText = description;
            ShowErrorMessage = true;
        }

        /// <summary>Resets the displayed error</summary>
        protected void ResetError()
        {
            ErrorTitle = string.Empty;
            ErrorText = string.Empty;
            ShowErrorMessage = false;
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        /// <summary>Current error title</summary>
        public string ErrorTitle {  get => _errorTitle; set { _errorTitle = value; OnMySelfChanged(); } }
        private string _errorTitle = string.Empty;

        /// <summary>Current error description</summary>
        public string ErrorText { get => _errorText; set { _errorText = value; OnMySelfChanged(); } }
        private string _errorText = string.Empty;

        /// <summary>Determines, wheter the error popup is shown</summary>
        public bool ShowErrorMessage { get => _showErrorMessage; set { _showErrorMessage = value; OnMySelfChanged(); } }
        private bool _showErrorMessage;

        /// <summary>Buttons to navigate the dialog</summary>
        public ObservableCollection<DialogNavigationButton> NavigationButtons { get => _navigationButtons; set { _navigationButtons = value; OnMySelfChanged(); } }
        private ObservableCollection<DialogNavigationButton> _navigationButtons = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"
        /// <summary>Is triggered, when a user input has been received and the dialog needs to be closed</summary>
        public event DialogSuccessReportHandler? DialogSuccessReport;
        /// <summary>Handles the dialog input and closes the dialog</summary>
        /// <param name="createdObject">Optional object, that was created in the dialog</param>
        public delegate void DialogSuccessReportHandler(object? createdObject);
        #endregion
        #endregion
    }
}