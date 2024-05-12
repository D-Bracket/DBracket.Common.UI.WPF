using System.Windows;

namespace DBracket.Common.UI.WPF.Controls.States
{
    public class ControlState : DependencyObject
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
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(ControlState), new FrameworkPropertyMetadata(string.Empty));

        public ControlStateSettings ControlStateSettings
        {
            get => (ControlStateSettings)GetValue(ControlStateSettingsProperty);
            set => SetValue(ControlStateSettingsProperty, value);
        }
        public static readonly DependencyProperty ControlStateSettingsProperty = DependencyProperty.Register(
            "ControlStateSettings", typeof(ControlStateSettings), typeof(Button), new FrameworkPropertyMetadata(null));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}