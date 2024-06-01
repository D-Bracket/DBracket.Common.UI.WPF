using System.Windows;

namespace DBracket.Common.UI.TestFramework.Controls
{
    public static class ControlAccess
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static Dictionary<Type, IControlAccess> _registeredControls = new();
        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static bool RegisterControlAccessType(Type controlType, IControlAccess controlAccess)
        {
            if (_registeredControls.ContainsKey(controlType))
                return false;
                //throw new Exception($"Control: {controlType} has already been registered");

            _registeredControls.Add(controlType, controlAccess);
            return true;
        }

        public static void RegisterControl(DependencyObject control)
        {
            if (_registeredControls.ContainsKey(control.GetType()) == false)
                throw new Exception();

            var controlAccess = _registeredControls[control.GetType()];
            controlAccess.RegisterControlEvents(control);
        }

        public static IControlAccess GetControlAccess(Type controlType)
        {
            if ( _registeredControls.ContainsKey(controlType))
                return _registeredControls[controlType];

            throw new Exception($"Control: {controlType} has not been registered");
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