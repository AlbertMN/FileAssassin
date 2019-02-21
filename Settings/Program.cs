using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings {
    public static class Program {
        public static string localAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FileAssassinData");
        public static string foldersLocation = Path.Combine(localAppData, "folders.txt"), extensionsLocation = Path.Combine(localAppData, "extensions.txt");
        public enum SettingType { folders, extensions };

        [STAThread]
        static void Main() {
            CreateFiles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingsForm());
        }

        private static bool CreateFiles() {
            if (!Directory.Exists(localAppData)) {
                try {
                    var dir = Directory.CreateDirectory(localAppData);
                } catch {
                    MessageBox.Show("Failed to create settings folder");
                }
            }

            if (!File.Exists(foldersLocation))
                try {
                    using (var myFile = File.Create(foldersLocation)) ;
                } catch {
                    MessageBox.Show("Failed to create folder-settings file");
                    return false;
                }
            if (!File.Exists(extensionsLocation))
                try {
                    using (var myFile = File.Create(extensionsLocation)) ;
                } catch {
                    MessageBox.Show("Failed to create extensions-settings file");
                    return false;
                }
            return true;
        }

        public static void SetSetting(SettingType type, string content) {
            if (!CreateFiles())
                return;

            string path;
            switch (type) {
                case SettingType.folders:
                    path = foldersLocation;
                    break;
                case SettingType.extensions:
                    path = extensionsLocation;
                    break;
                default:
                    MessageBox.Show("Invalid setting type");
                    return;
            }
            File.WriteAllText(path, content);
        }

        public static bool FileInUse(string file) {
            if (File.Exists(file)) {
                try {
                    using (Stream stream = new FileStream(file, FileMode.Open)) {
                        // File/Stream manipulating code here
                        return false;
                    }
                } catch {
                    Thread.Sleep(50);
                    return true;
                }
            }
            return false;
        }

        public static string GetSetting(SettingType type) {
            if (!CreateFiles())
                return "";

            string path;
            switch (type) {
                case SettingType.folders:
                    path = foldersLocation;
                    break;
                case SettingType.extensions:
                    path = extensionsLocation;
                    break;
                default:
                    MessageBox.Show("Invalid setting type");
                    return "";
            }
            string content = "";

            while (FileInUse(path)) ;
            try {
                content = File.ReadAllText(path);
            } catch {
                MessageBox.Show("Could not read setting");
            }

            return content;
        }

        public static string GetFolders() {
            return GetSetting(SettingType.folders);
        }
        public static string GetExtensions() {
            return GetSetting(SettingType.extensions);
        }
    }
}
