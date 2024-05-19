using System.Windows.Media;
using System.Windows;

namespace DBracket.Common.UI.WPF.Controls.Settings
{
    public static class ButtonSettings
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
        #region IsMouseOver
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty MouseOverBrushProperty =
            DependencyProperty.RegisterAttached(
          "MouseOverBrush",
          typeof(Brush),
          typeof(ButtonSettings),
          new FrameworkPropertyMetadata(defaultValue: new SolidColorBrush(Colors.LightGray))
        );

        // Declare a get accessor method.
        public static Brush GetMouseOverBrush(UIElement target) =>
            (Brush)target.GetValue(MouseOverBrushProperty);

        // Declare a set accessor method.
        public static void SetMouseOverBrush(UIElement target, Brush value) =>
            target.SetValue(MouseOverBrushProperty, value);
        #endregion

        #region IsPressed

        #endregion
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}