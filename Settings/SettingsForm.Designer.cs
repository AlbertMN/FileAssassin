namespace Settings {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.removeListItemBtn = new System.Windows.Forms.Button();
            this.addToListBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.browseFolderButton = new System.Windows.Forms.Button();
            this.folderPathField = new System.Windows.Forms.TextBox();
            this.folderListView = new System.Windows.Forms.ListView();
            this.filetypeListInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // removeListItemBtn
            // 
            this.removeListItemBtn.Location = new System.Drawing.Point(267, 134);
            this.removeListItemBtn.Name = "removeListItemBtn";
            this.removeListItemBtn.Size = new System.Drawing.Size(63, 20);
            this.removeListItemBtn.TabIndex = 24;
            this.removeListItemBtn.Text = "Remove";
            this.removeListItemBtn.UseVisualStyleBackColor = true;
            this.removeListItemBtn.Click += new System.EventHandler(this.removeListItemBtn_Click);
            // 
            // addToListBtn
            // 
            this.addToListBtn.Location = new System.Drawing.Point(267, 108);
            this.addToListBtn.Name = "addToListBtn";
            this.addToListBtn.Size = new System.Drawing.Size(63, 20);
            this.addToListBtn.TabIndex = 23;
            this.addToListBtn.Text = "Add";
            this.addToListBtn.UseVisualStyleBackColor = true;
            this.addToListBtn.Click += new System.EventHandler(this.addToListBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Folders to delete in";
            // 
            // browseFolderButton
            // 
            this.browseFolderButton.Location = new System.Drawing.Point(186, 108);
            this.browseFolderButton.Name = "browseFolderButton";
            this.browseFolderButton.Size = new System.Drawing.Size(75, 20);
            this.browseFolderButton.TabIndex = 21;
            this.browseFolderButton.Text = "Browse";
            this.browseFolderButton.UseVisualStyleBackColor = true;
            this.browseFolderButton.Click += new System.EventHandler(this.browseFolderButton_Click);
            // 
            // folderPathField
            // 
            this.folderPathField.Location = new System.Drawing.Point(15, 108);
            this.folderPathField.Name = "folderPathField";
            this.folderPathField.Size = new System.Drawing.Size(164, 20);
            this.folderPathField.TabIndex = 20;
            // 
            // folderListView
            // 
            this.folderListView.Location = new System.Drawing.Point(15, 134);
            this.folderListView.Name = "folderListView";
            this.folderListView.Size = new System.Drawing.Size(246, 97);
            this.folderListView.TabIndex = 19;
            this.folderListView.UseCompatibleStateImageBehavior = false;
            // 
            // filetypeListInput
            // 
            this.filetypeListInput.Location = new System.Drawing.Point(15, 26);
            this.filetypeListInput.Name = "filetypeListInput";
            this.filetypeListInput.Size = new System.Drawing.Size(164, 20);
            this.filetypeListInput.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Filetypes to delete (seperate by comma)";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeListItemBtn);
            this.Controls.Add(this.addToListBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseFolderButton);
            this.Controls.Add(this.folderPathField);
            this.Controls.Add(this.folderListView);
            this.Controls.Add(this.filetypeListInput);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "FileAssassin Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button removeListItemBtn;
        private System.Windows.Forms.Button addToListBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseFolderButton;
        private System.Windows.Forms.TextBox folderPathField;
        private System.Windows.Forms.ListView folderListView;
        private System.Windows.Forms.TextBox filetypeListInput;
        private System.Windows.Forms.Label label1;
    }
}