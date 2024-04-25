using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DBracket.Common.UI.WPF.Converter
{
    public class DoubleSubstractConverter : IValueConverter
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double startValue)
                throw new Exception();

            var t = double.TryParse(parameter.ToString(), CultureInfo.InvariantCulture, out double valueToSubstract);
            if (!t)
                throw new Exception();
            //if (parameter is not double valueToSubstract)
            //    throw new Exception();

            return startValue - valueToSubstract;
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