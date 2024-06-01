using DBracket.Common.UI.TestFramework.Protocol;
using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    public class WindowContainer : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        internal readonly Window _window;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public WindowContainer(Window window)
        {
            _window = window;

            var windowType = window.GetType();
            Name = windowType.Name;
            Type = windowType.Assembly.GetName().Name;
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

        public string Type { get => _type; set { _type = value; OnMySelfChanged(); } }
        private string _type;

        public ObservableCollection<TestSequence> TestSequences { get => _testSequences; set { _testSequences = value; OnMySelfChanged(); } }
        private ObservableCollection<TestSequence> _testSequences = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}