using DBracket.Common.TestFramework;
using DBracket.Common.UI.TestFramework.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework
{
    internal static class UIReportCenter
    {
        #region "----------------------------- Private Fields ------------------------------"
        //private static readonly Dictionary<Type, Dictionary<string, Control>> _controls = new();
        private static readonly Dictionary<string, Control> _controls = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        static UIReportCenter()
        {

        }
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
            var name = $"{control.Name}";//$"{parentControl.GetType().Name}.{control.Name}";
            if (string.IsNullOrEmpty(name) == true)
                throw new ArgumentException("The name of the control must be set");

            if (_controls.ContainsKey(name))
                Debug.WriteLine("Control already registered");

            _controls.Add(name, control);
            ControlAccess.RegisterControl(control);
        }

        internal static void ReportEvent(string name, string message, string uIEventType, DependencyObject control)
        {
            var uiEvent = new UIEvent(control)
            {
                Name = name,
                Description = message,
                EventType = uIEventType,
            };

            ReportEvent(uiEvent);
            //EventReceived?.Invoke(uiEvent);
        }

        internal static void ReportEvent(IEvent @event)
        {
            ReportCenter.ReportEvent(@event);
        }

        internal static DependencyObject GetControlByName(string name)
        {
            if (_controls.ContainsKey(name))
                return _controls[name];

            throw new Exception("Control not registered");
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
        //internal static event EventHandler? EventReceived;
        //internal delegate void EventHandler(UIEvent uiEvent);
        #endregion
        #endregion
    }
}