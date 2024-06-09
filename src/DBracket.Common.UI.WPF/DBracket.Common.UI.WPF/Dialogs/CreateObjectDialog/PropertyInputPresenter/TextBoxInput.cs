namespace DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter
{
    public class TextBoxInput : PropertyInputPresenterBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TextBoxInput(string propertyName, string header, int maxInputLength)
        {
            PropertyName = propertyName;
            Header = header;
            MaxInputLength = maxInputLength;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        internal override object? GetInput()
        {
            return Input;
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Input
        {
            get => _input;
            set
            {
                _input = value;

                // Reset previos errors
                ResetErrors(nameof(Input));
                var errors = OnValidateInput(value);
                foreach (var error in errors)
                {
                    AddError(Input, error);
                }

                OnMySelfChanged();
            }
        }
        private string _input = string.Empty;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}