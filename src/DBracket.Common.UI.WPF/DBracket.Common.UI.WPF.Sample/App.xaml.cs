﻿using DBracket.Common.UI.WPF.Fonts;
using DBracket.Common.UI.WPF.Sample.Views;
using DBracket.Common.UI.WPF.Themes;
using System.Windows;

namespace DBracket.Common.UI.WPF.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region "----------------------------- Private Fields ------------------------------"
        private FontController _fontController = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //var themeController = ThemesTest.GetInstance();
            //themeController.AddTheme("DBracket.Common.UI.WPF;component/Colors/ResourcesColors.xaml", "Red");
            //themeController.AddTheme("DBracket.Common.UI.WPF;component/Styles/Icon.Styles.xaml", "Blue");

            //themeController.Initialize();
            _fontController.SetFont("JetBrainsMono_Medium");

            var window = new MainWindow();
            window.Show();
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