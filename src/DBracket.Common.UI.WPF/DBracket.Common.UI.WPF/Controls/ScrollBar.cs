using System.Windows;
using System.Windows.Media;

namespace DBracket.Common.UI.WPF.Controls
{
    public class ScrollBar : System.Windows.Controls.Primitives.ScrollBar
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ScrollBar()
        {
            
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
        public bool IsScrollViewerMouseOver
        {
            get => (bool)GetValue(IsScrollViewerMouseOverProperty);
            set => SetValue(IsScrollViewerMouseOverProperty, value);
        }
        public static readonly DependencyProperty IsScrollViewerMouseOverProperty = DependencyProperty.Register(
            "IsScrollViewerMouseOver", typeof(bool), typeof(ScrollBar), new FrameworkPropertyMetadata(false));

        #region ScrollPageButton
        public Brush ScrollPageButtonBackground
        {
            get => (Brush)GetValue(ScrollPageButtonBackgroundProperty);
            set => SetValue(ScrollPageButtonBackgroundProperty, value);
        }
        public static readonly DependencyProperty ScrollPageButtonBackgroundProperty = DependencyProperty.Register(
            "ScrollPageButtonBackground", typeof(Brush), typeof(ScrollBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public Brush ScrollPageButtonBorderBrush
        {
            get => (Brush)GetValue(ScrollPageButtonBorderBrushProperty);
            set => SetValue(ScrollPageButtonBorderBrushProperty, value);
        }
        public static readonly DependencyProperty ScrollPageButtonBorderBrushProperty = DependencyProperty.Register(
            "ScrollPageButtonBorderBrush", typeof(Brush), typeof(ScrollBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White)));

        public CornerRadius ScrollPageButtonCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollPageButtonCornerRadiusProperty);
            set => SetValue(ScrollPageButtonCornerRadiusProperty, value);
        }
        public static readonly DependencyProperty ScrollPageButtonCornerRadiusProperty = DependencyProperty.Register(
            "ScrollPageButtonCornerRadius", typeof(CornerRadius), typeof(ScrollBar), new FrameworkPropertyMetadata(new CornerRadius(2)));
        #endregion

        #region ScrollButton
        public Brush ScrollButtonBackground
        {
            get => (Brush)GetValue(ScrollButtonBackgroundProperty);
            set => SetValue(ScrollButtonBackgroundProperty, value);
        }
        public static readonly DependencyProperty ScrollButtonBackgroundProperty = DependencyProperty.Register(
            "ScrollButtonBackground", typeof(Brush), typeof(ScrollBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Yellow)));

        public Brush ScrollButtonMouseOverBackground
        {
            get => (Brush)GetValue(ScrollButtonMouseOverBackgroundProperty);
            set => SetValue(ScrollButtonMouseOverBackgroundProperty, value);
        }
        public static readonly DependencyProperty ScrollButtonMouseOverBackgroundProperty = DependencyProperty.Register(
            "ScrollButtonMouseOverBackground", typeof(Brush), typeof(ScrollBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Purple)));

        public Brush ScrollButtonForeground
        {
            get => (Brush)GetValue(ScrollButtonForegroundProperty);
            set => SetValue(ScrollButtonForegroundProperty, value);
        }
        public static readonly DependencyProperty ScrollButtonForegroundProperty = DependencyProperty.Register(
            "ScrollButtonForeground", typeof(Brush), typeof(ScrollBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public Thickness ScrollButtonBorderThickness
        {
            get => (Thickness)GetValue(ScrollButtonBorderThicknessProperty);
            set => SetValue(ScrollButtonBorderThicknessProperty, value);
        }
        public static readonly DependencyProperty ScrollButtonBorderThicknessProperty = DependencyProperty.Register(
            "ScrollButtonBorderThickness", typeof(Thickness), typeof(ScrollBar), new FrameworkPropertyMetadata(new Thickness(0)));
        public Brush ScrollButtonBorderBrush
        {
            get => (Brush)GetValue(ScrollButtonBorderBrushProperty);
            set => SetValue(ScrollButtonBorderBrushProperty, value);
        }
        public static readonly DependencyProperty ScrollButtonBorderBrushProperty = DependencyProperty.Register(
            "ScrollButtonBorderBrush", typeof(Brush), typeof(ScrollBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public CornerRadius ScrollButtonCornerRadius
        {
            get => (CornerRadius)GetValue(ScrollButtonCornerRadiusProperty);
            set => SetValue(ScrollButtonCornerRadiusProperty, value);
        }
        public static readonly DependencyProperty ScrollButtonCornerRadiusProperty = DependencyProperty.Register(
            "ScrollButtonCornerRadius", typeof(CornerRadius), typeof(ScrollBar), new FrameworkPropertyMetadata(new CornerRadius(0)));
        #endregion
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}