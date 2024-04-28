using DBracket.Common.UI.WPF.Dialogs.Control;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.WPF.Dialogs
{
    /// <summary>Settings, to customize how a dialog should be displayed</summary>
    public class DialogSettings
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        /// <summary>Settings, to customize how a dialog should be displayed</summary>
        public DialogSettings()
        {
            
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        /// <summary>When set, the dialog is stretched, horizontally accross the screen</summary>
        public bool StrechHorizontally { get; set; }

        /// <summary>Buttons to navigate the dialog</summary>
        public ObservableCollection<DialogNavigationButton> NavigationButtons { get; set; } = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}