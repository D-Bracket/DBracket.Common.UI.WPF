using DBracket.Common.UI.WPF.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBracket.Common.UI.WPF.Sample.PathExamples.ViewModel
{
    public class ImageContainer : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ImageContainer(string imagePath)
        {
            ImagePath = imagePath;
            Source = new Uri(imagePath);
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
        public Uri Source { get => _source; set { _source = value; OnMySelfChanged(); } }
        private Uri _source;

        public string ImagePath { get => _imagePath; set { _imagePath = value; OnMySelfChanged(); } }
        private string _imagePath;

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}