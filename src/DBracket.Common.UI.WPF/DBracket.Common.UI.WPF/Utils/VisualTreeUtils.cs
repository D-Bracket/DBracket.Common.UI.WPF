using System.Windows;
using System.Windows.Controls;
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

        public static FrameworkElement? GetChildByName(FrameworkElement parent, string childName)
        {
            var cnt = VisualTreeHelper.GetChildrenCount(parent);
            FrameworkElement? child = null;
            for (int i = 0; i<cnt; i++)
            {
                child = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (child is null)
                    continue;
                if (child.Name == childName)
                    return child;
            }
            return null;
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