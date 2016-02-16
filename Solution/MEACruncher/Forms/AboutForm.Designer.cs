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
            resources.ApplyResources(this.MainTblLayout, "MainTblLayout");
            this.MainTblLayout.Controls.Add(this.LogoPic, 0, 0);
            this.MainTblLayout.Controls.Add(this.ProductNameLbl, 1, 0);
            this.MainTblLayout.Controls.Add(this.VersionLbl, 1, 1);
            this.MainTblLayout.Controls.Add(this.CopyrightLbl, 1, 2);
            this.MainTblLayout.Controls.Add(this.CompanyNameLbl, 1, 3);
            this.MainTblLayout.Controls.Add(this.DescriptionTxt, 1, 4);
            this.MainTblLayout.Controls.Add(this.OkBtn, 1, 5);
            this.MainTblLayout.Name = "MainTblLayout";
            // 
            // LogoPic
            // 
            resources.ApplyResources(this.LogoPic, "LogoPic");
            this.LogoPic.Name = "LogoPic";
            this.MainTblLayout.SetRowSpan(this.LogoPic, 6);
            this.LogoPic.TabStop = false;
            // 
            // ProductNameLbl
            // 
            resources.ApplyResources(this.ProductNameLbl, "ProductNameLbl");
            this.ProductNameLbl.Name = "ProductNameLbl";
            // 
            // VersionLbl
            // 
            resources.ApplyResources(this.VersionLbl, "VersionLbl");
            this.VersionLbl.Name = "VersionLbl";
            // 
            // CopyrightLbl
            // 
            resources.ApplyResources(this.CopyrightLbl, "CopyrightLbl");
            this.CopyrightLbl.Name = "CopyrightLbl";
            // 
            // CompanyNameLbl
            // 
            resources.ApplyResources(this.CompanyNameLbl, "CompanyNameLbl");
            this.CompanyNameLbl.Name = "CompanyNameLbl";
            // 
            // DescriptionTxt
            // 
            resources.ApplyResources(this.DescriptionTxt, "DescriptionTxt");
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.ReadOnly = true;
            this.DescriptionTxt.TabStop = false;
            // 
            // OkBtn
            // 
            resources.ApplyResources(this.OkBtn, "OkBtn");
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkBtn.Name = "OkBtn";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.OkBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTblLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
