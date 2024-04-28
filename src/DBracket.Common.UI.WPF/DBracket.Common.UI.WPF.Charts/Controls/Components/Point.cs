using System.Windows;
using System.Windows.Media.Animation;

namespace DBracket.Common.UI.WPF.Charts.Controls.Components
{
    public class Point : FrameworkElement
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public Point()
        {
            
        }

        public Point(double x, double y)
        {
            Data = new System.Windows.Point(x, y);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void AnimatePoint(double value, double xOffset)
        {
            PointAnimation animation = new PointAnimation(new System.Windows.Point(xOffset, -value), new TimeSpan(0, 0, 0, 0, 400));
            this.BeginAnimation(DataProperty, animation);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public System.Windows.Point Data
        {
            get => (System.Windows.Point)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Data", typeof(System.Windows.Point), typeof(Point), new FrameworkPropertyMetadata(new System.Windows.Point()));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}