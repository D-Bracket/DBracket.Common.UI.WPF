using DBracket.Common.UI.WPF.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBracket.Common.UI.WPF.Charts.Data
{
    public class ChartDataPoint : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ChartDataPoint(double value)
        {
            Value = value;
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
        public double Value { get => _value; set { _value = value; OnMySelfChanged(); } }
        private double _value;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}