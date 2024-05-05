using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DBracket.Common.UI.WPF.Converter
{
    public class DoubleMuilitplyConverter : IValueConverter
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double doubleValue)
                throw new Exception("Value needs to be a double");
            if (parameter is not string)
                throw new Exception();

            var multiplier = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);

            return doubleValue * multiplier;
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