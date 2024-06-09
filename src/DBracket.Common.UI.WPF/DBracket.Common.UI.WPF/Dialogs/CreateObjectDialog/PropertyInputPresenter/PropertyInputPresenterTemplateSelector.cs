using System.Windows;
using System.Windows.Controls;

namespace DBracket.Common.UI.WPF.Dialogs.CreateObjectDialog.PropertyInputPresenter
{
    public class PropertyInputPresenterTemplateSelector : DataTemplateSelector
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static Dictionary<Type, DataTemplate> _templates = new();
        private static bool _templatesInitialized;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public PropertyInputPresenterTemplateSelector()
        {
            if (_templatesInitialized)
                return;

            var textBoxType = typeof(TextBoxInput);
            var textBoxTemplate = Application.Current.FindResource("TextBoxTemplate") as DataTemplate;
            RegisterPresenterTemplate(textBoxType, textBoxTemplate);

            var ComboBoxType = typeof(ComboBoxInput);
            var ComboBoxTemplate = Application.Current.FindResource("ComboBoxTemplate") as DataTemplate;
            RegisterPresenterTemplate(ComboBoxType, ComboBoxTemplate);

            var fileSelectorType = typeof(FileSelectorInput);
            var fileSelectorTemplate = Application.Current.FindResource("SelectorTempalte") as DataTemplate;
            RegisterPresenterTemplate(fileSelectorType, fileSelectorTemplate);

            _templatesInitialized = true;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static void RegisterPresenterTemplate(Type type, DataTemplate dataTemplate)
        {
            if (_templates.ContainsKey(type))
                throw new InvalidOperationException($"A DataTemplate has already been registered for the type: {type}");

            _templates.Add(type, dataTemplate);
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var type = item.GetType();

            if (_templates.ContainsKey(type) == false)
                throw new InvalidOperationException($"No DataTemplate registered for the type: {type}");

            return _templates[type];
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