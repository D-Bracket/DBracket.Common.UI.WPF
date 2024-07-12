using DBracket.Common.TestFramework;
using DBracket.Common.UI.WPF.Bases;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    public class EventResult : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public EventResult(EventToTest referenceEvent, IEvent testResult)
        {
            ReferenceEvent = referenceEvent;
            TestResult = testResult;
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
        public EventToTest ReferenceEvent { get => _referenceEvent; set { _referenceEvent = value; OnMySelfChanged(); } }
        private EventToTest _referenceEvent;

        public IEvent TestResult { get => _testResult; set { _testResult = value; OnMySelfChanged(); } }
        private IEvent _testResult;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}