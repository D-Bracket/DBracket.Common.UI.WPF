using DBracket.Common.UI.TestFramework.Controls;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework.Prototyping
{
    /// <summary>Testcontrol to show how the user can implement UI testing functionalities in custom controls</summary>
    public class TestControl : Button
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TestControl()
        {
            var controlAccess = new TestControlAccess();
            ControlAccess.RegisterControlAccessType(typeof(TestControl), controlAccess);
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

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}