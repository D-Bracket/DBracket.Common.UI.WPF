using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBracket.Common.UI.WPF.Themes
{
    public class ThemeController
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ThemeController()
        {
            //var uiSettings = new UISettings();
            //var accentColor = uiSettings.GetColorValue(UIColorType.Accent);

            //var t = Color.FromArgb(accentColor.A, accentColor.R, accentColor.G, accentColor.B);

            var t = GetAccentColor();
            var t2 = GetWindowsTheme();
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        private enum WindowsTheme
        {
            Light,
            Dark
        }

        const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        const string RegistryValueName = "AppsUseLightTheme";

        private static WindowsTheme GetWindowsTheme()
        {
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                object registryValueObject = key?.GetValue(RegistryValueName);
                if (registryValueObject == null)
                    return WindowsTheme.Light;
                int registryValue = System.Convert.ToInt32(registryValueObject);
                return registryValue > 0 ? WindowsTheme.Light : WindowsTheme.Dark;
            }
        }


        public static (Byte r, Byte g, Byte b, Byte a) GetAccentColor()
        {
            const String DWM_KEY = @"Software\Microsoft\Windows\DWM";
            using (RegistryKey dwmKey = Registry.CurrentUser.OpenSubKey(DWM_KEY, RegistryKeyPermissionCheck.ReadSubTree))
            {
                const String KEY_EX_MSG = "The \"HKCU\\" + DWM_KEY + "\" registry key does not exist.";
                if (dwmKey is null) throw new InvalidOperationException(KEY_EX_MSG);

                Object accentColorObj = dwmKey.GetValue("AccentColor");
                if (accentColorObj is Int32 accentColorDword)
                {
                    return ParseDWordColor(accentColorDword);
                }
                else
                {
                    const String VALUE_EX_MSG = "The \"HKCU\\" + DWM_KEY + "\\AccentColor\" registry key value could not be parsed as an ABGR color.";
                    throw new InvalidOperationException(VALUE_EX_MSG);
                }
            }

        }

        private static (Byte r, Byte g, Byte b, Byte a) ParseDWordColor(Int32 color)
        {
            Byte
                a = (byte)((color >> 24) & 0xFF),
                b = (byte)((color >> 16) & 0xFF),
                g = (byte)((color >> 8) & 0xFF),
                r = (byte)((color >> 0) & 0xFF);

            return (r, g, b, a);
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
