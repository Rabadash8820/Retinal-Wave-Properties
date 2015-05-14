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
            System.Windows.Forms.TableLayoutPanel MainTableLayout;
            System.Windows.Forms.Label FullNameLabel;
            System.Windows.Forms.Label EmailLabel;
            System.Windows.Forms.Label CommentsLabel;
            System.Windows.Forms.Panel BottomPanel;
            System.Windows.Forms.Label PhoneLabel;
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.CommentsTextbox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelCreateButton = new System.Windows.Forms.Button();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.PhoneTextbox = new System.Windows.Forms.TextBox();
            MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            FullNameLabel = new System.Windows.Forms.Label();
            EmailLabel = new System.Windows.Forms.Label();
            CommentsLabel = new System.Windows.Forms.Label();
            BottomPanel = new System.Windows.Forms.Panel();
            PhoneLabel = new System.Windows.Forms.Label();
            MainTableLayout.SuspendLayout();
            BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            MainTableLayout.ColumnCount = 2;
            MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            MainTableLayout.Controls.Add(FullNameLabel, 0, 0);
            MainTableLayout.Controls.Add(EmailLabel, 0, 1);
            MainTableLayout.Controls.Add(CommentsLabel, 0, 3);
            MainTableLayout.Controls.Add(this.TitleTextbox, 1, 0);
            MainTableLayout.Controls.Add(this.CommentsTextbox, 1, 3);
            MainTableLayout.Controls.Add(BottomPanel, 0, 4);
            MainTableLayout.Controls.Add(PhoneLabel, 0, 2);
            MainTableLayout.Controls.Add(this.EmailTextbox, 1, 1);
            MainTableLayout.Controls.Add(this.PhoneTextbox, 1, 2);
            MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            MainTableLayout.Location = new System.Drawing.Point(0, 0);
            MainTableLayout.Name = "MainTableLayout";
            MainTableLayout.RowCount = 5;
            MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            MainTableLayout.Size = new System.Drawing.Size(399, 211);
            MainTableLayout.TabIndex = 14;
            // 
            // FullNameLabel
            // 
            FullNameLabel.AutoSize = true;
            FullNameLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            FullNameLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            FullNameLabel.Location = new System.Drawing.Point(3, 3);
            FullNameLabel.Margin = new System.Windows.Forms.Padding(3);
            FullNameLabel.Name = "FullNameLabel";
            FullNameLabel.Size = new System.Drawing.Size(70, 19);
            FullNameLabel.TabIndex = 0;
            FullNameLabel.Text = "Full Name";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            EmailLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            EmailLabel.Location = new System.Drawing.Point(3, 34);
            EmailLabel.Margin = new System.Windows.Forms.Padding(3);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new System.Drawing.Size(78, 19);
            EmailLabel.TabIndex = 2;
            EmailLabel.Text = "Work Email";
            // 
            // CommentsLabel
            // 
            CommentsLabel.AutoSize = true;
            CommentsLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            CommentsLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            CommentsLabel.Location = new System.Drawing.Point(3, 96);
            CommentsLabel.Margin = new System.Windows.Forms.Padding(3);
            CommentsLabel.Name = "CommentsLabel";
            CommentsLabel.Size = new System.Drawing.Size(76, 19);
            CommentsLabel.TabIndex = 4;
            CommentsLabel.Text = "Comments";
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
            this.TitleTextbox.MaxLength = 50;
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
            this.CommentsTextbox.Size = new System.Drawing.Size(302, 71);
            this.CommentsTextbox.TabIndex = 4;
            // 
            // BottomPanel
            // 
            MainTableLayout.SetColumnSpan(BottomPanel, 2);
            BottomPanel.Controls.Add(this.CreateButton);
            BottomPanel.Controls.Add(this.CancelCreateButton);
            BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            BottomPanel.Location = new System.Drawing.Point(3, 173);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = global::MEACruncher.Properties.Settings.Default.containerHeight;
            BottomPanel.TabIndex = 14;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.AutoSize = true;
            this.CreateButton.BackColor = global::MEACruncher.Properties.Settings.Default.buttonColor;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            this.CreateButton.ForeColor = global::MEACruncher.Properties.Settings.Default.buttonText;
            this.CreateButton.Location = new System.Drawing.Point(258, 3);
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
            this.CancelCreateButton.Location = new System.Drawing.Point(329, 3);
            this.CancelCreateButton.Name = "CancelCreateButton";
            this.CancelCreateButton.Size = new System.Drawing.Size(75, 31);
            this.CancelCreateButton.TabIndex = 1;
            this.CancelCreateButton.Text = "Cancel";
            this.CancelCreateButton.UseVisualStyleBackColor = false;
            this.CancelCreateButton.Click += new System.EventHandler(this.CancelCreateButton_Click);
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.Font = global::MEACruncher.Properties.Settings.Default.controlFont;
            PhoneLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.labelText;
            PhoneLabel.Location = new System.Drawing.Point(3, 65);
            PhoneLabel.Margin = new System.Windows.Forms.Padding(3);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new System.Drawing.Size(85, 19);
            PhoneLabel.TabIndex = 2;
            PhoneLabel.Text = "Work Phone";
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
            this.Controls.Add(MainTableLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(415, 250);
            this.Name = "NewExperimenterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Experimenter";
            MainTableLayout.ResumeLayout(false);
            MainTableLayout.PerformLayout();
            BottomPanel.ResumeLayout(false);
            BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.TextBox CommentsTextbox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelCreateButton;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox PhoneTextbox;
    }
}