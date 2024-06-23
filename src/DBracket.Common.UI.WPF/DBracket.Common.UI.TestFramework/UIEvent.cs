using DBracket.Common.TestFramework;
using DBracket.Common.UI.TestFramework.Controls;
using DBracket.Common.UI.TestFramework.Events;
using DBracket.Common.UI.WPF.Bases;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    public class UIEvent : PropertyChangedBase, IEvent
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public UIEvent(DependencyObject control)
        {
            Control = control;

            var properties = control.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var value = property.GetValue(control);
                ControlProperties.Add($"{propertyName}: {value}");
            }
        }

        [JsonConstructor]
        internal UIEvent()
        {
            //if (controlProperties.Any(x => x.Contains("Name: ")) == false)
            //    throw new Exception();

            //var name = controlProperties.Single(x => x.Contains("Name: ")).Replace("Name: ", "");
            //Control = UIReportCenter.GetControlByName(name);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void ReExecute()
        {
            if ( Control is null)
            {
                if (ControlProperties.Any(x => x.Contains("Name: ")) == false)
                    throw new Exception();

                var name = ControlProperties.Single(x => x.Contains("Name: ")).Replace("Name: ", "");
                Control = UIReportCenter.GetControlByName(name);
            }
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

        [JsonIgnore]
        public DependencyObject Control { get => _control; set { _control = value; OnMySelfChanged(); } }
        private DependencyObject _control;

        public ObservableCollection<string> ControlProperties { get => _controlProperties; set { _controlProperties = value; OnMySelfChanged(); } }
        private ObservableCollection<string> _controlProperties = new();

        public required string EventType { get => _eventType; set { _eventType = value; OnMySelfChanged(); } }
        private string _eventType;

        public ObservableCollection<EventDetail> Details { get => _details; set { _details = value; OnMySelfChanged(); } }
        private ObservableCollection<EventDetail> _details = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}