using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    internal class TestConfigurationResult : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TestConfigurationResult(TestConfiguration testConfiguration)
        {
            TestConfiguration = testConfiguration;
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

        public TestConfiguration TestConfiguration { get => _testConfiguration; set { _testConfiguration = value; OnMySelfChanged(); } }
        private TestConfiguration _testConfiguration;

        public ObservableCollection<TestSequenceResult> TestSequences { get => _testSequences; set { _testSequences = value; OnMySelfChanged(); } }
        private ObservableCollection<TestSequenceResult> _testSequences = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    public enum ResultStates
    {
        NOTEST,
        FAILED,
        PASSED,
        WARNING
    }
}