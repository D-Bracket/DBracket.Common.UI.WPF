using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Controls.Settings
{
    public static class ScrollViewerSettings
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private static ScrollBar GetScrollBar(DependencyObject d, Orientation orientation)
        {
            if (d is not ScrollViewer scrollViewer)
                return null;

            // Ensure the template is applied
            scrollViewer.ApplyTemplate();

            // Find the vertical scrollbar within the template
            if (orientation == Orientation.Horizontal)
            {
                return (ScrollBar)scrollViewer.Template.FindName("PART_HorizontalScrollBar", scrollViewer);
            }
            else
            {
                return (ScrollBar)scrollViewer.Template.FindName("PART_VerticalScrollBar", scrollViewer);
            }
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private static void HandleVerticalScrollBarScrollPageButtonBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not Brush newBrush)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollPageButtonBackground = newBrush;
        }

        private static void HandleVerticalScrollBarScrollPageButtonBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not Brush newBrush)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollPageButtonBorderBrush = newBrush;
        }

        private static void HandleVerticalScrollBarScrollPageButtonCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not CornerRadius cornerRadius)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollPageButtonCornerRadius = cornerRadius;
        }





        private static void HandleVerticalScrollBarScrollButtonBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not Brush newBrush)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollButtonBackground = newBrush;
        }

        private static void HandleVerticalScrollBarScrollButtonBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not Brush newBrush)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollButtonBorderBrush = newBrush;
        }

        private static void HandleVerticalScrollBarScrollButtonCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not CornerRadius cornerRadius)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollButtonCornerRadius = cornerRadius;
        }

        private static void HandleVerticalScrollBarScrollButtonMouseOverBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not Brush newBrush)
                throw new Exception("Value is not of Type Brush");

            var verticalScrollBar = GetScrollBar(d, Orientation.Vertical);
            verticalScrollBar.ScrollButtonMouseOverBackground = newBrush;
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        #region VerticalScrollBar
        #region ScrollPageButton
        #region VerticalScrollBarScrollPageButtonBackground
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty VerticalScrollBarScrollPageButtonBackgroundProperty =
            DependencyProperty.RegisterAttached(
          "VerticalScrollBarScrollPageButtonBackground",
          typeof(Brush),
          typeof(ScrollViewerSettings),
          new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), HandleVerticalScrollBarScrollPageButtonBackgroundChanged)
        );

        // Declare a get accessor method.
        public static Brush GetVerticalScrollBarScrollPageButtonBackground(UIElement target) =>
            (Brush)target.GetValue(VerticalScrollBarScrollPageButtonBackgroundProperty);

        // Declare a set accessor method.
        public static void SetVerticalScrollBarScrollPageButtonBackground(UIElement target, Brush value) =>
            target.SetValue(VerticalScrollBarScrollPageButtonBackgroundProperty, value);
        #endregion

        #region VerticalScrollBarScrollPageButtonBorderBrush
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty VerticalScrollBarScrollPageButtonBorderBrushProperty =
            DependencyProperty.RegisterAttached(
          "VerticalScrollBarScrollPageButtonBorderBrush",
          typeof(Brush),
          typeof(ScrollViewerSettings),
          new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), HandleVerticalScrollBarScrollPageButtonBorderBrushChanged)
        );

        // Declare a get accessor method.
        public static Brush GetVerticalScrollBarScrollPageButtonBorderBrush(UIElement target) =>
            (Brush)target.GetValue(VerticalScrollBarScrollPageButtonBorderBrushProperty);

        // Declare a set accessor method.
        public static void SetVerticalScrollBarScrollPageButtonBorderBrush(UIElement target, Brush value) =>
            target.SetValue(VerticalScrollBarScrollPageButtonBorderBrushProperty, value);
        #endregion

        #region VerticalScrollBarScrollPageButtonCornerRadius
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty VerticalScrollBarScrollPageButtonCornerRadiusProperty =
            DependencyProperty.RegisterAttached(
          "VerticalScrollBarScrollPageButtonCornerRadius",
          typeof(CornerRadius),
          typeof(ScrollViewerSettings),
          new FrameworkPropertyMetadata(new CornerRadius(2), HandleVerticalScrollBarScrollPageButtonCornerRadiusChanged)
        );

        // Declare a get accessor method.
        public static CornerRadius GetVerticalScrollBarScrollPageButtonCornerRadius(UIElement target) =>
            (CornerRadius)target.GetValue(VerticalScrollBarScrollPageButtonCornerRadiusProperty);

        // Declare a set accessor method.
        public static void SetVerticalScrollBarScrollPageButtonCornerRadius(UIElement target, CornerRadius value) =>
            target.SetValue(VerticalScrollBarScrollPageButtonCornerRadiusProperty, value);
        #endregion
        #endregion

        #region ScrollButton
        #region VerticalScrollBarScrollButtonColorDefault
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty VerticalScrollBarScrollButtonColorDefaultProperty =
            DependencyProperty.RegisterAttached(
          "VerticalScrollBarScrollButtonColorDefault",
          typeof(Color),
          typeof(ScrollViewerSettings),
          new FrameworkPropertyMetadata(Colors.Transparent)
        );

        // Declare a get accessor method.
        public static Color GetVerticalScrollBarScrollButtonColorDefault(UIElement target) =>
            (Color)target.GetValue(VerticalScrollBarScrollButtonColorDefaultProperty);

        // Declare a set accessor method.
        public static void SetVerticalScrollBarScrollButtonColorDefault(UIElement target, Color value) =>
            target.SetValue(VerticalScrollBarScrollButtonColorDefaultProperty, value);
        #endregion

        #region VerticalScrollBarScrollButtonColorMouseOver
        // Register an attached dependency property with the specified
        // property name, property type, owner type, and property metadata.
        public static readonly DependencyProperty VerticalScrollBarScrollButtonColorMouseOverProperty =
            DependencyProperty.RegisterAttached(
          "VerticalScrollBarScrollButtonColorMouseOver",
          typeof(Color),
          typeof(ScrollViewerSettings),
          new FrameworkPropertyMetadata(Colors.Transparent)
        );

        // Declare a get accessor method.
        public static Color GetVerticalScrollBarScrollButtonColorMouseOver(UIElement target) =>
            (Color)target.GetValue(VerticalScrollBarScrollButtonColorMouseOverProperty);

        // Declare a set accessor method.
        public static void SetVerticalScrollBarScrollButtonColorMouseOver(UIElement target, Color value) =>
            target.SetValue(VerticalScrollBarScrollButtonColorMouseOverProperty, value);
        #endregion

        //#region VerticalScrollBarScrollButtonBackground
        //// Register an attached dependency property with the specified
        //// property name, property type, owner type, and property metadata.
        //public static readonly DependencyProperty VerticalScrollBarScrollButtonBackgroundProperty =
        //    DependencyProperty.RegisterAttached(
        //  "VerticalScrollBarScrollButtonBackground",
        //  typeof(Brush),
        //  typeof(ScrollViewerSettings),
        //  new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), HandleVerticalScrollBarScrollButtonBackgroundChanged)
        //);

        //// Declare a get accessor method.
        //public static Brush GetVerticalScrollBarScrollButtonBackground(UIElement target) =>
        //    (Brush)target.GetValue(VerticalScrollBarScrollButtonBackgroundProperty);

        //// Declare a set accessor method.
        //public static void SetVerticalScrollBarScrollButtonBackground(UIElement target, Brush value) =>
        //    target.SetValue(VerticalScrollBarScrollButtonBackgroundProperty, value);
        //#endregion

        //#region VerticalScrollBarScrollButtonMouseOverBackground
        //// Register an attached dependency property with the specified
        //// property name, property type, owner type, and property metadata.
        //public static readonly DependencyProperty VerticalScrollBarScrollButtonMouseOverBackgroundProperty =
        //    DependencyProperty.RegisterAttached(
        //  "VerticalScrollBarScrollButtonMouseOverBackground",
        //  typeof(Brush),
        //  typeof(ScrollViewerSettings),
        //  new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), HandleVerticalScrollBarScrollButtonMouseOverBackgroundChanged)
        //);

        //// Declare a get accessor method.
        //public static Brush GetVerticalScrollBarScrollButtonMouseOverBackground(UIElement target) =>
        //    (Brush)target.GetValue(VerticalScrollBarScrollButtonMouseOverBackgroundProperty);

        //// Declare a set accessor method.
        //public static void SetVerticalScrollBarScrollButtonMouseOverBackground(UIElement target, Brush value) =>
        //    target.SetValue(VerticalScrollBarScrollButtonMouseOverBackgroundProperty, value);
        //#endregion
        #endregion
        #endregion
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}