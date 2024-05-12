using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DBracket.Common.UI.WPF.Converter
{
    // Source: https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html



    public abstract class ConverterMarkupExtension<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static T _converter = null;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ConverterMarkupExtension()
        {
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
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