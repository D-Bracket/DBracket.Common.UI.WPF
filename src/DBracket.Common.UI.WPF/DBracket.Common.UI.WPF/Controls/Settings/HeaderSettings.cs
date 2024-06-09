using System.Windows.Media;
using System.Windows;

namespace DBracket.Common.UI.WPF.Controls.Settings
{
    public static class HeaderSettings
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
        private static void HandleHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (string.IsNullOrEmpty(e.NewValue.ToString()))
            //{
            //    SetHeaderVisibility(d, Visibility.Collapsed);
            //}
            //else
            //{
            //    SetHeaderVisibility(d, Visibility.Visible);
            //}
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        #region Header
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached(
          "Header",
          typeof(string),
          typeof(HeaderSettings),
          new FrameworkPropertyMetadata(string.Empty, HandleHeaderChanged));

        // Declare a get accessor method.
        public static string GetHeader(DependencyObject target) =>
            (string)target.GetValue(HeaderProperty);

        // Declare a set accessor method.
        public static void SetHeader(DependencyObject target, string value) =>
            target.SetValue(HeaderProperty, value);
        #endregion

        #region HeaderForeground
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.RegisterAttached(
          "HeaderForeground",
          typeof(Brush),
          typeof(HeaderSettings),
          new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.Inherits));

        // Declare a get accessor method.
        public static Brush GetHeaderForeground(DependencyObject target) =>
            (Brush)target.GetValue(HeaderForegroundProperty);

        // Declare a set accessor method.
        public static void SetHeaderForeground(DependencyObject target, Brush value) =>
            target.SetValue(HeaderForegroundProperty, value);
        #endregion

        #region HeaderVisibility
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty HeaderVisibilityProperty =
            DependencyProperty.RegisterAttached(
          "HeaderVisibility",
          typeof(Visibility),
          typeof(HeaderSettings),
          new FrameworkPropertyMetadata(Visibility.Collapsed, FrameworkPropertyMetadataOptions.Inherits));

        // Declare a get accessor method.
        public static Visibility GetHeaderVisibility(DependencyObject target) =>
            (Visibility)target.GetValue(HeaderVisibilityProperty);

        // Declare a set accessor method.
        public static void SetHeaderVisibility(DependencyObject target, Visibility value) =>
            target.SetValue(HeaderVisibilityProperty, value);
        #endregion
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}