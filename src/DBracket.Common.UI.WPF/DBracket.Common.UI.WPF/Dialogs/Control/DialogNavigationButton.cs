using DBracket.Common.UI.WPF.Bases;
using System.Windows;

namespace DBracket.Common.UI.WPF.Dialogs.Control
{
    /// <summary>Button for the navigation in a dialog</summary>
    public class DialogNavigationButton : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        /// <summary>Button for the navigation in a dialog</summary>
        public DialogNavigationButton()
        {
            SpaceToLeft = 0;
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
        /// <summary>Content of the Button</summary>
        public required string Content { get => _content; set { _content = value; OnMySelfChanged(); } }
        private string _content = string.Empty;

        /// <summary>Parameter that is send, when the bound Command should be executed</summary>
        public required string CommandParameter { get => _commandParameter; set { _commandParameter = value; OnMySelfChanged(); } }
        private string _commandParameter = string.Empty;

        /// <summary>Space to the left of the button</summary>
        public double SpaceToLeft { get => _saceToLeft; set { _saceToLeft = value; Margin = new Thickness(value, 0, 0, 0); OnMySelfChanged(); } }
        private double _saceToLeft;

        /// <summary>Margin to other objects</summary>
        public Thickness Margin { get => _margin; internal set { _margin = value; OnMySelfChanged(); } }
        private Thickness _margin = new Thickness(0,0,0,0);

        /// <summary>Button Width</summary>
        public double Width { get => _width; set { _width = value; OnMySelfChanged(); } }
        private double _width = 40;

        /// <summary>Determines wheter the button is only enabled under certain conditions</summary>
        public bool IsEnabled { get => _isEnabled; set { _isEnabled = value; OnMySelfChanged(); } }
        private bool _isEnabled = true;
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}