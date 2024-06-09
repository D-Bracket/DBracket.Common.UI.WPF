using DBracket.Common.UI.WPF.Bases;

namespace DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter
{
    public abstract class PropertyInputPresenterBase : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        internal List<string> OnValidateInput(string? value)
        {
            return ValidateInputRequest?.Invoke(_propertyName, value);
        }

        internal abstract object? GetInput();
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string PropertyName { get => _propertyName; set { _propertyName = value; OnMySelfChanged(); } }
        private string _propertyName;

        public string Header { get => _header; set { _header = value; OnMySelfChanged(); } }
        private string _header;

        public int MaxInputLength { get => _maxInputLength; set { _maxInputLength = value; OnMySelfChanged(); } }
        private int _maxInputLength;

        //public ObservableCollection<object>? ListOfOptions { get => _listOfOptions; set { _listOfOptions = value; OnMySelfChanged(); } }
        //private ObservableCollection<object>? _listOfOptions;

        //public object SelectedInput
        //{
        //    get => _selectedInput;
        //    set
        //    {
        //        _selectedInput = value;

        //        // Reset previous error
        //        ResetErrors(nameof(SelectedInput));

        //        string? error = string.Empty;
        //        if (!string.IsNullOrEmpty(DisplayMemberPath))
        //        {
        //            if (value is not null)
        //            {
        //                var property = value.GetType().GetProperty(DisplayMemberPath);
        //                if (property is not null)
        //                {
        //                    var propValue = property?.GetValue(value);
        //                    var propStringValue = propValue?.ToString();
        //                    error = PropertyInputReceived?.Invoke(_propertyName, propStringValue);
        //                }
        //            }
        //            else
        //            {
        //                error = PropertyInputReceived?.Invoke(_propertyName, null);
        //            }
        //        }
        //        else
        //        {
        //            var newValue = value is null ? string.Empty : value.ToString();
        //            error = PropertyInputReceived?.Invoke(_propertyName, newValue);
        //        }

        //        if (string.IsNullOrEmpty(error) == false)
        //        {
        //            // Show errors
        //            AddError(nameof(Input), error);
        //        }

        //        OnMySelfChanged();
        //    }
        //}
        //private object _selectedInput;

        //public string DisplayMemberPath { get => _displayMemberPath; set { _displayMemberPath = value; OnMySelfChanged(); } }
        //private string _displayMemberPath;

        //public bool IsEditable { get => _isEditable; set { _isEditable = value; OnMySelfChanged(); } }
        //private bool _isEditable;

        //public DataTemplate? ItemTemplate { get => _itemTemplate; set { _itemTemplate = value; OnMySelfChanged(); } }
        //private DataTemplate? _itemTemplate;

        //public ParameterInputTypes InputType { get => _inputType; set { _inputType = value; OnMySelfChanged(); } }
        //private ParameterInputTypes _inputType;
        #endregion

        #region "--------------------------------- Events ----------------------------------"
        public event InputValidationHandler? ValidateInputRequest;
        public delegate List<string> InputValidationHandler(string propertyName, string? input);
        #endregion
        #endregion
    }
}