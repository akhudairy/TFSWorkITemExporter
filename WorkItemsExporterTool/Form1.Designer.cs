namespace Sedco.Products.TFSHelpers.WorkItemsExporterTool
{
    partial class Form1
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
            this.itemIdTextBox = new System.Windows.Forms.TextBox();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.tfsUrlTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.queryComboBox = new System.Windows.Forms.ComboBox();
            this.foldersComboBox = new System.Windows.Forms.ComboBox();
            this.projectsComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.savedQueryRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.Enabled = false;
            this.itemIdTextBox.Location = new System.Drawing.Point(17, 39);
            this.itemIdTextBox.MaxLength = 10;
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.Size = new System.Drawing.Size(540, 20);
            this.itemIdTextBox.TabIndex = 6;
            // 
            // queryTextBox
            // 
            this.queryTextBox.Enabled = false;
            this.queryTextBox.Location = new System.Drawing.Point(17, 93);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(540, 70);
            this.queryTextBox.TabIndex = 8;
            this.queryTextBox.Text = "SELECT [System.Id], [System.WorkItemType],[System.State], [System.AssignedTo], [S" +
    "ystem.Title] \r\nFROM WorkItems ORDER BY [System.WorkItemType], [System.Id]";
            // 
            // tfsUrlTextBox
            // 
            this.tfsUrlTextBox.Location = new System.Drawing.Point(33, 27);
            this.tfsUrlTextBox.Name = "tfsUrlTextBox";
            this.tfsUrlTextBox.Size = new System.Drawing.Size(540, 20);
            this.tfsUrlTextBox.TabIndex = 1;
            this.tfsUrlTextBox.Text = "http://tfsserver:8080/tfs/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Team Foundation URL";
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(204, 561);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(203, 37);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(17, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Work Item ID";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(17, 70);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "OR, enter query";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.queryComboBox);
            this.mainPanel.Controls.Add(this.foldersComboBox);
            this.mainPanel.Controls.Add(this.projectsComboBox);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.savedQueryRadioButton);
            this.mainPanel.Controls.Add(this.itemIdTextBox);
            this.mainPanel.Controls.Add(this.radioButton2);
            this.mainPanel.Controls.Add(this.queryTextBox);
            this.mainPanel.Controls.Add(this.radioButton1);
            this.mainPanel.Location = new System.Drawing.Point(12, 214);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(574, 330);
            this.mainPanel.TabIndex = 100;
            // 
            // queryComboBox
            // 
            this.queryComboBox.Enabled = false;
            this.queryComboBox.FormattingEnabled = true;
            this.queryComboBox.Location = new System.Drawing.Point(95, 295);
            this.queryComboBox.Name = "queryComboBox";
            this.queryComboBox.Size = new System.Drawing.Size(230, 21);
            this.queryComboBox.TabIndex = 102;
            // 
            // foldersComboBox
            // 
            this.foldersComboBox.Enabled = false;
            this.foldersComboBox.FormattingEnabled = true;
            this.foldersComboBox.Location = new System.Drawing.Point(95, 256);
            this.foldersComboBox.Name = "foldersComboBox";
            this.foldersComboBox.Size = new System.Drawing.Size(230, 21);
            this.foldersComboBox.TabIndex = 101;
            this.foldersComboBox.SelectedIndexChanged += new System.EventHandler(this.foldersComboBox_SelectedIndexChanged);
            // 
            // projectsComboBox
            // 
            this.projectsComboBox.Enabled = false;
            this.projectsComboBox.FormattingEnabled = true;
            this.projectsComboBox.Location = new System.Drawing.Point(95, 216);
            this.projectsComboBox.Name = "projectsComboBox";
            this.projectsComboBox.Size = new System.Drawing.Size(230, 21);
            this.projectsComboBox.TabIndex = 10;
            this.projectsComboBox.SelectedIndexChanged += new System.EventHandler(this.projectsComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "Query";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Project";
            // 
            // savedQueryRadioButton
            // 
            this.savedQueryRadioButton.AutoSize = true;
            this.savedQueryRadioButton.Enabled = false;
            this.savedQueryRadioButton.Location = new System.Drawing.Point(17, 179);
            this.savedQueryRadioButton.Name = "savedQueryRadioButton";
            this.savedQueryRadioButton.Size = new System.Drawing.Size(107, 17);
            this.savedQueryRadioButton.TabIndex = 9;
            this.savedQueryRadioButton.TabStop = true;
            this.savedQueryRadioButton.Text = "OR, saved query";
            this.savedQueryRadioButton.UseVisualStyleBackColor = true;
            this.savedQueryRadioButton.CheckedChanged += new System.EventHandler(this.savedQueryRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.userTextBox);
            this.panel1.Controls.Add(this.domainTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 132);
            this.panel1.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "Domain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Domain information (required to download attachments)";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(394, 94);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(167, 20);
            this.passwordTextBox.TabIndex = 4;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(95, 94);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(167, 20);
            this.userTextBox.TabIndex = 3;
            // 
            // domainTextBox
            // 
            this.domainTextBox.Location = new System.Drawing.Point(95, 46);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(466, 20);
            this.domainTextBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "User";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tfsUrlTextBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Export Work Items Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.TextBox tfsUrlTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.ComboBox queryComboBox;
        private System.Windows.Forms.ComboBox foldersComboBox;
        private System.Windows.Forms.ComboBox projectsComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton savedQueryRadioButton;
        private System.Windows.Forms.Label label8;

    }
}

