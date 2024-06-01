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
        public static void ReportEvent(string message)
        {
            MessageReceived?.Invoke(message);
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

        public static event MessageHandler? MessageReceived;
        public delegate void MessageHandler(string message);
        #endregion
        #endregion
    }
}