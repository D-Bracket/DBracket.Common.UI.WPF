using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DBracket.Common.UI.WPF.Controls
{
    public class ColorAnimator : FrameworkElement
    {
        #region "----------------------------- Private Fields ------------------------------"
        private ColorAnimation _animation;
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private static void HandleDefaultColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ColorAnimator animator)
                throw new Exception();

            animator.ColorOutput = animator.ColorDefault;
        }

        private static void HandleIsTriggeredChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ColorAnimator animator)
                throw new Exception();

            if (animator.IsTriggered)
            {
                animator._animation = new ColorAnimation(animator.ColorAnimatedTarget, animator.Duration);
                animator.BeginAnimation(ColorOutputProperty, animator._animation);
            }
            else
            {
                animator._animation = new ColorAnimation(animator.ColorDefault, animator.Duration);
                animator.BeginAnimation(ColorOutputProperty, animator._animation);
            }
        }
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
            "Name", typeof(string), typeof(ColorAnimator), new FrameworkPropertyMetadata(string.Empty));

        public bool IsTriggered
        {
            get => (bool)GetValue(IsTriggeredProperty);
            set => SetValue(IsTriggeredProperty, value);
        }
        public static readonly DependencyProperty IsTriggeredProperty = DependencyProperty.Register(
            "IsTriggered", typeof(bool), typeof(ColorAnimator), new FrameworkPropertyMetadata(false, HandleIsTriggeredChanged));

        public Color ColorOutput
        {
            get => (Color)GetValue(ColorOutputProperty);
            set => SetValue(ColorOutputProperty, value);
        }
        public static readonly DependencyProperty ColorOutputProperty = DependencyProperty.Register(
            "ColorOutput", typeof(Color), typeof(ColorAnimator), new FrameworkPropertyMetadata(Colors.Transparent));

        public Color ColorDefault
        {
            get => (Color)GetValue(ColorDefaultProperty);
            set => SetValue(ColorDefaultProperty, value);
        }
        public static readonly DependencyProperty ColorDefaultProperty = DependencyProperty.Register(
            "ColorDefault", typeof(Color), typeof(ColorAnimator), new FrameworkPropertyMetadata(Colors.Transparent, HandleDefaultColorChanged));

        public Color ColorAnimatedTarget
        {
            get => (Color)GetValue(ColorAnimatedTargetProperty);
            set => SetValue(ColorAnimatedTargetProperty, value);
        }
        public static readonly DependencyProperty ColorAnimatedTargetProperty = DependencyProperty.Register(
            "ColorAnimatedTarget", typeof(Color), typeof(ColorAnimator), new FrameworkPropertyMetadata(Colors.Transparent));

        public TimeSpan Duration
        {
            get => (TimeSpan)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            "Duration", typeof(TimeSpan), typeof(ColorAnimator), new FrameworkPropertyMetadata(new TimeSpan(0,0,0,0,400)));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}