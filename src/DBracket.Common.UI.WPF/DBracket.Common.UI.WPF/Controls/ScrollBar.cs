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
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}