namespace MEACruncher.Forms {
    partial class EditProjectForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProjectForm));
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RedoButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.BasicInfoPage = new System.Windows.Forms.TabPage();
            this.BasicInfoTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CommentsTextbox = new System.Windows.Forms.TextBox();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.DateStartedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DateStartedLabel = new System.Windows.Forms.Label();
            this.CommentsLabel = new System.Windows.Forms.Label();
            this.PopulationsPage = new System.Windows.Forms.TabPage();
            this.RecordingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.RecordingsDGV = new System.Windows.Forms.DataGridView();
            this.AddRecordingButton = new System.Windows.Forms.Button();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.BasicInfoPage.SuspendLayout();
            this.BasicInfoTableLayout.SuspendLayout();
            this.PopulationsPage.SuspendLayout();
            this.RecordingsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 1;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayout.Controls.Add(this.MainTabControl, 0, 0);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 2;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayout.Size = new System.Drawing.Size(800, 379);
            this.MainTableLayout.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.RedoButton);
            this.BottomPanel.Controls.Add(this.UndoButton);
            this.BottomPanel.Controls.Add(this.CancelEditButton);
            this.BottomPanel.Controls.Add(this.UpdateButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 347);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(794, 29);
            this.BottomPanel.TabIndex = 0;
            // 
            // RedoButton
            // 
            this.RedoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RedoButton.BackgroundImage")));
            this.RedoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RedoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedoButton.ForeColor = System.Drawing.Color.Black;
            this.RedoButton.Location = new System.Drawing.Point(34, 2);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(25, 25);
            this.RedoButton.TabIndex = 1;
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.EnabledChanged += new System.EventHandler(this.RedoButton_EnabledChanged);
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UndoButton.BackgroundImage")));
            this.UndoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UndoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UndoButton.ForeColor = System.Drawing.Color.Black;
            this.UndoButton.Location = new System.Drawing.Point(3, 2);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(25, 25);
            this.UndoButton.TabIndex = 0;
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.EnabledChanged += new System.EventHandler(this.UndoButton_EnabledChanged);
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelEditButton.AutoSize = true;
            this.CancelEditButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelEditButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CancelEditButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.CancelEditButton.Location = new System.Drawing.Point(709, -1);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(75, 31);
            this.CancelEditButton.TabIndex = 3;
            this.CancelEditButton.Text = "Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = false;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.AutoSize = true;
            this.UpdateButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.UpdateButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.UpdateButton.Location = new System.Drawing.Point(628, -1);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 31);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.BackColor = global::MEACruncher.Properties.Settings.Default.TabPageBackColor;
            this.MainTabControl.Controls.Add(this.BasicInfoPage);
            this.MainTabControl.Controls.Add(this.PopulationsPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.MainTabControl.ForeColor = global::MEACruncher.Properties.Settings.Default.TabPageForeColor;
            this.MainTabControl.Location = new System.Drawing.Point(3, 3);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(794, 338);
            this.MainTabControl.TabIndex = 1;
            // 
            // BasicInfoPage
            // 
            this.BasicInfoPage.BackColor = global::MEACruncher.Properties.Settings.Default.TabPageBackColor;
            this.BasicInfoPage.Controls.Add(this.BasicInfoTableLayout);
            this.BasicInfoPage.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.BasicInfoPage.ForeColor = global::MEACruncher.Properties.Settings.Default.TabPageForeColor;
            this.BasicInfoPage.Location = new System.Drawing.Point(4, 26);
            this.BasicInfoPage.Name = "BasicInfoPage";
            this.BasicInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.BasicInfoPage.Size = new System.Drawing.Size(786, 308);
            this.BasicInfoPage.TabIndex = 0;
            this.BasicInfoPage.Text = "Basic Info";
            // 
            // BasicInfoTableLayout
            // 
            this.BasicInfoTableLayout.ColumnCount = 2;
            this.BasicInfoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BasicInfoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicInfoTableLayout.Controls.Add(this.TitleLabel, 0, 0);
            this.BasicInfoTableLayout.Controls.Add(this.CommentsTextbox, 1, 2);
            this.BasicInfoTableLayout.Controls.Add(this.TitleTextbox, 1, 0);
            this.BasicInfoTableLayout.Controls.Add(this.DateStartedDateTimePicker, 1, 1);
            this.BasicInfoTableLayout.Controls.Add(this.DateStartedLabel, 0, 1);
            this.BasicInfoTableLayout.Controls.Add(this.CommentsLabel, 0, 2);
            this.BasicInfoTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicInfoTableLayout.Location = new System.Drawing.Point(3, 3);
            this.BasicInfoTableLayout.Name = "BasicInfoTableLayout";
            this.BasicInfoTableLayout.RowCount = 3;
            this.BasicInfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.BasicInfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.BasicInfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicInfoTableLayout.Size = new System.Drawing.Size(780, 302);
            this.BasicInfoTableLayout.TabIndex = 6;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.TitleLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.LabelForeColor;
            this.TitleLabel.Location = new System.Drawing.Point(3, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(34, 19);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            // 
            // CommentsTextbox
            // 
            this.CommentsTextbox.BackColor = global::MEACruncher.Properties.Settings.Default.TextboxBackColor;
            this.CommentsTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsTextbox.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CommentsTextbox.ForeColor = global::MEACruncher.Properties.Settings.Default.TextboxForeColor;
            this.CommentsTextbox.Location = new System.Drawing.Point(95, 65);
            this.CommentsTextbox.Multiline = true;
            this.CommentsTextbox.Name = "CommentsTextbox";
            this.CommentsTextbox.Size = new System.Drawing.Size(682, 234);
            this.CommentsTextbox.TabIndex = 2;
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.BackColor = global::MEACruncher.Properties.Settings.Default.TextboxBackColor;
            this.TitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTextbox.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.TitleTextbox.ForeColor = global::MEACruncher.Properties.Settings.Default.TextboxForeColor;
            this.TitleTextbox.Location = new System.Drawing.Point(95, 3);
            this.TitleTextbox.MaxLength = 25;
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(682, 25);
            this.TitleTextbox.TabIndex = 0;
            // 
            // DateStartedDateTimePicker
            // 
            this.DateStartedDateTimePicker.BackColor = global::MEACruncher.Properties.Settings.Default.TextboxBackColor;
            this.DateStartedDateTimePicker.CalendarFont = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.DateStartedDateTimePicker.CalendarForeColor = global::MEACruncher.Properties.Settings.Default.TextboxForeColor;
            this.DateStartedDateTimePicker.CalendarMonthBackground = global::MEACruncher.Properties.Settings.Default.TextboxBackColor;
            this.DateStartedDateTimePicker.CalendarTitleBackColor = global::MEACruncher.Properties.Settings.Default.TextboxBackColor;
            this.DateStartedDateTimePicker.CalendarTitleForeColor = global::MEACruncher.Properties.Settings.Default.TextboxForeColor;
            this.DateStartedDateTimePicker.CalendarTrailingForeColor = global::MEACruncher.Properties.Settings.Default.TextboxForeColor;
            this.DateStartedDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateStartedDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DateStartedDateTimePicker.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.DateStartedDateTimePicker.ForeColor = global::MEACruncher.Properties.Settings.Default.TextboxForeColor;
            this.DateStartedDateTimePicker.Location = new System.Drawing.Point(95, 34);
            this.DateStartedDateTimePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.DateStartedDateTimePicker.Name = "DateStartedDateTimePicker";
            this.DateStartedDateTimePicker.Size = new System.Drawing.Size(682, 25);
            this.DateStartedDateTimePicker.TabIndex = 1;
            // 
            // DateStartedLabel
            // 
            this.DateStartedLabel.AutoSize = true;
            this.DateStartedLabel.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.DateStartedLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.LabelForeColor;
            this.DateStartedLabel.Location = new System.Drawing.Point(3, 31);
            this.DateStartedLabel.Name = "DateStartedLabel";
            this.DateStartedLabel.Size = new System.Drawing.Size(86, 19);
            this.DateStartedLabel.TabIndex = 1;
            this.DateStartedLabel.Text = "Date Started";
            // 
            // CommentsLabel
            // 
            this.CommentsLabel.AutoSize = true;
            this.CommentsLabel.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CommentsLabel.ForeColor = global::MEACruncher.Properties.Settings.Default.LabelForeColor;
            this.CommentsLabel.Location = new System.Drawing.Point(3, 62);
            this.CommentsLabel.Name = "CommentsLabel";
            this.CommentsLabel.Size = new System.Drawing.Size(76, 19);
            this.CommentsLabel.TabIndex = 1;
            this.CommentsLabel.Text = "Comments";
            // 
            // PopulationsPage
            // 
            this.PopulationsPage.BackColor = global::MEACruncher.Properties.Settings.Default.TabPageBackColor;
            this.PopulationsPage.Controls.Add(this.RecordingsTableLayout);
            this.PopulationsPage.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.PopulationsPage.ForeColor = global::MEACruncher.Properties.Settings.Default.TabPageForeColor;
            this.PopulationsPage.Location = new System.Drawing.Point(4, 26);
            this.PopulationsPage.Name = "PopulationsPage";
            this.PopulationsPage.Padding = new System.Windows.Forms.Padding(3);
            this.PopulationsPage.Size = new System.Drawing.Size(786, 308);
            this.PopulationsPage.TabIndex = 2;
            this.PopulationsPage.Text = "Recordings";
            // 
            // RecordingsTableLayout
            // 
            this.RecordingsTableLayout.ColumnCount = 1;
            this.RecordingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RecordingsTableLayout.Controls.Add(this.RecordingsDGV, 0, 0);
            this.RecordingsTableLayout.Controls.Add(this.AddRecordingButton, 0, 1);
            this.RecordingsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingsTableLayout.Location = new System.Drawing.Point(3, 3);
            this.RecordingsTableLayout.Name = "RecordingsTableLayout";
            this.RecordingsTableLayout.RowCount = 2;
            this.RecordingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RecordingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.RecordingsTableLayout.Size = new System.Drawing.Size(780, 302);
            this.RecordingsTableLayout.TabIndex = 0;
            // 
            // RecordingsDGV
            // 
            this.RecordingsDGV.BackgroundColor = global::MEACruncher.Properties.Settings.Default.DgvBackColor;
            this.RecordingsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordingsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordingsDGV.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.RecordingsDGV.GridColor = global::MEACruncher.Properties.Settings.Default.DgvGridColor;
            this.RecordingsDGV.Location = new System.Drawing.Point(3, 3);
            this.RecordingsDGV.Name = "RecordingsDGV";
            this.RecordingsDGV.Size = new System.Drawing.Size(774, 261);
            this.RecordingsDGV.TabIndex = 0;
            // 
            // AddRecordingButton
            // 
            this.AddRecordingButton.AutoSize = true;
            this.AddRecordingButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.AddRecordingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRecordingButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.AddRecordingButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.AddRecordingButton.Location = new System.Drawing.Point(3, 270);
            this.AddRecordingButton.Name = "AddRecordingButton";
            this.AddRecordingButton.Size = new System.Drawing.Size(75, 29);
            this.AddRecordingButton.TabIndex = 1;
            this.AddRecordingButton.Text = "Add...";
            this.AddRecordingButton.UseVisualStyleBackColor = false;
            // 
            // EditProjectForm
            // 
            this.AcceptButton = this.UpdateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.CancelButton = this.CancelEditButton;
            this.ClientSize = new System.Drawing.Size(800, 379);
            this.Controls.Add(this.MainTableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "EditProjectForm";
            this.Text = "Edit Project";
            this.MainTableLayout.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.BasicInfoPage.ResumeLayout(false);
            this.BasicInfoTableLayout.ResumeLayout(false);
            this.BasicInfoTableLayout.PerformLayout();
            this.PopulationsPage.ResumeLayout(false);
            this.RecordingsTableLayout.ResumeLayout(false);
            this.RecordingsTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordingsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage BasicInfoPage;
        private System.Windows.Forms.TabPage PopulationsPage;
        private System.Windows.Forms.TableLayoutPanel BasicInfoTableLayout;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox CommentsTextbox;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.DateTimePicker DateStartedDateTimePicker;
        private System.Windows.Forms.Label DateStartedLabel;
        private System.Windows.Forms.Label CommentsLabel;
        private System.Windows.Forms.TableLayoutPanel RecordingsTableLayout;
        private System.Windows.Forms.Button AddRecordingButton;
        private System.Windows.Forms.DataGridView RecordingsDGV;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button UndoButton;
    }
}