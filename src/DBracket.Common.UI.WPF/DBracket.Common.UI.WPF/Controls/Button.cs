using DBracket.Common.UI.WPF.Controls.States;
using System.Windows;

namespace DBracket.Common.UI.WPF.Controls
{
    public class Button : System.Windows.Controls.Button
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Button()
        {
            
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        /// <summary></summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void HandleStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Button button)
                throw new ArgumentNullException();

            var state = "Default";
            if (string.IsNullOrEmpty(e.NewValue.ToString()) == false) 
                state = e.NewValue.ToString();

            var stateSettings = button.States.FirstOrDefault(x => x.Name == state);
            if (stateSettings is null)
                throw new Exception($"State {state} not registrated");

            button.ActiveStateSettings = stateSettings.ControlStateSettings;
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            "CornerRadius", typeof(CornerRadius), typeof(Button), new FrameworkPropertyMetadata(null));

        public string ActiveState
        {
            get => (string)GetValue(ActiveStateProperty);
            set => SetValue(ActiveStateProperty, value);
        }
        public static readonly DependencyProperty ActiveStateProperty = DependencyProperty.Register(
            "ActiveState", typeof(string), typeof(Button), new FrameworkPropertyMetadata("Default", HandleStateChanged));

        public ControlStateSettings ActiveStateSettings
        {
            get => (ControlStateSettings)GetValue(ActiveStateSettingsProperty);
            private set => SetValue(ActiveStateSettingsProperty, value);
        }
        public static readonly DependencyProperty ActiveStateSettingsProperty = DependencyProperty.Register(
            "ActiveStateSettings", typeof(ControlStateSettings), typeof(Button), new FrameworkPropertyMetadata(null));

        public ControlStateCollection States
        {
            get => (ControlStateCollection)GetValue(StatesProperty);
            set => SetValue(StatesProperty, value);
        }
        public static readonly DependencyProperty StatesProperty = DependencyProperty.Register(
            "States", typeof(ControlStateCollection), typeof(Button), new FrameworkPropertyMetadata(new ControlStateCollection()));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}