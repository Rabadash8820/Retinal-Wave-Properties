namespace MEACruncher {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.DateStartedLabel = new System.Windows.Forms.Label();
            this.DateStartedMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.CommentsLabel = new System.Windows.Forms.Label();
            this.CommentsTextbox = new System.Windows.Forms.TextBox();
            this.ExperimentersLabel = new System.Windows.Forms.Label();
            this.ExperimentersListbox = new System.Windows.Forms.ListBox();
            this.ChooseExperimenterLabel = new System.Windows.Forms.Label();
            this.ChooseExperimenterCombobox = new System.Windows.Forms.ComboBox();
            this.NewExperimenterButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelCreateButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ExperimentersListbox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.ExperimentersLabel, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.ChooseExperimenterCombobox, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.ChooseExperimenterLabel, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.NewExperimenterButton, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.DateStartedMonthCalendar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.DateStartedLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TitleTextbox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TitleLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CommentsLabel, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.CommentsTextbox, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.CreateButton, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.CancelCreateButton, 5, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 494);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(3, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title";
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTextbox.Location = new System.Drawing.Point(3, 16);
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(239, 20);
            this.TitleTextbox.TabIndex = 1;
            this.TitleTextbox.Text = "Project1";
            // 
            // DateStartedLabel
            // 
            this.DateStartedLabel.AutoSize = true;
            this.DateStartedLabel.Location = new System.Drawing.Point(3, 39);
            this.DateStartedLabel.Name = "DateStartedLabel";
            this.DateStartedLabel.Size = new System.Drawing.Size(65, 13);
            this.DateStartedLabel.TabIndex = 2;
            this.DateStartedLabel.Text = "Date started";
            // 
            // DateStartedMonthCalendar
            // 
            this.DateStartedMonthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateStartedMonthCalendar.Location = new System.Drawing.Point(9, 61);
            this.DateStartedMonthCalendar.Name = "DateStartedMonthCalendar";
            this.DateStartedMonthCalendar.TabIndex = 3;
            // 
            // CommentsLabel
            // 
            this.CommentsLabel.AutoSize = true;
            this.CommentsLabel.Location = new System.Drawing.Point(3, 346);
            this.CommentsLabel.Name = "CommentsLabel";
            this.CommentsLabel.Size = new System.Drawing.Size(56, 13);
            this.CommentsLabel.TabIndex = 4;
            this.CommentsLabel.Text = "Comments";
            // 
            // CommentsTextbox
            // 
            this.CommentsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsTextbox.Location = new System.Drawing.Point(3, 362);
            this.CommentsTextbox.Multiline = true;
            this.CommentsTextbox.Name = "CommentsTextbox";
            this.CommentsTextbox.Size = new System.Drawing.Size(239, 129);
            this.CommentsTextbox.TabIndex = 5;
            // 
            // ExperimentersLabel
            // 
            this.ExperimentersLabel.AutoSize = true;
            this.ExperimentersLabel.Location = new System.Drawing.Point(3, 232);
            this.ExperimentersLabel.Name = "ExperimentersLabel";
            this.ExperimentersLabel.Size = new System.Drawing.Size(95, 13);
            this.ExperimentersLabel.TabIndex = 6;
            this.ExperimentersLabel.Text = "Add Experimenters";
            // 
            // ExperimentersListbox
            // 
            this.ExperimentersListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExperimentersListbox.FormattingEnabled = true;
            this.ExperimentersListbox.Location = new System.Drawing.Point(3, 248);
            this.ExperimentersListbox.Name = "ExperimentersListbox";
            this.ExperimentersListbox.Size = new System.Drawing.Size(239, 95);
            this.ExperimentersListbox.TabIndex = 7;
            // 
            // ChooseExperimenterLabel
            // 
            this.ChooseExperimenterLabel.AutoSize = true;
            this.ChooseExperimenterLabel.Location = new System.Drawing.Point(248, 232);
            this.ChooseExperimenterLabel.Name = "ChooseExperimenterLabel";
            this.ChooseExperimenterLabel.Size = new System.Drawing.Size(112, 13);
            this.ChooseExperimenterLabel.TabIndex = 9;
            this.ChooseExperimenterLabel.Text = "Choose Experimenters";
            // 
            // ChooseExperimenterCombobox
            // 
            this.ChooseExperimenterCombobox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChooseExperimenterCombobox.FormattingEnabled = true;
            this.ChooseExperimenterCombobox.Location = new System.Drawing.Point(248, 248);
            this.ChooseExperimenterCombobox.Name = "ChooseExperimenterCombobox";
            this.ChooseExperimenterCombobox.Size = new System.Drawing.Size(121, 21);
            this.ChooseExperimenterCombobox.TabIndex = 8;
            // 
            // NewExperimenterButton
            // 
            this.NewExperimenterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewExperimenterButton.Location = new System.Drawing.Point(375, 248);
            this.NewExperimenterButton.Name = "NewExperimenterButton";
            this.NewExperimenterButton.Size = new System.Drawing.Size(75, 23);
            this.NewExperimenterButton.TabIndex = 10;
            this.NewExperimenterButton.Text = "Create New";
            this.NewExperimenterButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CreateButton.Location = new System.Drawing.Point(375, 468);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 11;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            // 
            // CancelCreateButton
            // 
            this.CancelCreateButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CancelCreateButton.Location = new System.Drawing.Point(456, 468);
            this.CancelCreateButton.Name = "CancelCreateButton";
            this.CancelCreateButton.Size = new System.Drawing.Size(80, 23);
            this.CancelCreateButton.TabIndex = 12;
            this.CancelCreateButton.Text = "Cancel";
            this.CancelCreateButton.UseVisualStyleBackColor = true;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NewProjectForm";
            this.Text = "Create New Project";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.Label DateStartedLabel;
        private System.Windows.Forms.MonthCalendar DateStartedMonthCalendar;
        private System.Windows.Forms.Label CommentsLabel;
        private System.Windows.Forms.TextBox CommentsTextbox;
        private System.Windows.Forms.Label ExperimentersLabel;
        private System.Windows.Forms.ListBox ExperimentersListbox;
        private System.Windows.Forms.ComboBox ChooseExperimenterCombobox;
        private System.Windows.Forms.Label ChooseExperimenterLabel;
        private System.Windows.Forms.Button NewExperimenterButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelCreateButton;
    }
}