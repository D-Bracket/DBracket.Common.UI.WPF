using System.Collections.ObjectModel;

namespace DBracket.Common.TestFramework
{
    public interface IEvent
    {
        #region "--------------------------------- Methods ---------------------------------"

        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        public string Name { get; set; }
        public string Description { get; set; }
        public string EventType { get; set; }
        public DateTime Time { get; set; }

        public ObservableCollection<EventDetail> Details { get; set; }
        #endregion


        #region "--------------------------------- Events ----------------------------------"

        #endregion
    }
}