using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    public class TestSequence : PropertyChangedBase
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

        public ObservableCollection<Test> Tests { get => _tests; set { _tests = value; OnMySelfChanged(); } }
        private ObservableCollection<Test> _tests = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}