using DBracket.Common.UI.TestFramework.Controls;
using DBracket.Common.UI.TestFramework.Events.Types;
using System.Windows;

namespace DBracket.Common.UI.TestFramework.Prototyping
{
    internal class TestControlAccess : IControlAccess
    {
        #region "----------------------------- Private Fields ------------------------------"
        private const string EVENT_CLICK = "event_Click";
        private const string EVENT_CUSTOMEVENT = "event_CustomEvent";
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TestControlAccess()
        {
            RegisterEventType(EVENT_CLICK, new ClickEvent());
            RegisterEventType(EVENT_CUSTOMEVENT, new CustomEvent());
        }

        public override void RegisterControlEvents(DependencyObject control)
        {
            if (control is not TestControl button)
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