using DBracket.Common.TestFramework;
using DBracket.Common.UI.TestFramework.Events.Types;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework.Behaviors
{
    public static class RegisterControl
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
        private static void HandleIsTestControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not Control control)
                return;

            UIReportCenter.RegisterControl(control);

            //if (d is Button button)
            //{
            //    button.Click += (s, e) => 
            //    {
            //        UIReportCenter.ReportEvent(button.Name, "button_Clicked", EventTypes.EVENT_CLICK, button);
            //    };
            //}
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty IsTestControlProperty =
            DependencyProperty.RegisterAttached(
          "IsTestControl",
          typeof(bool),
          typeof(RegisterControl),
          new FrameworkPropertyMetadata(false, HandleIsTestControlChanged)
        );

        // Declare a get accessor method.
        public static bool GetIsTestControl(UIElement target) =>
            (bool)target.GetValue(IsTestControlProperty);

        // Declare a set accessor method.
        public static void SetIsTestControl(UIElement target, bool value) =>
            target.SetValue(IsTestControlProperty, value);
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}