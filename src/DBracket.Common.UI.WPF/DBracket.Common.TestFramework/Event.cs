using System.Collections.ObjectModel;

namespace DBracket.Common.TestFramework
{
    public class Event : IEvent
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
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Time { get; set; }

        public required string EventType { get => _eventType; set { _eventType = value;  } }
        private string _eventType;

        public ObservableCollection<EventDetail> Details { get => _details; set { _details = value; } }
        private ObservableCollection<EventDetail> _details = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}
