using DBracket.Common.UI.TestFramework.Controls;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework
{
    internal static class UIReportCenter
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static readonly Dictionary<string, Control> _controls = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        internal static void Initialize()
        {
            // Register Control Access
            ControlAccess.RegisterControlAccessType(typeof(Button), new ButtonAccess());
        }

        internal static void RegisterControl(Control control)
        {
            if (string.IsNullOrEmpty(control.Name) == true)
                throw new ArgumentException("The name of the control must be set");

            if (_controls.ContainsKey(control.Name))
                throw new InvalidOperationException("Control already registered");

            _controls.Add(control.Name, control);
            ControlAccess.RegisterControl(control);
        }

        internal static void ReportEvent(string name, string message, string uIEventType, DependencyObject control)
        {
            var uiEvent = new UIEvent()
            {
                Name = name,
                Description = message,
                EventType = uIEventType,
                Control = control
            };

            EventReceived?.Invoke(uiEvent);
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
        internal static event EventHandler? EventReceived;
        internal delegate void EventHandler(UIEvent uiEvent);
        #endregion
        #endregion
    }
}