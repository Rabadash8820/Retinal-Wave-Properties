﻿namespace MEACruncher {
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
            this.LoadProjectButton = new System.Windows.Forms.Button();
            this.OtherDataButton = new System.Windows.Forms.Button();
            this.ExitAppButton = new System.Windows.Forms.Button();
            this.ExperimentersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadProjectButton
            // 
            this.LoadProjectButton.AutoSize = true;
            this.LoadProjectButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LoadProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadProjectButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadProjectButton.Location = new System.Drawing.Point(12, 12);
            this.LoadProjectButton.Name = "LoadProjectButton";
            this.LoadProjectButton.Size = new System.Drawing.Size(258, 49);
            this.LoadProjectButton.TabIndex = 0;
            this.LoadProjectButton.Text = "View Projects";
            this.LoadProjectButton.UseVisualStyleBackColor = false;
            this.LoadProjectButton.Click += new System.EventHandler(this.LoadProjectButton_Click);
            // 
            // OtherDataButton
            // 
            this.OtherDataButton.AutoSize = true;
            this.OtherDataButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.OtherDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OtherDataButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherDataButton.Location = new System.Drawing.Point(12, 122);
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
            this.ExitAppButton.Location = new System.Drawing.Point(12, 175);
            this.ExitAppButton.Name = "ExitAppButton";
            this.ExitAppButton.Size = new System.Drawing.Size(258, 49);
            this.ExitAppButton.TabIndex = 0;
            this.ExitAppButton.Text = "Exit";
            this.ExitAppButton.UseVisualStyleBackColor = false;
            this.ExitAppButton.Click += new System.EventHandler(this.ExitAppButton_Click);
            // 
            // ExperimentersButton
            // 
            this.ExperimentersButton.AutoSize = true;
            this.ExperimentersButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ExperimentersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExperimentersButton.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExperimentersButton.Location = new System.Drawing.Point(12, 67);
            this.ExperimentersButton.Name = "ExperimentersButton";
            this.ExperimentersButton.Size = new System.Drawing.Size(261, 49);
            this.ExperimentersButton.TabIndex = 1;
            this.ExperimentersButton.Text = "View Experimenters";
            this.ExperimentersButton.UseVisualStyleBackColor = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(279, 238);
            this.Controls.Add(this.ExperimentersButton);
            this.Controls.Add(this.ExitAppButton);
            this.Controls.Add(this.OtherDataButton);
            this.Controls.Add(this.LoadProjectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to MEA Cruncher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadProjectButton;
        private System.Windows.Forms.Button OtherDataButton;
        private System.Windows.Forms.Button ExitAppButton;
        private System.Windows.Forms.Button ExperimentersButton;
    }
}