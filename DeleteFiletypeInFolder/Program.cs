using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteFiletypeInFolder {
    class Program {
        public static string localAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FileAssassinData");
        public static string foldersLocation = Path.Combine(localAppData, "folders.txt"), extensionsLocation = Path.Combine(localAppData, "extensions.txt");
        public enum SettingType { folders, extensions };

        static void Main(string[] args) {
            if (!CreateFiles()) {
                return;
            }

            string pathsToCheck = GetSetting(SettingType.folders), extensionsToDlete = GetSetting(SettingType.extensions);
            foreach (string path in pathsToCheck.Split(',')) {
                if (path != String.Empty) {
                    if (Directory.Exists(path)) {
                        List<string> filesToDelete = new List<string>();

                        foreach (string extension in extensionsToDlete.Split(',')) {
                            foreach (string file in Directory.GetFiles(path, "*." + extension)) {
                                //Console.WriteLine(file);
                                try {
                                    File.Delete(file);
                                } catch {
                                    MessageBox.Show("Failed to delete file", "DeleteFiletypeInFolder");
                                }
                            }
                        }
                    }
                }
            }
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
            } catch (Exception ex) {
                MessageBox.Show("Could not read setting; " + ex.Message);
            }

            return content;
        }
    }
}
