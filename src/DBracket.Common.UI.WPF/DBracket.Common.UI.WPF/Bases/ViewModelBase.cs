using DBracket.Common.UI.WPF.Commands;
using System.Windows.Input;

namespace DBracket.Common.UI.WPF.Bases
{
    /// <summary>Baseclass for ViewModels</summary>
    public abstract class ViewModelBase : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        /// <summary>Executes the commands from the UI</summary>
        /// <param name="command">Command that has to be executed</param>
        public abstract void ExecuteCommands(object? command);
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"
        /// <summary>Commands from the UI</summary>
        public ICommand Commands => new RelayCommand(ExecuteCommands);
        #endregion
        #endregion
    }
}