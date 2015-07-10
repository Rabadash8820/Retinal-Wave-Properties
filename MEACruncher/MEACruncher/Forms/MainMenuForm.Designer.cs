namespace MEACruncher.Forms {
    partial class MainMenuForm {
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
            this.ExitAppButton = new System.Windows.Forms.Button();
            this.OtherDataButton = new System.Windows.Forms.Button();
            this.ProjectsBtn = new System.Windows.Forms.Button();
            this.PopulationsBtn = new System.Windows.Forms.Button();
            this.FilesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitAppButton
            // 
            this.ExitAppButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.ExitAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitAppButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitAppButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.ExitAppButton.Location = new System.Drawing.Point(9, 228);
            this.ExitAppButton.Name = "ExitAppButton";
            this.ExitAppButton.Size = new System.Drawing.Size(261, 49);
            this.ExitAppButton.TabIndex = 4;
            this.ExitAppButton.Text = "Exit";
            this.ExitAppButton.UseVisualStyleBackColor = false;
            this.ExitAppButton.Click += new System.EventHandler(this.ExitAppButton_Click);
            // 
            // OtherDataButton
            // 
            this.OtherDataButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.OtherDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OtherDataButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherDataButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.OtherDataButton.Location = new System.Drawing.Point(9, 174);
            this.OtherDataButton.Name = "OtherDataButton";
            this.OtherDataButton.Size = new System.Drawing.Size(261, 49);
            this.OtherDataButton.TabIndex = 3;
            this.OtherDataButton.Text = "View Other Data";
            this.OtherDataButton.UseVisualStyleBackColor = false;
            // 
            // ProjectsBtn
            // 
            this.ProjectsBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.ProjectsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjectsBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectsBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.ProjectsBtn.Location = new System.Drawing.Point(9, 12);
            this.ProjectsBtn.Name = "ProjectsBtn";
            this.ProjectsBtn.Size = new System.Drawing.Size(261, 49);
            this.ProjectsBtn.TabIndex = 0;
            this.ProjectsBtn.Text = "View Projects";
            this.ProjectsBtn.UseVisualStyleBackColor = false;
            this.ProjectsBtn.Click += new System.EventHandler(this.LoadProjectButton_Click);
            // 
            // PopulationsBtn
            // 
            this.PopulationsBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.PopulationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopulationsBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopulationsBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.PopulationsBtn.Location = new System.Drawing.Point(9, 66);
            this.PopulationsBtn.Name = "PopulationsBtn";
            this.PopulationsBtn.Size = new System.Drawing.Size(261, 49);
            this.PopulationsBtn.TabIndex = 0;
            this.PopulationsBtn.Text = "View Populations";
            this.PopulationsBtn.UseVisualStyleBackColor = false;
            // 
            // FilesBtn
            // 
            this.FilesBtn.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.FilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilesBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilesBtn.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.FilesBtn.Location = new System.Drawing.Point(9, 120);
            this.FilesBtn.Name = "FilesBtn";
            this.FilesBtn.Size = new System.Drawing.Size(261, 49);
            this.FilesBtn.TabIndex = 0;
            this.FilesBtn.Text = "View Files";
            this.FilesBtn.UseVisualStyleBackColor = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.ClientSize = new System.Drawing.Size(279, 289);
            this.Controls.Add(this.ExitAppButton);
            this.Controls.Add(this.OtherDataButton);
            this.Controls.Add(this.FilesBtn);
            this.Controls.Add(this.PopulationsBtn);
            this.Controls.Add(this.ProjectsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEA Cruncher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProjectsBtn;
        private System.Windows.Forms.Button OtherDataButton;
        private System.Windows.Forms.Button ExitAppButton;
        private System.Windows.Forms.Button PopulationsBtn;
        private System.Windows.Forms.Button FilesBtn;
    }
}