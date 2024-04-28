using System.Windows;

namespace DBracket.Common.UI.WPF.Helpers
{
    public class BindingProxy : Freezable
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public BindingProxy()
        {
            
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();  
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public object DataSource
        {
            get => (object)GetValue(DataSourceProperty);
            set => SetValue(DataSourceProperty, value);
        }

        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(BindingProxy),
                new FrameworkPropertyMetadata(null));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}