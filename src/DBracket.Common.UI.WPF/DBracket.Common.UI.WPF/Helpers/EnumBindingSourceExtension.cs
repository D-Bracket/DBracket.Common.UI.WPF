using System.Windows.Markup;

namespace DBracket.Common.UI.WPF.Helpers
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public EnumBindingSourceExtension()
        {

        }

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || enumType.IsEnum == false)
                throw new ArgumentException("Type must nit be null and of type Enum");

            EnumType = enumType;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (EnumType is null)
                return new string[1];

            return Enum.GetValues(EnumType);
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public Type? EnumType { get; private set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}