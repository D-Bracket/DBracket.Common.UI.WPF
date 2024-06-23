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
        public string Name { get => _name; set { _name = value; OnMySelfChanged(); } }
        private string _name;

        public EventAssertionTypes SelectedAssertionType { get => _selectedAssertionType; set { _selectedAssertionType = value; OnMySelfChanged(); } }
        private EventAssertionTypes _selectedAssertionType;

        public string LowerLimit { get => _lowerLimit; set { _lowerLimit = value; OnMySelfChanged(); } }
        private string _lowerLimit;

        public string UpperLimit { get => _upperLimit; set { _upperLimit = value; OnMySelfChanged(); } }
        private string _upperLimit;
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