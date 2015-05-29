namespace MEACruncher.Forms.NewForms {
    partial class NewProjectForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DateStartedLabel = new System.Windows.Forms.Label();
            this.CommentsLabel = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.DateStartedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CommentsTextbox = new System.Windows.Forms.TextBox();
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RedoButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.CancelCreateButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.TitleTextbox.Size = new System.Drawing.Size(261, 25);
            this.TitleTextbox.TabIndex = 0;
            this.TitleTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.TitleTextbox_Validating);
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
            this.DateStartedDateTimePicker.Size = new System.Drawing.Size(261, 25);
            this.DateStartedDateTimePicker.TabIndex = 1;
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
            this.CommentsTextbox.Size = new System.Drawing.Size(261, 108);
            this.CommentsTextbox.TabIndex = 2;
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 2;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.TitleLabel, 0, 0);
            this.MainTableLayout.Controls.Add(this.CommentsTextbox, 1, 2);
            this.MainTableLayout.Controls.Add(this.TitleTextbox, 1, 0);
            this.MainTableLayout.Controls.Add(this.DateStartedDateTimePicker, 1, 1);
            this.MainTableLayout.Controls.Add(this.DateStartedLabel, 0, 1);
            this.MainTableLayout.Controls.Add(this.CommentsLabel, 0, 2);
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 3);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 4;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayout.Size = new System.Drawing.Size(359, 211);
            this.MainTableLayout.TabIndex = 5;
            // 
            // BottomPanel
            // 
            this.MainTableLayout.SetColumnSpan(this.BottomPanel, 2);
            this.BottomPanel.Controls.Add(this.RedoButton);
            this.BottomPanel.Controls.Add(this.UndoButton);
            this.BottomPanel.Controls.Add(this.CancelCreateButton);
            this.BottomPanel.Controls.Add(this.CreateButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 179);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(353, 29);
            this.BottomPanel.TabIndex = 5;
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
            // CancelCreateButton
            // 
            this.CancelCreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCreateButton.AutoSize = true;
            this.CancelCreateButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.CancelCreateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelCreateButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CancelCreateButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.CancelCreateButton.Location = new System.Drawing.Point(269, -1);
            this.CancelCreateButton.Name = "CancelCreateButton";
            this.CancelCreateButton.Size = new System.Drawing.Size(75, 31);
            this.CancelCreateButton.TabIndex = 3;
            this.CancelCreateButton.Text = "Cancel";
            this.CancelCreateButton.UseVisualStyleBackColor = false;
            this.CancelCreateButton.Click += new System.EventHandler(this.CancelCreateButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.AutoSize = true;
            this.CreateButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CreateButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.CreateButton.Location = new System.Drawing.Point(188, -1);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 31);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.CreateButton;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.CancelButton = this.CancelCreateButton;
            this.ClientSize = new System.Drawing.Size(359, 211);
            this.Controls.Add(this.MainTableLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 250);
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Project";
            this.MainTableLayout.ResumeLayout(false);
            this.MainTableLayout.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DateStartedLabel;
        private System.Windows.Forms.Label CommentsLabel;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.DateTimePicker DateStartedDateTimePicker;
        private System.Windows.Forms.TextBox CommentsTextbox;
        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CancelCreateButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button UndoButton;


    }
}
