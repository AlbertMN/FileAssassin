using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCAWeb.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Settings {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            Application.EnableVisualStyles();
            InitializeComponent();

            string rowItems = Program.GetSetting(Program.SettingType.folders);
            if (rowItems != String.Empty) {
                if (rowItems[rowItems.Length - 1] == ',') {
                    rowItems = rowItems.Remove(rowItems.Length - 1);
                }
                string[] row = rowItems.Split(',');
                foreach (string item in row) {
                    folderListView.Items.Add(new ListViewItem(item));
                }
            }

            filetypeListInput.KeyDown += new KeyEventHandler(FreakingStopDingSoundNoHandle);
            folderPathField.KeyDown += new KeyEventHandler(FreakingStopDingSound);

            void FreakingStopDingSound(Object o, KeyEventArgs e) {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            void FreakingStopDingSoundNoHandle(Object o, KeyEventArgs e) {
                if (e.KeyCode == Keys.Enter) {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
            filetypeListInput.KeyDown += delegate { Program.SetSetting(Program.SettingType.extensions, filetypeListInput.Text); };
            filetypeListInput.KeyUp += delegate { Program.SetSetting(Program.SettingType.extensions, filetypeListInput.Text); };
            filetypeListInput.Text = Program.GetSetting(Program.SettingType.extensions);
        }

        private void browseFolderButton_Click(object sender, EventArgs e) {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                folderPathField.Text = dialog.FileName;
            }
        }

        private void addToListBtn_Click(object sender, EventArgs e) {
            string thePath = folderPathField.Text;
            if (thePath != String.Empty) {
                try {
                    if (Directory.Exists(thePath)) {
                        string theFolders = Program.GetSetting(Program.SettingType.folders);
                        if (!theFolders.Contains(thePath)) {
                            UserFileAccessRights rights = new UserFileAccessRights(thePath);
                            if (rights.canDelete()) {
                                string[] row = { thePath };
                                folderListView.Items.Add(new ListViewItem(row));
                                folderPathField.Text = "";
                                Program.SetSetting(Program.SettingType.folders, theFolders + thePath + ",");
                            } else {
                                MessageBox.Show("This software does not have permission to delete files in this folder. Try open as administrator, or pick a different folder.");
                            }
                        } else {
                            MessageBox.Show("This folder has already been added");
                        }
                    } else {
                        MessageBox.Show("Folder doesn't exist");
                    }
                } catch {
                    MessageBox.Show("Invalid folder path format");
                }
            } else {
                MessageBox.Show("Please enter a path");
            }
        }

        private void removeListItemBtn_Click(object sender, EventArgs e) {
            string totalFolders = Program.GetSetting(Program.SettingType.folders);

            foreach (ListViewItem item in folderListView.SelectedItems) {
                item.Remove();
                totalFolders = totalFolders.Replace(item.Text + ",", "");
            }
            Program.SetSetting(Program.SettingType.folders, totalFolders);
        }
    }
}
