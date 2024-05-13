using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Controls
{
    /// <summary>
    /// Icon - Data for paths, is from MahApps Metro IconPacks
    /// https://github.com/MahApps/IconPacks.Browser
    /// </summary>
    public class Icon : Control
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        private static void SwitchIcon(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newType = (IconTypes)e.NewValue;
            var icon = (Icon)d;

            switch (newType)
            {
                case IconTypes.NoIcon:
                    icon.Data = "";
                    break;

                case IconTypes.Accept_PicolIcons:
                    icon.Data = "M437.5 562.5L812.5 187.5L937.5 312.5L437.5 812.5L125 500L250 375Z";
                    icon.Flip = 1;
                    break;
            }
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        /// <summary>Data of the icon path</summary>
        public string Data
        {
            get => (string)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
        /// <summary>Data DependencyProperty</summary>
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Data", typeof(string), typeof(Icon), new FrameworkPropertyMetadata(null));

        /// <summary>Type of the icon</summary>
        public IconTypes IconType
        {
            get => (IconTypes)GetValue(IconTypeProperty);
            set => SetValue(IconTypeProperty, value);
        }
        /// <summary>IconType DependencyProperty</summary>
        public static readonly DependencyProperty IconTypeProperty = DependencyProperty.Register(
            "IconType", typeof(IconTypes), typeof(Icon), new FrameworkPropertyMetadata(SwitchIcon));

        /// <summary>
        /// -1  - Doesn't Flip the icon upside down
        /// 0   - Flips the icon upside down
        /// </summary>
        public double Flip
        {
            get => (double)GetValue(FlipProperty);
            set => SetValue(FlipProperty, value);
        }
        /// <summary>IconType DependencyProperty</summary>
        public static readonly DependencyProperty FlipProperty = DependencyProperty.Register(
            "Flip", typeof(double), typeof(Icon), new FrameworkPropertyMetadata((double)-1, null));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    /// <summary>Available Icontypes</summary>
    public enum IconTypes
    {
        /// <summary>No icon selected</summary>
        NoIcon = 0,
        /// <summary>PicolIcons.Accept</summary>
        Accept_PicolIcons,
    }
}