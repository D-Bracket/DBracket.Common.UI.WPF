using DBracket.Common.UI.TestFramework.Protocol;
using DBracket.Common.UI.WPF.Bases;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    public class WindowContainer : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        internal readonly Window _window;
        private bool _isConfigurationLoaded;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public WindowContainer(Window window)
        {
            _window = window;

            var windowType = window.GetType();
            Name = windowType.Name;
            Type = windowType.Assembly.GetName().Name;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        internal void LoadTestConfiguration(string configurationFilePath)
        {
            // Configuration loaded, do nothing
            if (_isConfigurationLoaded)
                return;

            // Create not existing configuration
            if (File.Exists(configurationFilePath) == false)
            {
                var windowConfiguration = JsonConvert.SerializeObject(this);
                using (var stream = File.Open(configurationFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                {
                    using (var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
                    {
                        writer.Write(windowConfiguration);
                        writer.Flush();
                    }
                }
                _isConfigurationLoaded = true;
                return;
            }

            // Load configuration
            var configurationText = File.ReadAllText(configurationFilePath);
            var configuration = JsonConvert.DeserializeObject<WindowContainer>(configurationText);

            if (configuration is null)
                throw new Exception();

            _isConfigurationLoaded = true;
        }

        internal static ObservableCollection<WindowContainer> LoadConfiguration(string configurationFilePath)
        {
            // Create not existing configuration
            if (File.Exists(configurationFilePath) == false)
                throw new ArgumentException($"File: {configurationFilePath} does not exist");

            // Load configuration
            var configurationText = File.ReadAllText(configurationFilePath);
            var configuration = JsonConvert.DeserializeObject<ObservableCollection<WindowContainer>>(configurationText);

            if (configuration is null)
                throw new Exception();

            return configuration;
        }

        //internal WindowContainer LoadWindowConfiguration(string configurationFilePath)
        //{
        //    // Create not existing configuration
        //    if (File.Exists(configurationFilePath) == false)
        //    {
        //        var windowConfiguration = JsonConvert.SerializeObject(this);
        //        using (var stream = File.Open(configurationFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        //        {
        //            using (var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
        //            {
        //                writer.Write(windowConfiguration);
        //                writer.Flush();
        //            }
        //        }
        //        _isConfigurationLoaded = true;
        //        return;
        //    }

        //    // Load configuration
        //    var configurationText = File.ReadAllText(configurationFilePath);
        //    var configuration = JsonConvert.DeserializeObject<WindowContainer>(configurationText);

        //    if (configuration is null)
        //        throw new Exception();

        //    _isConfigurationLoaded = true;
        //}
        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Name { get => _name; set { _name = value; OnMySelfChanged(); } }
        private string _name;

        public string Type { get => _type; set { _type = value; OnMySelfChanged(); } }
        private string _type;

        public ObservableCollection<TestSequence> TestSequences { get => _testSequences; set { _testSequences = value; OnMySelfChanged(); } }
        private ObservableCollection<TestSequence> _testSequences = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}