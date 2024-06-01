using DBracket.Common.UI.TestFramework.Events;
using System.Windows;

namespace DBracket.Common.UI.TestFramework.Prototyping
{
    internal class CustomEvent : IUIEventType
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void ReExecuteEvent(DependencyObject control)
        {
            if (control is not TestControl testControl)
                return;

            // Example Event
            testControl.DragEnter += new DragEventHandler((object sender, DragEventArgs args) =>
            {
                // Do stuff here

            });
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

        #endregion
        #endregion
    }
}