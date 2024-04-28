using System.Windows;

namespace DBracket.Common.UI.WPF.Charts.Controls.Components
{
    public static class AxisSettings /*: DependencyObject*/
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
        //public string Header
        //{
        //    get => (string)GetValue(HeaderProperty);
        //    set => SetValue(HeaderProperty, value);
        //}




        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty HeaderProperty = 
            DependencyProperty.RegisterAttached(
                "Header", 
                typeof(string),
                typeof(AxisSettings),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));
        public static string GetHeader(UIElement target) =>
    (string)target.GetValue(HeaderProperty);
        public static void SetHeader(UIElement target, string value) =>
            target.SetValue(HeaderProperty, value);

        //public Visibility Visibility { get => _visibility; set { _visibility = value; OnMySelfChanged(); } }
        //private Visibility _visibility = Visibility.Visible;

        //public string Header { get => _header; set { _header = value; OnMySelfChanged(); } }
        //private string _header = string.Empty;

        //public double MaxValue { get => _maxValue; set { _maxValue = value; OnMySelfChanged(); } }
        //private double _maxValue;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}