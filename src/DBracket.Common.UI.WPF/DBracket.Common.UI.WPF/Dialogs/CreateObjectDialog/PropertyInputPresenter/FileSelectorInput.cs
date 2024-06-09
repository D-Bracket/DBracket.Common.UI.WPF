using DBracket.Common.UI.WPF.Commands;
using Microsoft.Win32;
using System.Windows.Input;

namespace DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter
{
    public class FileSelectorInput : PropertyInputPresenterBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private string _fileStartPath = string.Empty;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public FileSelectorInput(string propertyName, string header, int maxInputLength, string startPath)
        {
            PropertyName = propertyName;
            Header = header;
            MaxInputLength = maxInputLength;
            _fileStartPath = startPath;
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

        #region "----------------------------- Command Handling ----------------------------"
        private void ExecuteCommand(string? command)
        {
            switch (command)
            {
                case "SearchFileLocation":
                    var openFileDialog = new OpenFileDialog
                    {
                        InitialDirectory = $@"{_fileStartPath}"
                    };

                    if (openFileDialog.ShowDialog() == true)
                    {
                        Input = openFileDialog.FileName;
                    }
                    break;
            }
        }
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

        #region "-------------------------------- Commands ---------------------------------"
        public ICommand Commands => new StringCommand(ExecuteCommand);
        #endregion
        #endregion
    }
}