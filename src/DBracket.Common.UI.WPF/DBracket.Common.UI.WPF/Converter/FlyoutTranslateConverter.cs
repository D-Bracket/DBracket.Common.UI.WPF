using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace DBracket.Common.UI.WPF.Converter
{
    internal class FlyoutTranslateConverter : IMultiValueConverter
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not double tag) // values from 1 to 0
                throw new ArgumentException();
            if (values[1] is not double flyoutWidth)
                throw new ArgumentException();
            if (values[2] is not double flyoutHeight)
                throw new ArgumentException();
            if (values[3] is not Dock dock) // values from 1 to 0
                throw new ArgumentException();
            if (values[4] is not bool isX) // values from 1 to 0
                throw new ArgumentException();

            //var multiplier = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);

            switch (dock)
            {
                case Dock.Left:
                    return isX ? flyoutWidth * (-tag) : 0;
                case Dock.Top:
                    return isX ? 0 : flyoutHeight * (-tag);
                case Dock.Right:
                    return isX ? flyoutWidth * (tag) : 0;
                case Dock.Bottom:
                    return isX ? 0 : flyoutHeight * (tag);
                default:
                    return 0;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
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