using DBracket.Common.TestFramework;
using DBracket.Common.UI.TestFramework.Controls;
using DBracket.Common.UI.TestFramework.Events;
using DBracket.Common.UI.WPF.Bases;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    public class UIEvent : PropertyChangedBase, IEvent
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UIEvent()
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void ReExecute()
        {
            var controlAccess = ControlAccess.GetControlAccess(Control.GetType());
            controlAccess.ExecuteEventType(EventType, Control);

            //switch (EventType)
            //{
            //    case UIEventType.Pressed:
            //        var button = Control as Button;
            //        if (button is not null)
            //        {
            //            var buttonType = button.GetType();
            //            var click = buttonType.GetMethod("OnClick", BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            //            if (click is null)
            //                return;
            //            click.Invoke(button, []);
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Name { get => _name; set { _name = value; OnMySelfChanged(); } }
        private string _name;

        public string Description { get => _description; set { _description = value; OnMySelfChanged(); } }
        private string _description;

        public required DependencyObject Control { get => _control; set { _control = value; OnMySelfChanged(); } }
        private DependencyObject _control;

        public required string EventType { get => _eventType; set { _eventType = value; OnMySelfChanged(); } }
        private string _eventType;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}