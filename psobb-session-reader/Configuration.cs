using System;
using System.IO;
using System.Xml.Linq;

namespace psobb_session_reader
{
    public class Configuration
    {
        public string PSOPath { get; set; }
        public int MainWindowX { get; set; }
        public int MainWindowY { get; set; }
        public int MainWindowWidth { get; set; }
        public int MainWindowHeight { get; set; }

        public void Save()
        {
            Save(DefaultPath);
        }

        public void Save(string path)
        {
            object[] settings =
            {
                new XElement(nameof(PSOPath), PSOPath),
                new XElement(nameof(MainWindowX), MainWindowX),
                new XElement(nameof(MainWindowY), MainWindowY),
                new XElement(nameof(MainWindowWidth), MainWindowWidth),
                new XElement(nameof(MainWindowHeight), MainWindowHeight)
            };

            string directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);

            XElement root = new XElement(nameof(Configuration), settings);
            XDocument document = new XDocument(root);
            document.Save(path);
        }

        public static Configuration Load()
        {
            return Load(DefaultPath);
        }

        public static Configuration Load(string path)
        {
            Configuration configuration = new Configuration();
            XDocument document = XDocument.Load(path);
            XElement root = document.Root;
            configuration.PSOPath = Read<string>(root, nameof(PSOPath));
            configuration.MainWindowX = Read<int>(root, nameof(MainWindowX));
            configuration.MainWindowY = Read<int>(root, nameof(MainWindowY));
            configuration.MainWindowWidth = Read<int>(root, nameof(MainWindowWidth));
            configuration.MainWindowHeight = Read<int>(root, nameof(MainWindowHeight));
            return configuration;
        }

        private static T Read<T>(XElement element, string name)
        {
            object value = (string)element.Element(name);

            if (value == null)
                return default(T);

            if (typeof(T) == typeof(string))
                return (T)value;

            return (T)Convert.ChangeType(value, typeof(T));
        }

        private static readonly string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string DefaultPath = Path.Combine(ApplicationData, "psobb-session-reader", "Settings.xml");
    }
}
