using DBracket.Common.TestFramework;
using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    internal class EventTemplateSelector : DataTemplateSelector
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public EventTemplateSelector()
        {
            
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is not EventToTest eventToTest)
                throw new ArgumentException("Wrong type");

            if (eventToTest.Event is UIEvent)
                return UIEventDataTemplate;

            if (eventToTest.Event is Event)
                return EventDataTemplate;

            throw new Exception("Unkown event type");
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public DataTemplate UIEventDataTemplate { get; set; }
        public DataTemplate EventDataTemplate { get; set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}