namespace psobb_session_reader
{
    partial class PathPrompt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pathTextBox = new System.Windows.Forms.TextBox();
            this._pathLabel = new System.Windows.Forms.Label();
            this._mainPanel = new System.Windows.Forms.Panel();
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._pathPanel = new System.Windows.Forms.Panel();
            this._browseButton = new System.Windows.Forms.Button();
            this._initializationScriptPathDialog = new System.Windows.Forms.OpenFileDialog();
            this._mainPanel.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this._pathPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pathTextBox
            // 
            this._pathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pathTextBox.Location = new System.Drawing.Point(0, 0);
            this._pathTextBox.Name = "_pathTextBox";
            this._pathTextBox.Size = new System.Drawing.Size(458, 20);
            this._pathTextBox.TabIndex = 0;
            // 
            // _pathLabel
            // 
            this._pathLabel.AutoSize = true;
            this._pathLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._pathLabel.Location = new System.Drawing.Point(10, 10);
            this._pathLabel.Name = "_pathLabel";
            this._pathLabel.Size = new System.Drawing.Size(352, 13);
            this._pathLabel.TabIndex = 1;
            this._pathLabel.Text = "Enter the path to the initialization script (init.lua) for the Kill Counter addon" +
    ":";
            // 
            // _mainPanel
            // 
            this._mainPanel.Controls.Add(this._buttonPanel);
            this._mainPanel.Controls.Add(this._pathPanel);
            this._mainPanel.Controls.Add(this._pathLabel);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 0);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this._mainPanel.Size = new System.Drawing.Size(553, 89);
            this._mainPanel.TabIndex = 2;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.AutoSize = true;
            this._buttonPanel.Controls.Add(this._okButton);
            this._buttonPanel.Controls.Add(this._cancelButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._buttonPanel.Location = new System.Drawing.Point(10, 45);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(533, 36);
            this._buttonPanel.TabIndex = 6;
            // 
            // _okButton
            // 
            this._okButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(178, 10);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 3;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(259, 10);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _pathPanel
            // 
            this._pathPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._pathPanel.Controls.Add(this._pathTextBox);
            this._pathPanel.Controls.Add(this._browseButton);
            this._pathPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._pathPanel.Location = new System.Drawing.Point(10, 23);
            this._pathPanel.Name = "_pathPanel";
            this._pathPanel.Size = new System.Drawing.Size(533, 22);
            this._pathPanel.TabIndex = 4;
            // 
            // _browseButton
            // 
            this._browseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._browseButton.Location = new System.Drawing.Point(458, 0);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(75, 22);
            this._browseButton.TabIndex = 2;
            this._browseButton.Text = "Browse...";
            this._browseButton.UseVisualStyleBackColor = true;
            this._browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // _initializationScriptPathDialog
            // 
            this._initializationScriptPathDialog.Filter = "Initialization Script|init.lua";
            // 
            // PathPrompt
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(553, 89);
            this.Controls.Add(this._mainPanel);
            this.Name = "PathPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Where is PSO?";
            this.Load += new System.EventHandler(this.PathPrompt_Load);
            this._mainPanel.ResumeLayout(false);
            this._mainPanel.PerformLayout();
            this._buttonPanel.ResumeLayout(false);
            this._pathPanel.ResumeLayout(false);
            this._pathPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _pathTextBox;
        private System.Windows.Forms.Label _pathLabel;
        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Panel _pathPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.OpenFileDialog _initializationScriptPathDialog;
        private System.Windows.Forms.Panel _buttonPanel;
    }
}