using DBracket.Common.UI.WPF.Bases;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

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

        [JsonIgnore]
        public TestSequence TestSequence { get => _testSequence; set { _testSequence = value; OnMySelfChanged(); } }
        private TestSequence _testSequence;

        public ObservableCollection<EventToTest> Events { get => _events; set { _events = value; OnMySelfChanged(); } }
        private ObservableCollection<EventToTest> _events = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}