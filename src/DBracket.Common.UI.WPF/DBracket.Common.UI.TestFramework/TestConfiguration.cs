using DBracket.Common.UI.TestFramework.Protocol;
using DBracket.Common.UI.WPF.Bases;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace DBracket.Common.UI.TestFramework
{
    public class TestConfiguration : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        internal Window _window;
        private bool _isConfigurationLoaded;
        internal string _file;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        [JsonConstructor]
        internal TestConfiguration()
        {

        }

        public TestConfiguration(Type windowType)
        {
            //_window = window;
            //WindowType = window.GetType();
            WindowType = windowType;
            Name = WindowType.Name;
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
            var configuration = JsonConvert.DeserializeObject<TestConfiguration>(configurationText);
            configuration._file = configurationFilePath;

            if (configuration is null)
                throw new Exception();

            _isConfigurationLoaded = true;
        }

        //internal static ObservableCollection<WindowContainer> LoadConfiguration(string configurationFilePath)
        //{
        //    // Create not existing configuration
        //    if (File.Exists(configurationFilePath) == false)
        //        throw new ArgumentException($"File: {configurationFilePath} does not exist");

        //    // Load configuration
        //    var configurationText = File.ReadAllText(configurationFilePath);
        //    var configuration = JsonConvert.DeserializeObject<ObservableCollection<WindowContainer>>(configurationText);

        //    if (configuration is null)
        //        throw new Exception();

        //    return configuration;
        //}

        internal static ObservableCollection<TestConfiguration> LoadConfigurations(string configurationDirectory)
        {
            var configurations = new ObservableCollection<TestConfiguration>();

            // Create not existing configuration
            if (Directory.Exists(configurationDirectory) == false)
                return configurations;

            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto
            };

            var files = Directory.GetFiles(configurationDirectory);
            foreach (var filePath in files)
            {
                // Load configuration
                var configurationText = File.ReadAllText(filePath);
                var configuration = JsonConvert.DeserializeObject<TestConfiguration>(configurationText, settings);
                configuration._file = filePath;
                configurations.Add(configuration);
            }

            return configurations;
        }

        internal static void CreateConfigurationFile(string configurationFilePath, TestConfiguration configuration)
        {
            if (File.Exists(configurationFilePath) == false)
            {
                var windowConfiguration = JsonConvert.SerializeObject(configuration);
                using (var stream = File.Open(configurationFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                {
                    using (var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
                    {
                        writer.Write(windowConfiguration);
                        writer.Flush();
                    }
                }
            }
        }

        internal void SaveConfiguration(TestConfiguration? configuration)
        {
            var windowConfiguration = JsonConvert.SerializeObject(
                configuration, 
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.Auto
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
            using (var stream = File.Open(_file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)))
                {
                    writer.Write(windowConfiguration);
                    writer.Flush();
                }
            }
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

        public Type WindowType { get => _windowType; set { _windowType = value; OnMySelfChanged(); } }
        private Type _windowType;

        public ObservableCollection<TestSequence> TestSequences { get => _testSequences; set { _testSequences = value; OnMySelfChanged(); } }
        private ObservableCollection<TestSequence> _testSequences = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}