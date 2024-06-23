namespace DBracket.Common.TestFramework
{
    public static class ReportCenter
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static void ReportEvent(IEvent reportedEvent)
        {
            EventReported?.Invoke(reportedEvent);
        }

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"
        public static event ReportEventHandler? EventReported;
        public delegate void ReportEventHandler(IEvent reportedEvent);
        #endregion
        #endregion
    }
}