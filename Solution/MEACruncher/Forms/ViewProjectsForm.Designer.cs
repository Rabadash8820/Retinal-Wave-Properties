namespace MEACruncher.Forms {
    partial class ViewProjectsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProjectsForm));
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.EntitiesDGV = new System.Windows.Forms.DataGridView();
            this.TitleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateStartedCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.NewBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).BeginInit();
            this.MainTblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTblLayout
            // 
            resources.ApplyResources(this.MainTblLayout, "MainTblLayout");
            this.MainTblLayout.Controls.Add(this.EntitiesDGV, 0, 0);
            this.MainTblLayout.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTblLayout.Name = "MainTblLayout";
            // 
            // EntitiesDGV
            // 
            this.EntitiesDGV.AllowUserToAddRows = false;
            this.EntitiesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntitiesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleCol,
            this.DateStartedCol,
            this.CommentsCol});
            resources.ApplyResources(this.EntitiesDGV, "EntitiesDGV");
            this.EntitiesDGV.Name = "EntitiesDGV";
            this.EntitiesDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EntitiesDGV_CellFormatting);
            this.EntitiesDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EntitiesDGV_CellValidating);
            this.EntitiesDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.EntitiesDGV_DataError);
            this.EntitiesDGV.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntitiesDGV_RowValidated);
            this.EntitiesDGV.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EntitiesDGV_RowValidating);
            // 
            // TitleCol
            // 
            resources.ApplyResources(this.TitleCol, "TitleCol");
            this.TitleCol.Name = "TitleCol";
            // 
            // DateStartedCol
            // 
            resources.ApplyResources(this.DateStartedCol, "DateStartedCol");
            this.DateStartedCol.Name = "DateStartedCol";
            // 
            // CommentsCol
            // 
            this.CommentsCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.CommentsCol, "CommentsCol");
            this.CommentsCol.Name = "CommentsCol";
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.DeleteBtn);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Controls.Add(this.EditBtn);
            this.BottomPanel.Controls.Add(this.NewBtn);
            resources.ApplyResources(this.BottomPanel, "BottomPanel");
            this.BottomPanel.Name = "BottomPanel";
            // 
            // DeleteBtn
            // 
            resources.ApplyResources(this.DeleteBtn, "DeleteBtn");
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // CloseBtn
            // 
            resources.ApplyResources(this.CloseBtn, "CloseBtn");
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // EditBtn
            // 
            resources.ApplyResources(this.EditBtn, "EditBtn");
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // NewBtn
            // 
            resources.ApplyResources(this.NewBtn, "NewBtn");
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // ViewProjectsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.Controls.Add(this.MainTblLayout);
            this.MinimizeBox = false;
            this.Name = "ViewProjectsForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).EndInit();
            this.MainTblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.DataGridView EntitiesDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateStartedCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsCol;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.Button DeleteBtn;
    }
}