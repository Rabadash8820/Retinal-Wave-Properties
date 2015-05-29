namespace MEACruncher.Forms.ViewForms {
    partial class ViewExperimentersForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewExperimentersForm));
            this.FullNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuspendLayout();
            // 
            // FullNameColumn
            // 
            this.FullNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullNameColumn.HeaderText = "Full Name";
            this.FullNameColumn.MaxInputLength = 30;
            this.FullNameColumn.Name = "FullNameColumn";
            this.FullNameColumn.Width = 94;
            // 
            // EmailColumn
            // 
            this.EmailColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmailColumn.HeaderText = "Work Email";
            this.EmailColumn.MaxInputLength = 25;
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.Width = 102;
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PhoneColumn.HeaderText = "Work Phone";
            this.PhoneColumn.MaxInputLength = 15;
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.Width = 109;
            // 
            // CommentsColumn
            // 
            this.CommentsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            // 
            // ViewExperimentersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.ClientSize = new System.Drawing.Size(602, 249);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 150);
            this.Name = "ViewExperimentersForm";
            this.ShowInTaskbar = false;
            this.Text = "Experimenters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn FullNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;

    }
}