using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Dialogs.Control;

namespace DBracket.Common.UI.WPF.Dialogs.InputDialog
{
    public class InputDialogViewModel : DialogViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private Func<string, List<string>>? _listValidationFunction;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public InputDialogViewModel(string header, string message, int maxLength, bool IsCancelButtonVisible = true)
        {
            Header = header;
            Message = message;
            MaxLength = maxLength;

            CreateNavigationButtons(IsCancelButtonVisible);
        }

        public InputDialogViewModel(string header, string message, int maxLength, Func<string, List<string>> listValidationFunction, bool IsCancelButtonVisible = true)
        {
            Header = header;
            Message = message;
            MaxLength = maxLength;
            _listValidationFunction = listValidationFunction;

            CreateNavigationButtons(IsCancelButtonVisible);

            if (_listValidationFunction is not null)
                NavigationButtons[0].IsEnabled = false;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void CreateNavigationButtons(bool IsCancelButtonVisible)
        {
            NavigationButtons.Add(new DialogNavigationButton() { Content = "Ok", CommandParameter = "Ok", SpaceToLeft = 40 });
            if (IsCancelButtonVisible)
                NavigationButtons.Add(new DialogNavigationButton() { Content = "Cancel", CommandParameter = "CloseDialog", SpaceToLeft = 40 });
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "Okay":
                    InputsReceived?.Invoke(false, Input);
                    break;

                case "Cancel":
                    InputsReceived?.Invoke(true, string.Empty);
                    break;

                default:
                    break;
            }
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Header { get => _header; set { _header = value; OnMySelfChanged(); } }
        private string _header;

        public string Message { get => _message; set { _message = value; OnMySelfChanged(); } }
        private string _message;

        public string Input
        {
            get => _input;
            set
            {
                _input = value;

                // Reset previos errors
                ResetErrors(nameof(Input));

                if (_listValidationFunction is not null)
                {
                    var errors = _listValidationFunction(Input);
                    if (errors.Count() != 0)
                    {
                        NavigationButtons[0].IsEnabled = false;
                        foreach (var error in errors)
                        {
                            AddError(Input, error);
                        }
                    }
                    else
                    {
                        NavigationButtons[0].IsEnabled = true;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Input) == false)
                        NavigationButtons[0].IsEnabled = true;
                }

                OnMySelfChanged();
            }
        }
        private string _input;

        public int MaxLength { get; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"
        public event InputReceivedHandler? InputsReceived;
        public delegate void InputReceivedHandler(bool wasCanceled, string input);
        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}