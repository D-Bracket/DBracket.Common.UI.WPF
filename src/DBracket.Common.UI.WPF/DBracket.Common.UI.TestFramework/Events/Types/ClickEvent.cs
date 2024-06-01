using System.Reflection;
using System.Windows;

namespace DBracket.Common.UI.TestFramework.Events.Types
{
    public class ClickEvent : IUIEventType
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void ReExecuteEvent(DependencyObject control)
        {
            var click = control.GetType().GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic);
            if (click is null)
                return;
            click.Invoke(control, []);
            //        var button = Control as Button;
            //        if (button is not null)
            //        {
            //            var buttonType = button.GetType();
            //            var click = buttonType.GetMethod("OnClick", BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            //            if (click is null)
            //                return;
            //            click.Invoke(button, []);
            //        }
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