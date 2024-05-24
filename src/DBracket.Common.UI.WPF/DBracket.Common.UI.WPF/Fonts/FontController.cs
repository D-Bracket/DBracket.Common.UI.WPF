using System.Windows;
using System.Windows.Media;

namespace DBracket.Common.UI.WPF.Fonts
{
    public class FontController
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public FontController()
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void SetFont(string fontName)
        {
            var font = Application.Current.FindResource(fontName) as FontFamily;
            if (font is null)
                throw new ArgumentException("Font not found in App Resources");

            var themeFont = Application.Current.FindResource("ThemeFont") as FontFamily;
            if (themeFont is not null)
                Application.Current.Resources.Remove(themeFont);

            Application.Current.Resources.Add("ThemeFont", font);
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