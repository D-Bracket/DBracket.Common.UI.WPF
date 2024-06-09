using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Dialogs.Control;
using DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog
{
    public class CreateObjectDialogViewModel : DialogViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private Func<string, long, string, List<string>>? _listValidationFunction;

        private object _objectToCreate;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public CreateObjectDialogViewModel(object objectToCreate, string header, ObservableCollection<PropertyInputPresenterBase> listOfParameters, bool IsCancelButtonVisible = true)
        {
            _objectToCreate = objectToCreate;
            Header = header;
            ListOfParameters = listOfParameters;

            foreach (var parameter in listOfParameters)
            {
                parameter.ValidateInputRequest += HandlePropertyInputReceived;
            }

            CreateNavigationButtons(IsCancelButtonVisible);
            NavigationButtons[0].IsEnabled = false;
        }

        public CreateObjectDialogViewModel(object objectToCreate, string header, ObservableCollection<PropertyInputPresenterBase> listOfParameters, Func<string, long, string, List<string>> listValidationFunction, bool IsCancelButtonVisible = true)
        {
            _objectToCreate = objectToCreate;
            Header = header;
            ListOfParameters = listOfParameters;

            foreach (var parameter in listOfParameters)
            {
                parameter.ValidateInputRequest += HandlePropertyInputReceived;
            }

            CreateNavigationButtons(IsCancelButtonVisible);

            _listValidationFunction = listValidationFunction;
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
            NavigationButtons.Add(new DialogNavigationButton() { Content = "Add", CommandParameter = "Add", SpaceToLeft = 0 });
            if (IsCancelButtonVisible)
                NavigationButtons.Add(new DialogNavigationButton() { Content = "Cancel", CommandParameter = "CloseDialog", SpaceToLeft = 40 });
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private List<string> HandlePropertyInputReceived(string propertyName, object? input)
        {
            var inp = string.Empty;
            if (input is string strInput)
                inp = strInput;

            if (_listValidationFunction is not null)
            {
                var errors = _listValidationFunction(propertyName, 0, inp);

                if (errors.Count() != 0)
                {
                    NavigationButtons[0].IsEnabled = false;
                    return errors;
                }
            }

            var isAddingEnabled = CheckIfAllInputsReceived();
            NavigationButtons[0].IsEnabled = isAddingEnabled;
            return new List<string>();
        }

        private bool CheckIfAllInputsReceived()
        {
            foreach (var parameter in ListOfParameters)
            {
                var input = parameter.GetInput();
                if (parameter.HasErrors)
                    return false;

                if (input is null)
                    return false;

                if (input is not string stringInput)
                    continue;

                if (string.IsNullOrEmpty(stringInput))
                    return false;
            }
            return true;
        }
        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "Add":
                    var objectType = _objectToCreate.GetType();
                    foreach (var property in ListOfParameters)
                    {
                        var propertyToSet = objectType.GetProperty(property.PropertyName);
                        if (propertyToSet is null)
                            throw new Exception("Property not found");

                        var propertyType = propertyToSet.PropertyType;
                        var propertyValue = propertyToSet.GetValue(_objectToCreate);
                        var input = property.GetInput();

                        if (propertyValue is Enum)
                        {
                            string valueString = string.Empty;
                            if (input is not null && input.ToString() is not null)
                            {
                                var tmp = input.ToString();
                                if (tmp is not null)
                                    valueString = tmp;
                            }
                            propertyToSet.SetValue(_objectToCreate, Enum.Parse(propertyType, valueString));
                        }
                        else
                        {
                            propertyToSet.SetValue(_objectToCreate, Convert.ChangeType(input, propertyType));
                        }
                    }

                    InputsReceivedReport?.Invoke(false, _objectToCreate);
                    break;

                case "CloseDialog":
                    InputsReceivedReport?.Invoke(true, null);
                    break;
            }
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Header { get => _header; set { _header = value; OnMySelfChanged(); } }
        private string _header;

        public ObservableCollection<PropertyInputPresenterBase> ListOfParameters { get => _listOfParameters; set { _listOfParameters = value; OnMySelfChanged(); } }
        private ObservableCollection<PropertyInputPresenterBase> _listOfParameters = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"
        public event DialogResultHandler? InputsReceivedReport;
        public delegate void DialogResultHandler(bool wasCanceled, object? objectData);
        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
}