using System.Windows.Input;

namespace DBracket.Common.UI.WPF.Commands
{
    /// <summary>Relaycommand to execute Actions</summary>
    public class RelayCommand : ICommand
    {
        #region "----------------------------- Private Fields ------------------------------"
        private readonly Action<object?> _execute;

        private readonly Predicate<object?>? _predicate;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        /// <summary>Relaycommand to execute Actions</summary>
        /// <param name="execute">Action to execute, when the command is called</param>
        public RelayCommand(Action<object?> execute)
            : this(execute, null)
        {

        }

        /// <summary>Relaycommand to execute Actions</summary>
        /// <param name="execute">Action to execute, when the command is called</param>
        /// <param name="canExecute">Determines wheter the command can be executed or not</param>
        /// <exception cref="ArgumentNullException">Thrown, when the execute action is null</exception>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _predicate = canExecute;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        /// <summary>Returns wheter the command can be executed or not</summary>
        /// <param name="parameter">Commandparameter</param>
        /// <returns>True - If the command can be executed</returns>
        public bool CanExecute(object? parameter)
        {
            return _predicate == null || _predicate(parameter);
        }

        /// <summary>Executes the Command</summary>
        /// <param name="parameter">Commandparameter</param>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"
        /// <summary>Eventhandler, for when the Condtions to execute the Command changed</summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }
        #endregion
        #endregion
    }
}