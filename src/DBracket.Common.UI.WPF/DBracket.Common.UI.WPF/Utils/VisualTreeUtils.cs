using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DBracket.Common.UI.WPF.Utils
{
    public class VisualTreeUtils
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static DependencyObject? FindParent(DependencyObject child, string ancestorType)
        {
            DependencyObject parent = child;
            var type = string.Empty;
            do
            {
                parent = VisualTreeHelper.GetParent(parent);
                if (parent is null)
                    break;
                type = parent.GetType().Name;
            }
            while(type != ancestorType);
            return parent;
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