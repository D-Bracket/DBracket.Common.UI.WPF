using System.Collections.ObjectModel;

namespace DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter
{
    public class ComboBoxInput : PropertyInputPresenterBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ComboBoxInput(string propertyName, string header, IEnumerable<object> listOfOptions, string displayMemberPath, bool isEditable)
        {
            PropertyName = propertyName;
            Header = header;
            DisplayMemberPath = displayMemberPath;

            if (listOfOptions is not null)
                ListOfOptions = [.. listOfOptions];

            IsEditable = isEditable;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        internal override object? GetInput()
        {
            return SelectedInput;
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<object>? ListOfOptions { get => _listOfOptions; set { _listOfOptions = value; OnMySelfChanged(); } }
        private ObservableCollection<object>? _listOfOptions;

        public string DisplayMemberPath { get => _displayMemberPath; set { _displayMemberPath = value; OnMySelfChanged(); } }
        private string _displayMemberPath;

        public object SelectedInput
        {
            get => _selectedInput;
            set
            {
                _selectedInput = value;

                // Reset previous error
                ResetErrors(nameof(SelectedInput));

                List<string> errors = new();
                if (!string.IsNullOrEmpty(DisplayMemberPath))
                {
                    if (value is not null)
                    {
                        var property = value.GetType().GetProperty(DisplayMemberPath);
                        if (property is not null)
                        {
                            var propValue = property?.GetValue(value);
                            var propStringValue = propValue?.ToString();
                            errors = OnValidateInput(propStringValue);
                        }
                    }
                    else
                    {
                        errors = OnValidateInput(null);
                    }
                }
                else
                {
                    var newValue = value is null ? string.Empty : value.ToString();
                    errors = OnValidateInput(newValue);
                }

                if (errors.Count > 0)
                {
                    foreach (var error in errors)
                    {
                        // Show errors
                        AddError(nameof(SelectedInput), error);
                    }
                }

                OnMySelfChanged();
            }
        }
        private object _selectedInput;

        public bool IsEditable { get => _isEditable; set { _isEditable = value; OnMySelfChanged(); } }
        private bool _isEditable;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}