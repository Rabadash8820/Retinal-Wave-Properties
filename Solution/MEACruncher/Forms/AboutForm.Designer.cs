namespace MEACruncher {
    partial class AboutForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.LogoPic = new System.Windows.Forms.PictureBox();
            this.ProductNameLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.CopyrightLbl = new System.Windows.Forms.Label();
            this.CompanyNameLbl = new System.Windows.Forms.Label();
            this.DescriptionTxt = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.MainTblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 2;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.MainTblLayout.Controls.Add(this.LogoPic, 0, 0);
            this.MainTblLayout.Controls.Add(this.ProductNameLbl, 1, 0);
            this.MainTblLayout.Controls.Add(this.VersionLbl, 1, 1);
            this.MainTblLayout.Controls.Add(this.CopyrightLbl, 1, 2);
            this.MainTblLayout.Controls.Add(this.CompanyNameLbl, 1, 3);
            this.MainTblLayout.Controls.Add(this.DescriptionTxt, 1, 4);
            this.MainTblLayout.Controls.Add(this.OkBtn, 1, 5);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(9, 9);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 6;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTblLayout.Size = new System.Drawing.Size(417, 265);
            this.MainTblLayout.TabIndex = 0;
            // 
            // LogoPic
            // 
            this.LogoPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoPic.Image = ((System.Drawing.Image)(resources.GetObject("LogoPic.Image")));
            this.LogoPic.Location = new System.Drawing.Point(3, 3);
            this.LogoPic.Name = "LogoPic";
            this.MainTblLayout.SetRowSpan(this.LogoPic, 6);
            this.LogoPic.Size = new System.Drawing.Size(131, 259);
            this.LogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPic.TabIndex = 12;
            this.LogoPic.TabStop = false;
            // 
            // ProductNameLbl
            // 
            this.ProductNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductNameLbl.Location = new System.Drawing.Point(143, 0);
            this.ProductNameLbl.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.ProductNameLbl.MaximumSize = new System.Drawing.Size(0, 17);
            this.ProductNameLbl.Name = "ProductNameLbl";
            this.ProductNameLbl.Size = new System.Drawing.Size(271, 17);
            this.ProductNameLbl.TabIndex = 19;
            this.ProductNameLbl.Text = "MEA Cruncher";
            this.ProductNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionLbl
            // 
            this.VersionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionLbl.Location = new System.Drawing.Point(143, 26);
            this.VersionLbl.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.VersionLbl.MaximumSize = new System.Drawing.Size(0, 17);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(271, 17);
            this.VersionLbl.TabIndex = 0;
            this.VersionLbl.Text = "Version 0.1.0";
            // 
            // CopyrightLbl
            // 
            this.CopyrightLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CopyrightLbl.Location = new System.Drawing.Point(143, 52);
            this.CopyrightLbl.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.CopyrightLbl.MaximumSize = new System.Drawing.Size(0, 17);
            this.CopyrightLbl.Name = "CopyrightLbl";
            this.CopyrightLbl.Size = new System.Drawing.Size(271, 17);
            this.CopyrightLbl.TabIndex = 21;
            this.CopyrightLbl.Text = "© March, 2015";
            this.CopyrightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompanyNameLbl
            // 
            this.CompanyNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyNameLbl.Location = new System.Drawing.Point(143, 78);
            this.CompanyNameLbl.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.CompanyNameLbl.MaximumSize = new System.Drawing.Size(0, 17);
            this.CompanyNameLbl.Name = "CompanyNameLbl";
            this.CompanyNameLbl.Size = new System.Drawing.Size(271, 17);
            this.CompanyNameLbl.TabIndex = 22;
            this.CompanyNameLbl.Text = "Danware";
            this.CompanyNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionTxt.Location = new System.Drawing.Point(143, 107);
            this.DescriptionTxt.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.DescriptionTxt.Multiline = true;
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.ReadOnly = true;
            this.DescriptionTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DescriptionTxt.Size = new System.Drawing.Size(271, 126);
            this.DescriptionTxt.TabIndex = 23;
            this.DescriptionTxt.TabStop = false;
            this.DescriptionTxt.Text = "Description";
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkBtn.Location = new System.Drawing.Point(339, 239);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 24;
            this.OkBtn.Text = "&OK";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.MainTblLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About MEA Cruncher";
            this.MainTblLayout.ResumeLayout(false);
            this.MainTblLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.PictureBox LogoPic;
        private System.Windows.Forms.Label ProductNameLbl;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label CopyrightLbl;
        private System.Windows.Forms.Label CompanyNameLbl;
        private System.Windows.Forms.TextBox DescriptionTxt;
        private System.Windows.Forms.Button OkBtn;
    }
}
