using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    internal class TestSequenceResult : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TestSequenceResult(TestSequence testSequence)
        {
            TestSequence = testSequence;
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
        public bool IsExpanded { get => _isExpanded; set { _isExpanded = value; OnMySelfChanged(); } }
        private bool _isExpanded;



        public ResultStates Result { get => _result; set { _result = value; OnMySelfChanged(); } }
        private ResultStates _result = ResultStates.NOTEST;

        public TestSequence TestSequence { get => _testSequence; set { _testSequence = value; OnMySelfChanged(); } }
        private TestSequence _testSequence;

        public ObservableCollection<TestResult> Tests { get => _tests; set { _tests = value; OnMySelfChanged(); } }
        private ObservableCollection<TestResult> _tests = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}