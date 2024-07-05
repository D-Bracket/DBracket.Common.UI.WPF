using DBracket.Common.TestFramework;
using DBracket.Common.UI.WPF.Bases;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    public class EventAssertion : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        private IEvent _event;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public EventAssertion(IEvent @event)
        {
            _event = @event;
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
        public EventDetail EventDetail { get => _eventDetail; set { _eventDetail = value; OnMySelfChanged(); } }
        private EventDetail _eventDetail;

        public EventDetailParameter Parameter { get => _parameter; set { _parameter = value; OnMySelfChanged(); } }
        private EventDetailParameter _parameter;

        //public string EventDetail { get => _eventDetail; set { _eventDetail = value; OnMySelfChanged(); } }
        //private string _eventDetail;

        //public string Parameter { get => _parameter; set { _parameter = value; OnMySelfChanged(); } }
        //private string _parameter;

        public EventAssertionTypes SelectedAssertionType { get => _selectedAssertionType; set { _selectedAssertionType = value; OnMySelfChanged(); } }
        private EventAssertionTypes _selectedAssertionType;

        public double LowerLimit { get => _lowerLimit; set { _lowerLimit = value; OnMySelfChanged(); } }
        private double _lowerLimit;

        public double UpperLimit { get => _upperLimit; set { _upperLimit = value; OnMySelfChanged(); } }
        private double _upperLimit;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    public enum EventAssertionTypes
    {
        Equals,
        Contains,
        InRange,
        Regex
    }
}