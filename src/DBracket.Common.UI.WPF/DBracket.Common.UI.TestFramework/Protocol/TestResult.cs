using DBracket.Common.UI.WPF.Bases;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    public class TestResult : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TestResult(Test test)
        {
            Test = test;
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
        public ResultStates Result { get => _result; set { _result = value; OnMySelfChanged(); } }
        private ResultStates _result = ResultStates.NOTEST;

        public Test Test { get => _test; set { _test = value; OnMySelfChanged(); } }
        private Test _test;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}