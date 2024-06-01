using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DBracket.Common.UI.WPF.Converter
{
    public class NullToBoolConverter : IValueConverter
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is bool inactivState)
            {
                return value is not null ? true : inactivState;
            }
            else
            {
                return value is not null ? true : false;
            }
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