using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Dialogs.Control
{

    public partial class DialogContainer : UserControl
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public DialogContainer(UserControl dialogContent, DialogSettings settings)
        {
            InitializeComponent();
            dialogContent.Content = dialogContent;
            DataContext = dialogContent.DataContext;

            if (settings.NavigationButtons.Count == 0)
            {
                NavigationGrid.Visibility = System.Windows.Visibility.Visible;
                return;
            }

            var isFirst = true;
            foreach (var button in settings.NavigationButtons)
            {
                if (isFirst)
                {
                    isFirst = false;
                    button.Margin = new System.Windows.Thickness(0);
                    continue;
                }
                button.Margin = new System.Windows.Thickness(button.SpaceToLeft, 0, 0, 0);
            }
            NavigationButtons.ItemsSource = settings.NavigationButtons;
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

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}