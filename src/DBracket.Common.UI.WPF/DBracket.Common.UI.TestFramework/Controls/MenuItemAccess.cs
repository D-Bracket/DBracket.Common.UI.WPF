using DBracket.Common.UI.TestFramework.Events.Types;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework.Controls
{
    public class MenuItemAccess : IControlAccess
    {
        #region "----------------------------- Private Fields ------------------------------"
        private const string EVENT_CLICK = "event_Click";
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public MenuItemAccess()
        {
            RegisterEventType(EVENT_CLICK, new ClickEvent());
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override void RegisterControlEvents(DependencyObject control)
        {
            if (control is not MenuItem menuItem)
                throw new ArgumentException("Control must be of Type Button");

            menuItem.Click += (s, e) =>
            {
                UIReportCenter.ReportEvent(menuItem.Name, "MenuItem_Clicked", EVENT_CLICK, menuItem);
            };
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