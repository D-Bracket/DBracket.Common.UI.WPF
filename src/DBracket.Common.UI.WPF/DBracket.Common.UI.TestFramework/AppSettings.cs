using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    public class AppSettings
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public AppSettings()
        {
            var tmp = System.Reflection.Assembly.GetExecutingAssembly().Location;
            tmp = tmp.Replace(tmp.Split(@"\").Last(),"");
            ConfigurationPath = $@"{tmp}Configurations\";
            if (Directory.Exists(ConfigurationPath) == false)
                Directory.CreateDirectory(ConfigurationPath);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string ConfigurationPath { get; set; } 
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}