namespace MEACruncher.Forms {
    partial class AddTissueTypeForm {
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
            this.MainListView = new System.Windows.Forms.ListView();
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonsPnl = new System.Windows.Forms.Panel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTblLayout.SuspendLayout();
            this.ButtonsPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainListView.Location = new System.Drawing.Point(3, 3);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(403, 237);
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.MainListView, 0, 0);
            this.MainTblLayout.Controls.Add(this.ButtonsPnl, 0, 1);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 2;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTblLayout.Size = new System.Drawing.Size(409, 278);
            this.MainTblLayout.TabIndex = 1;
            // 
            // ButtonsPnl
            // 
            this.ButtonsPnl.Controls.Add(this.AddBtn);
            this.ButtonsPnl.Controls.Add(this.CancelBtn);
            this.ButtonsPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPnl.Location = new System.Drawing.Point(3, 246);
            this.ButtonsPnl.Name = "ButtonsPnl";
            this.ButtonsPnl.Size = new System.Drawing.Size(403, 29);
            this.ButtonsPnl.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBtn.AutoSize = true;
            this.AddBtn.Location = new System.Drawing.Point(244, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(325, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // AddTissueTypeForm
            // 
            this.AcceptButton = this.AddBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(409, 278);
            this.Controls.Add(this.MainTblLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTissueTypeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Tissue Type";
            this.MainTblLayout.ResumeLayout(false);
            this.ButtonsPnl.ResumeLayout(false);
            this.ButtonsPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.Panel ButtonsPnl;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}