using DBracket.Common.UI.WPF.Bases;
using DBracket.Common.UI.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DBracket.Common.UI.WPF.Sample.Views.Examples
{
    public class SideBarControl : ViewModelBase
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

        #region "----------------------------- Command Handling ----------------------------"
        public override void ExecuteCommands(object? command)
        {
            throw new NotImplementedException();
        }

        private void ExecuteToggleCommand(object? obj)
        {
            if (obj is not SideBarItem item)
                return;

            if (item.SubItems.Count > 0)
            {
                if (item.ShownSubItems is not null)
                {
                    item.ShownSubItems = null;
                }
                else
                {
                    item.ShownSubItems = item.SubItems;
                }
            }
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion

        #region "-------------------------------- Commands ---------------------------------"
        /// <summary>Commands from the UI</summary>
        public ICommand ToggleCommand => new RelayCommand(ExecuteToggleCommand);
        #endregion
        #endregion
    }
}