using DBracket.Common.UI.WPF.Bases;
using System.Windows;

namespace DBracket.Common.UI.WPF.Dialogs.YesNoDialog
{
    public class YesNoDialogViewModel : DialogViewModelBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public YesNoDialogViewModel(string header, string message, YesNoDialogOptions options, bool showCommentBox, int maxCommentLength = 250)
        {
            Header = header;
            Message = message;
            MaxCommentLength = maxCommentLength;

            CancelButtonVisibility = options == YesNoDialogOptions.YesNoCancel ? Visibility.Visible : Visibility.Hidden;
            CommentVisibility = showCommentBox ? Visibility.Visible : Visibility.Collapsed;

            switch (options)
            {
                case YesNoDialogOptions.YesNo:
                    NavigationButtons.Add(new Control.DialogNavigationButton()
                    {
                        Content = "Yes",
                        CommandParameter = "Yes",
                        SpaceToLeft = 0
                    });
                    NavigationButtons.Add(new Control.DialogNavigationButton()
                    {
                        Content = "No",
                        CommandParameter = "No",
                        SpaceToLeft = 40
                    });
                    break;

                case YesNoDialogOptions.YesNoCancel:
                    NavigationButtons.Add(new Control.DialogNavigationButton()
                    {
                        Content = "Cancel",
                        CommandParameter = "Cancel",
                        SpaceToLeft = 0
                    });
                    NavigationButtons.Add(new Control.DialogNavigationButton()
                    {
                        Content = "Yes",
                        CommandParameter = "Yes",
                        SpaceToLeft = 40
                    });
                    NavigationButtons.Add(new Control.DialogNavigationButton()
                    {
                        Content = "No",
                        CommandParameter = "No",
                        SpaceToLeft = 40
                    });
                    break;
            }
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(string? command)
        {
            switch (command)
            {
                case "Yes":
                    OptionChosen?.Invoke(YesNoDialogResults.Yes, Comment);
                    break;

                case "No":
                    OptionChosen?.Invoke(YesNoDialogResults.No, Comment);
                    break;

                case "Cancel":
                    OptionChosen?.Invoke(YesNoDialogResults.Cancel, Comment);
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

        public string Comment { get => _comment; set { _comment = value; OnMySelfChanged(); } }
        private string _comment;

        public int MaxCommentLength { get; }

        public Visibility CancelButtonVisibility { get => _cancelButtonVisibility; set { _cancelButtonVisibility = value; OnMySelfChanged(); } }
        private Visibility _cancelButtonVisibility = Visibility.Collapsed;

        public Visibility CommentVisibility { get => _commentVisibility; set { _commentVisibility = value; OnMySelfChanged(); } }
        private Visibility _commentVisibility = Visibility.Collapsed;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        public event DialogResultHandler? OptionChosen;
        public delegate void DialogResultHandler(YesNoDialogResults result, string comment);
        #endregion

        #region "-------------------------------- Commands ---------------------------------"

        #endregion
        #endregion
    }
    public enum YesNoDialogOptions
    {
        YesNo = 1,
        YesNoCancel = 2
    }

    public enum YesNoDialogResults
    {
        Yes = 1,
        No = 2,
        Cancel = 3
    }
}