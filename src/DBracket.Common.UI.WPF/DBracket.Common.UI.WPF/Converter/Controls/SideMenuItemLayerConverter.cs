using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DBracket.Common.UI.WPF.Converter.Controls
{
    internal class SideMenuItemLayerConverter : IValueConverter
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double layer)
                return new Thickness(0,0,0,0);
            
            var result = double.TryParse(parameter.ToString(), CultureInfo.InvariantCulture, out var space);
            if (result == false) 
                return new Thickness(0,0,0,0);

            return new Thickness((space*layer),0,0,0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}