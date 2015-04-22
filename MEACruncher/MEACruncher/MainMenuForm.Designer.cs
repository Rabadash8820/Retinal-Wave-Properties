namespace MEACruncher {
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
            this.NewProjectButton = new System.Windows.Forms.Button();
            this.LoadProjectButton = new System.Windows.Forms.Button();
            this.OtherDataButton = new System.Windows.Forms.Button();
            this.ExitAppButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewProjectButton
            // 
            this.NewProjectButton.AutoSize = true;
            this.NewProjectButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.NewProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewProjectButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewProjectButton.Location = new System.Drawing.Point(12, 12);
            this.NewProjectButton.Name = "NewProjectButton";
            this.NewProjectButton.Size = new System.Drawing.Size(258, 49);
            this.NewProjectButton.TabIndex = 0;
            this.NewProjectButton.Text = "Create New Project";
            this.NewProjectButton.UseVisualStyleBackColor = false;
            this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
            // 
            // LoadProjectButton
            // 
            this.LoadProjectButton.AutoSize = true;
            this.LoadProjectButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LoadProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadProjectButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadProjectButton.Location = new System.Drawing.Point(12, 65);
            this.LoadProjectButton.Name = "LoadProjectButton";
            this.LoadProjectButton.Size = new System.Drawing.Size(258, 49);
            this.LoadProjectButton.TabIndex = 0;
            this.LoadProjectButton.Text = "Load Project";
            this.LoadProjectButton.UseVisualStyleBackColor = false;
            // 
            // OtherDataButton
            // 
            this.OtherDataButton.AutoSize = true;
            this.OtherDataButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.OtherDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OtherDataButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherDataButton.Location = new System.Drawing.Point(12, 118);
            this.OtherDataButton.Name = "OtherDataButton";
            this.OtherDataButton.Size = new System.Drawing.Size(258, 49);
            this.OtherDataButton.TabIndex = 0;
            this.OtherDataButton.Text = "View Other Data";
            this.OtherDataButton.UseVisualStyleBackColor = false;
            // 
            // ExitAppButton
            // 
            this.ExitAppButton.AutoSize = true;
            this.ExitAppButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ExitAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitAppButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitAppButton.Location = new System.Drawing.Point(12, 171);
            this.ExitAppButton.Name = "ExitAppButton";
            this.ExitAppButton.Size = new System.Drawing.Size(258, 49);
            this.ExitAppButton.TabIndex = 0;
            this.ExitAppButton.Text = "Exit";
            this.ExitAppButton.UseVisualStyleBackColor = false;
            this.ExitAppButton.Click += new System.EventHandler(this.ExitAppButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(279, 230);
            this.Controls.Add(this.ExitAppButton);
            this.Controls.Add(this.OtherDataButton);
            this.Controls.Add(this.LoadProjectButton);
            this.Controls.Add(this.NewProjectButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to MEA Cruncher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewProjectButton;
        private System.Windows.Forms.Button LoadProjectButton;
        private System.Windows.Forms.Button OtherDataButton;
        private System.Windows.Forms.Button ExitAppButton;
    }
}