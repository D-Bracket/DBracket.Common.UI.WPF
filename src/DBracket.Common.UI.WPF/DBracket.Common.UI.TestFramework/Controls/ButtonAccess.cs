using DBracket.Common.UI.TestFramework.Events.Types;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework.Controls
{
    internal class ButtonAccess : IControlAccess
    {
        #region "----------------------------- Private Fields ------------------------------"
        private const string EVENT_CLICK = "event_Click";
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ButtonAccess()
        {
            RegisterEventType(EVENT_CLICK, new ClickEvent());
        }

        public override void RegisterControlEvents(DependencyObject control)
        {
            if (control is not Button button)
                throw new ArgumentException("Control must be of Type Button");

            button.Click += (s, e) =>
            {
                UIReportCenter.ReportEvent(button.Name, "button_Clicked", EVENT_CLICK, button);
            };
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

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}