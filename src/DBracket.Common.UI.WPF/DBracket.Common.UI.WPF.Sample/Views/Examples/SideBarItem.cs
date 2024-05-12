using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.WPF.Sample.Views.Examples
{
    public class SideBarItem : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public SideBarItem()
        {

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
        
        public ObservableCollection<SideBarItem> SubItems { get => _subItems; set { _subItems = value; OnMySelfChanged(); } }
        private ObservableCollection<SideBarItem> _subItems = new();

        public ObservableCollection<SideBarItem> ShownSubItems { get => _shownSubItems; set { _shownSubItems = value; OnMySelfChanged(); } }
        private ObservableCollection<SideBarItem> _shownSubItems;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}