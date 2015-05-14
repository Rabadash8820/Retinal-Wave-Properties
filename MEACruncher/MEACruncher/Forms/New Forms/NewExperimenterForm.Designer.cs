namespace MEACruncher.Forms {
    partial class NewExperimenterForm {
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
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelCreateButton = new System.Windows.Forms.Button();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.CommentsLabel = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.CommentsTextbox = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.PhoneTextbox = new System.Windows.Forms.TextBox();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 2;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.FullNameLabel, 0, 0);
            this.MainTableLayout.Controls.Add(this.EmailLabel, 0, 1);
            this.MainTableLayout.Controls.Add(this.CommentsLabel, 0, 3);
            this.MainTableLayout.Controls.Add(this.TitleTextbox, 1, 0);
            this.MainTableLayout.Controls.Add(this.CommentsTextbox, 1, 3);
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 4);
            this.MainTableLayout.Controls.Add(this.PhoneLabel, 0, 2);
            this.MainTableLayout.Controls.Add(this.EmailTextbox, 1, 1);
            this.MainTableLayout.Controls.Add(this.PhoneTextbox, 1, 2);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 5;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayout.Size = new System.Drawing.Size(399, 211);
            this.MainTableLayout.TabIndex = 14;
            // 
            // BottomPanel
            // 
            this.MainTableLayout.SetColumnSpan(this.BottomPanel, 2);
            this.BottomPanel.Controls.Add(this.CreateButton);
            this.BottomPanel.Controls.Add(this.CancelCreateButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 179);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(393, 29);
            this.BottomPanel.TabIndex = 14;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.AutoSize = true;
            this.CreateButton.BackColor = global::MEACruncher.Properties.Settings.Default.buttonColor;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.CreateButton.ForeColor = global::MEACruncher.Properties.Settings.Default.buttonText;
            this.CreateButton.Location = new System.Drawing.Point(238, -1);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(65, 31);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelCreateButton
            // 
            this.CancelCreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCreateButton.AutoSize = true;
            this.CancelCreateButton.BackColor = global::MEACruncher.Properties.Settings.Default.buttonColor;
            this.CancelCreateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelCreateButton.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.CancelCreateButton.ForeColor = global::MEACruncher.Properties.Settings.Default.buttonText;
            this.CancelCreateButton.Location = new System.Drawing.Point(309, -1);
            this.CancelCreateButton.Name = "CancelCreateButton";
            this.CancelCreateButton.Size = new System.Drawing.Size(75, 31);
            this.CancelCreateButton.TabIndex = 1;
            this.CancelCreateButton.Text = "Cancel";
            this.CancelCreateButton.UseVisualStyleBackColor = false;
            this.CancelCreateButton.Click += new System.EventHandler(this.CancelCreateButton_Click);
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.FullNameLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            this.FullNameLabel.Location = new System.Drawing.Point(3, 3);
            this.FullNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(70, 19);
            this.FullNameLabel.TabIndex = 0;
            this.FullNameLabel.Text = "Full Name";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.EmailLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            this.EmailLabel.Location = new System.Drawing.Point(3, 34);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(3);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(78, 19);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Work Email";
            // 
            // CommentsLabel
            // 
            this.CommentsLabel.AutoSize = true;
            this.CommentsLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.CommentsLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            this.CommentsLabel.Location = new System.Drawing.Point(3, 96);
            this.CommentsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CommentsLabel.Name = "CommentsLabel";
            this.CommentsLabel.Size = new System.Drawing.Size(76, 19);
            this.CommentsLabel.TabIndex = 4;
            this.CommentsLabel.Text = "Comments";
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.BackColor = global::MEACruncher.Properties.Settings.Default.textboxBackground;
            this.TitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::MEACruncher.Properties.Settings.Default, "controlHeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TitleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TitleTextbox.ForeColor = global::MEACruncher.Properties.Settings.Default.textboxText;
            this.TitleTextbox.Location = new System.Drawing.Point(94, 3);
            this.TitleTextbox.MaxLength = 30;
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = global::MEACruncher.Properties.Settings.Default.controlHeight;
            this.TitleTextbox.TabIndex = 1;
            // 
            // CommentsTextbox
            // 
            this.CommentsTextbox.BackColor = global::MEACruncher.Properties.Settings.Default.textboxBackground;
            this.CommentsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CommentsTextbox.ForeColor = global::MEACruncher.Properties.Settings.Default.textboxText;
            this.CommentsTextbox.Location = new System.Drawing.Point(94, 96);
            this.CommentsTextbox.Multiline = true;
            this.CommentsTextbox.Name = "CommentsTextbox";
            this.CommentsTextbox.Size = new System.Drawing.Size(302, 77);
            this.CommentsTextbox.TabIndex = 4;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.PhoneLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            this.PhoneLabel.Location = new System.Drawing.Point(3, 65);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(3);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(85, 19);
            this.PhoneLabel.TabIndex = 2;
            this.PhoneLabel.Text = "Work Phone";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = global::MEACruncher.Properties.Settings.Default.textboxBackground;
            this.EmailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::MEACruncher.Properties.Settings.Default, "controlHeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EmailTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmailTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.EmailTextbox.ForeColor = global::MEACruncher.Properties.Settings.Default.textboxText;
            this.EmailTextbox.Location = new System.Drawing.Point(94, 34);
            this.EmailTextbox.MaxLength = 25;
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = global::MEACruncher.Properties.Settings.Default.controlHeight;
            this.EmailTextbox.TabIndex = 2;
            // 
            // PhoneTextbox
            // 
            this.PhoneTextbox.BackColor = global::MEACruncher.Properties.Settings.Default.textboxBackground;
            this.PhoneTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhoneTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::MEACruncher.Properties.Settings.Default, "controlHeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PhoneTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhoneTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PhoneTextbox.ForeColor = global::MEACruncher.Properties.Settings.Default.textboxText;
            this.PhoneTextbox.Location = new System.Drawing.Point(94, 65);
            this.PhoneTextbox.MaxLength = 15;
            this.PhoneTextbox.Name = "PhoneTextbox";
            this.PhoneTextbox.Size = global::MEACruncher.Properties.Settings.Default.controlHeight;
            this.PhoneTextbox.TabIndex = 3;
            // 
            // NewExperimenterForm
            // 
            this.AcceptButton = this.CreateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.CancelCreateButton;
            this.ClientSize = new System.Drawing.Size(399, 211);
            this.Controls.Add(this.MainTableLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 250);
            this.Name = "NewExperimenterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Experimenter";
            this.MainTableLayout.ResumeLayout(false);
            this.MainTableLayout.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.TextBox CommentsTextbox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelCreateButton;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox PhoneTextbox;
        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label CommentsLabel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label PhoneLabel;
    }
}