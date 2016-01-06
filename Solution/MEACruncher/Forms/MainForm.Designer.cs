namespace MEACruncher.Forms {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPicturebox = new System.Windows.Forms.PictureBox();
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ExitAppButton = new System.Windows.Forms.Button();
            this.ProjectsBtn = new System.Windows.Forms.Button();
            this.OtherDataButton = new System.Windows.Forms.Button();
            this.PopulationsBtn = new System.Windows.Forms.Button();
            this.FilesBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicturebox)).BeginInit();
            this.MainTblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPicturebox
            // 
            this.MainPicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPicturebox.Image = global::MEACruncher.Properties.Resources.NeuronBackground;
            this.MainPicturebox.Location = new System.Drawing.Point(0, 0);
            this.MainPicturebox.Name = "MainPicturebox";
            this.MainPicturebox.Size = new System.Drawing.Size(957, 536);
            this.MainPicturebox.TabIndex = 1;
            this.MainPicturebox.TabStop = false;
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainTblLayout.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.ExitAppButton, 0, 4);
            this.MainTblLayout.Controls.Add(this.ProjectsBtn, 0, 0);
            this.MainTblLayout.Controls.Add(this.OtherDataButton, 0, 3);
            this.MainTblLayout.Controls.Add(this.PopulationsBtn, 0, 1);
            this.MainTblLayout.Controls.Add(this.FilesBtn, 0, 2);
            this.MainTblLayout.Location = new System.Drawing.Point(368, 160);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 5;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.MainTblLayout.Size = new System.Drawing.Size(220, 260);
            this.MainTblLayout.TabIndex = 2;
            this.MainTblLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTblLayout_Paint);
            // 
            // ExitAppButton
            // 
            this.ExitAppButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitAppButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.ExitAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitAppButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ExitAppButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.ExitAppButton.Location = new System.Drawing.Point(10, 211);
            this.ExitAppButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.ExitAppButton.Name = "ExitAppButton";
            this.ExitAppButton.Size = new System.Drawing.Size(200, 40);
            this.ExitAppButton.TabIndex = 9;
            this.ExitAppButton.Text = "Exit";
            this.ExitAppButton.UseVisualStyleBackColor = false;
            this.ExitAppButton.Click += new System.EventHandler(this.ExitAppButton_Click);
            // 
            // ProjectsBtn
            // 
            this.ProjectsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProjectsBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.ProjectsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjectsBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ProjectsBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.ProjectsBtn.Location = new System.Drawing.Point(10, 9);
            this.ProjectsBtn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.ProjectsBtn.Name = "ProjectsBtn";
            this.ProjectsBtn.Size = new System.Drawing.Size(200, 40);
            this.ProjectsBtn.TabIndex = 7;
            this.ProjectsBtn.Text = "View Projects";
            this.ProjectsBtn.UseVisualStyleBackColor = false;
            this.ProjectsBtn.Click += new System.EventHandler(this.ProjectsBtn_Click);
            // 
            // OtherDataButton
            // 
            this.OtherDataButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OtherDataButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.OtherDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OtherDataButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.OtherDataButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.OtherDataButton.Location = new System.Drawing.Point(10, 160);
            this.OtherDataButton.Name = "OtherDataButton";
            this.OtherDataButton.Size = new System.Drawing.Size(200, 40);
            this.OtherDataButton.TabIndex = 8;
            this.OtherDataButton.Text = "View Other Data";
            this.OtherDataButton.UseVisualStyleBackColor = false;
            this.OtherDataButton.Click += new System.EventHandler(this.OtherDataButton_Click);
            // 
            // PopulationsBtn
            // 
            this.PopulationsBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PopulationsBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.PopulationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopulationsBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PopulationsBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.PopulationsBtn.Location = new System.Drawing.Point(10, 60);
            this.PopulationsBtn.Name = "PopulationsBtn";
            this.PopulationsBtn.Size = new System.Drawing.Size(200, 40);
            this.PopulationsBtn.TabIndex = 6;
            this.PopulationsBtn.Text = "View Populations";
            this.PopulationsBtn.UseVisualStyleBackColor = false;
            // 
            // FilesBtn
            // 
            this.FilesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FilesBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.FilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilesBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.FilesBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.FilesBtn.Location = new System.Drawing.Point(10, 110);
            this.FilesBtn.Name = "FilesBtn";
            this.FilesBtn.Size = new System.Drawing.Size(200, 40);
            this.FilesBtn.TabIndex = 5;
            this.FilesBtn.Text = "View Tissue Types";
            this.FilesBtn.UseVisualStyleBackColor = false;
            this.FilesBtn.Click += new System.EventHandler(this.FilesBtn_Click);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 50F);
            this.TitleLbl.ForeColor = global::MEACruncher.Properties.Settings.Default.LabelForeColor;
            this.TitleLbl.Location = new System.Drawing.Point(248, 54);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(460, 89);
            this.TitleLbl.TabIndex = 3;
            this.TitleLbl.Text = "MEA Cruncher";
            this.TitleLbl.Paint += new System.Windows.Forms.PaintEventHandler(this.TitleLbl_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 536);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.MainTblLayout);
            this.Controls.Add(this.MainPicturebox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 480);
            this.Name = "MainForm";
            this.Text = "MEA Cruncher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.MainPicturebox)).EndInit();
            this.MainTblLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPicturebox;
        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.Button ExitAppButton;
        private System.Windows.Forms.Button ProjectsBtn;
        private System.Windows.Forms.Button OtherDataButton;
        private System.Windows.Forms.Button PopulationsBtn;
        private System.Windows.Forms.Button FilesBtn;
        private System.Windows.Forms.Label TitleLbl;

    }
}

