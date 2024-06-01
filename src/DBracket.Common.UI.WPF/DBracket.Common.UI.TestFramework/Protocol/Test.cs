using DBracket.Common.UI.WPF.Bases;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    public class Test : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

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

        public string Description { get => _description; set { _description = value; OnMySelfChanged(); } }
        private string _description;

        public TestSequence TestSequence { get => _testSequence; set { _testSequence = value; OnMySelfChanged(); } }
        private TestSequence _testSequence;



        public TestResult Result { get => _result; set { _result = value; OnMySelfChanged(); } }
        private TestResult _result;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}