using DBracket.Common.UI.TestFramework.Events;
using System.Windows;

namespace DBracket.Common.UI.TestFramework.Controls
{
    public abstract class IControlAccess
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void RegisterEventType(string name, IUIEventType uIEventType)
        {
            if (EventTypes.ContainsKey(name))
                throw new Exception("Event Type: , for Control: is already registered");

            EventTypes.Add(name, uIEventType);
        }

        public void ExecuteEventType(string eventType, DependencyObject control)
        {
            if (EventTypes.ContainsKey(eventType) == false)
                throw new Exception("");

            var type = EventTypes[eventType];
            type.ReExecuteEvent(control);
        }

        public abstract void RegisterControlEvents(DependencyObject control);
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public Dictionary<string, IUIEventType> EventTypes { get; } = new Dictionary<string, IUIEventType>();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}