using DBracket.Common.UI.WPF.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBracket.Common.UI.WPF.Themes
{
    public class ThemesTest : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static ThemesTest _instance;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        private ThemesTest()
        {
            //AddTheme("DBracket.Common.UI.WPF;component/Colors/ResourcesColors.xaml", "Red");
            //AddTheme("DBracket.Common.UI.WPF;component/Styles/Icon.Styles.xaml", "Blue");
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static ThemesTest GetInstance()
        {
            if (_instance is null)
                _instance = new ThemesTest();

            return _instance;
        }

        public void Initialize()
        {

        }

        public void AddTheme(string path, string name)
        {
            // path = "/DllName;component/Resources/MyResourceDictionary.xaml";

            var myResourceDictionary = new ResourceDictionary();
            myResourceDictionary.Source =
                new Uri(path, UriKind.RelativeOrAbsolute);
            Themes.Add(name, myResourceDictionary);
        }

        public void SwitchTheme(string name)
        {
            if (Themes.ContainsKey(name))
            {

            }
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        /// <summary></summary>
        public Dictionary<string, ResourceDictionary> Themes { get { return _themes; } set { _themes = value; OnMySelfChanged(); } }
        private Dictionary<string, ResourceDictionary> _themes = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}