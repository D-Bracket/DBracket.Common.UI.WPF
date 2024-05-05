using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Controls
{
    public class Flyout : ContentControl
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
        public bool IsOpened
        {
            get => (bool)GetValue(IsOpenedProperty);
            set => SetValue(IsOpenedProperty, value);
        }
        public static readonly DependencyProperty IsOpenedProperty = DependencyProperty.Register(
            "IsOpened", typeof(bool), typeof(Flyout), new FrameworkPropertyMetadata(null));        
        
        public Dock Dock
        {
            get => (Dock)GetValue(DockProperty);
            set => SetValue(DockProperty, value);
        }
        public static readonly DependencyProperty DockProperty = DependencyProperty.Register(
            "Dock", typeof(Dock), typeof(Flyout), new FrameworkPropertyMetadata(Dock.Left));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}