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
            resources.ApplyResources(this.MainPicturebox, "MainPicturebox");
            this.MainPicturebox.Image = global::MEACruncher.Properties.Resources.NeuronBackground;
            this.MainPicturebox.Name = "MainPicturebox";
            this.MainPicturebox.TabStop = false;
            // 
            // MainTblLayout
            // 
            resources.ApplyResources(this.MainTblLayout, "MainTblLayout");
            this.MainTblLayout.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.MainTblLayout.Controls.Add(this.ExitAppButton, 0, 4);
            this.MainTblLayout.Controls.Add(this.ProjectsBtn, 0, 0);
            this.MainTblLayout.Controls.Add(this.OtherDataButton, 0, 3);
            this.MainTblLayout.Controls.Add(this.PopulationsBtn, 0, 1);
            this.MainTblLayout.Controls.Add(this.FilesBtn, 0, 2);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTblLayout_Paint);
            // 
            // ExitAppButton
            // 
            resources.ApplyResources(this.ExitAppButton, "ExitAppButton");
            this.ExitAppButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.ExitAppButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.ExitAppButton.Name = "ExitAppButton";
            this.ExitAppButton.UseVisualStyleBackColor = false;
            this.ExitAppButton.Click += new System.EventHandler(this.ExitAppButton_Click);
            // 
            // ProjectsBtn
            // 
            resources.ApplyResources(this.ProjectsBtn, "ProjectsBtn");
            this.ProjectsBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.ProjectsBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.ProjectsBtn.Name = "ProjectsBtn";
            this.ProjectsBtn.UseVisualStyleBackColor = false;
            this.ProjectsBtn.Click += new System.EventHandler(this.ProjectsBtn_Click);
            // 
            // OtherDataButton
            // 
            resources.ApplyResources(this.OtherDataButton, "OtherDataButton");
            this.OtherDataButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.OtherDataButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.OtherDataButton.Name = "OtherDataButton";
            this.OtherDataButton.UseVisualStyleBackColor = false;
            this.OtherDataButton.Click += new System.EventHandler(this.OtherDataButton_Click);
            // 
            // PopulationsBtn
            // 
            resources.ApplyResources(this.PopulationsBtn, "PopulationsBtn");
            this.PopulationsBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.PopulationsBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.PopulationsBtn.Name = "PopulationsBtn";
            this.PopulationsBtn.UseVisualStyleBackColor = false;
            // 
            // FilesBtn
            // 
            resources.ApplyResources(this.FilesBtn, "FilesBtn");
            this.FilesBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.FilesBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.FilesBtn.Name = "FilesBtn";
            this.FilesBtn.UseVisualStyleBackColor = false;
            this.FilesBtn.Click += new System.EventHandler(this.FilesBtn_Click);
            // 
            // TitleLbl
            // 
            resources.ApplyResources(this.TitleLbl, "TitleLbl");
            this.TitleLbl.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.TitleLbl.ForeColor = global::MEACruncher.Properties.Settings.Default.LabelForeColor;
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Paint += new System.Windows.Forms.PaintEventHandler(this.TitleLbl_Paint);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.MainTblLayout);
            this.Controls.Add(this.MainPicturebox);
            this.Name = "MainForm";
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

