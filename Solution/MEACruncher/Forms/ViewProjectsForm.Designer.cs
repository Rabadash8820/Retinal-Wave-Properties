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
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.EntitiesTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.EntitiesDGV = new System.Windows.Forms.DataGridView();
            this.TitleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateStartedCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntitiesPanel = new System.Windows.Forms.Panel();
            this.AssocBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.NewBtn = new System.Windows.Forms.Button();
            this.AssocTabCtrl = new System.Windows.Forms.TabControl();
            this.PopulationsTab = new System.Windows.Forms.TabPage();
            this.AssocTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.PopulationsDGV = new System.Windows.Forms.DataGridView();
            this.PopNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopAgesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopConditionsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopStrainsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopTissueTypesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopCommentsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PopulationsPanel = new System.Windows.Forms.Panel();
            this.PopNewBtn = new System.Windows.Forms.Button();
            this.PopRemoveBtn = new System.Windows.Forms.Button();
            this.PopAddBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).BeginInit();
            this.MainTblLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.EntitiesTblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).BeginInit();
            this.EntitiesPanel.SuspendLayout();
            this.AssocTabCtrl.SuspendLayout();
            this.PopulationsTab.SuspendLayout();
            this.AssocTblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationsDGV)).BeginInit();
            this.PopulationsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTblLayout
            // 
            resources.ApplyResources(this.MainTblLayout, "MainTblLayout");
            this.MainTblLayout.Controls.Add(this.EntitiesDGV, 0, 0);
            this.MainTblLayout.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTblLayout.Controls.Add(this.MainSplit, 0, 0);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 2;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTblLayout.Size = new System.Drawing.Size(697, 386);
            this.MainTblLayout.TabIndex = 0;
            // 
            // BottomPanel
            // 
            resources.ApplyResources(this.BottomPanel, "BottomPanel");
            this.BottomPanel.Controls.Add(this.DeleteBtn);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Controls.Add(this.NewBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 354);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(691, 29);
            this.BottomPanel.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(613, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.Location = new System.Drawing.Point(3, 3);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.EntitiesTblLayout);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.AssocTabCtrl);
            this.MainSplit.Size = new System.Drawing.Size(691, 345);
            this.MainSplit.SplitterDistance = 134;
            this.MainSplit.TabIndex = 2;
            // 
            // EntitiesTblLayout
            // 
            this.EntitiesTblLayout.ColumnCount = 1;
            this.EntitiesTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EntitiesTblLayout.Controls.Add(this.EntitiesDGV, 0, 0);
            this.EntitiesTblLayout.Controls.Add(this.EntitiesPanel, 0, 1);
            this.EntitiesTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntitiesTblLayout.Location = new System.Drawing.Point(0, 0);
            this.EntitiesTblLayout.Name = "EntitiesTblLayout";
            this.EntitiesTblLayout.RowCount = 2;
            this.EntitiesTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EntitiesTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.EntitiesTblLayout.Size = new System.Drawing.Size(691, 134);
            this.EntitiesTblLayout.TabIndex = 0;
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
            this.EntitiesDGV.Size = new System.Drawing.Size(685, 93);
            this.EntitiesDGV.TabIndex = 2;
            this.EntitiesDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntitiesDGV_RowEnter);
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
            // EntitiesPanel
            // 
            this.EntitiesPanel.Controls.Add(this.AssocBtn);
            this.EntitiesPanel.Controls.Add(this.DeleteBtn);
            this.EntitiesPanel.Controls.Add(this.NewBtn);
            this.EntitiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntitiesPanel.Location = new System.Drawing.Point(3, 102);
            this.EntitiesPanel.Name = "EntitiesPanel";
            this.EntitiesPanel.Size = new System.Drawing.Size(685, 29);
            this.EntitiesPanel.TabIndex = 3;
            // 
            // AssocBtn
            // 
            this.AssocBtn.AutoSize = true;
            this.AssocBtn.Location = new System.Drawing.Point(87, 3);
            this.AssocBtn.Name = "AssocBtn";
            this.AssocBtn.Size = new System.Drawing.Size(86, 23);
            this.AssocBtn.TabIndex = 2;
            this.AssocBtn.Text = "Associations";
            this.AssocBtn.UseVisualStyleBackColor = true;
            this.AssocBtn.Click += new System.EventHandler(this.AssocBtn_Click);
            // 
            // DeleteBtn
            // 
            resources.ApplyResources(this.DeleteBtn, "DeleteBtn");
            this.DeleteBtn.AutoSize = true;
            this.DeleteBtn.Location = new System.Drawing.Point(179, 3);
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
            // NewBtn
            // 
            resources.ApplyResources(this.NewBtn, "NewBtn");
            this.NewBtn.AutoSize = true;
            this.NewBtn.Location = new System.Drawing.Point(6, 3);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // AssocTabCtrl
            // 
            this.AssocTabCtrl.Controls.Add(this.PopulationsTab);
            this.AssocTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssocTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.AssocTabCtrl.Name = "AssocTabCtrl";
            this.AssocTabCtrl.SelectedIndex = 0;
            this.AssocTabCtrl.Size = new System.Drawing.Size(691, 207);
            this.AssocTabCtrl.TabIndex = 0;
            // 
            // PopulationsTab
            // 
            this.PopulationsTab.Controls.Add(this.AssocTblLayout);
            this.PopulationsTab.Location = new System.Drawing.Point(4, 22);
            this.PopulationsTab.Name = "PopulationsTab";
            this.PopulationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.PopulationsTab.Size = new System.Drawing.Size(683, 181);
            this.PopulationsTab.TabIndex = 0;
            this.PopulationsTab.Text = "Populations";
            this.PopulationsTab.UseVisualStyleBackColor = true;
            // 
            // AssocTblLayout
            // 
            this.AssocTblLayout.ColumnCount = 1;
            this.AssocTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssocTblLayout.Controls.Add(this.PopulationsDGV, 0, 0);
            this.AssocTblLayout.Controls.Add(this.PopulationsPanel, 0, 1);
            this.AssocTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssocTblLayout.Location = new System.Drawing.Point(3, 3);
            this.AssocTblLayout.Name = "AssocTblLayout";
            this.AssocTblLayout.RowCount = 2;
            this.AssocTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AssocTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.AssocTblLayout.Size = new System.Drawing.Size(677, 175);
            this.AssocTblLayout.TabIndex = 0;
            // 
            // PopulationsDGV
            // 
            this.PopulationsDGV.AllowUserToAddRows = false;
            this.PopulationsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PopulationsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PopNameCol,
            this.PopAgesCol,
            this.PopConditionsCol,
            this.PopStrainsCol,
            this.PopTissueTypesCol,
            this.PopCommentsCol});
            this.PopulationsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PopulationsDGV.Location = new System.Drawing.Point(3, 3);
            this.PopulationsDGV.Name = "PopulationsDGV";
            this.PopulationsDGV.Size = new System.Drawing.Size(671, 134);
            this.PopulationsDGV.TabIndex = 1;
            // 
            // PopNameCol
            // 
            this.PopNameCol.HeaderText = "Name";
            this.PopNameCol.Name = "PopNameCol";
            // 
            // PopAgesCol
            // 
            this.PopAgesCol.HeaderText = "Ages";
            this.PopAgesCol.Name = "PopAgesCol";
            this.PopAgesCol.ReadOnly = true;
            // 
            // PopConditionsCol
            // 
            this.PopConditionsCol.HeaderText = "Conditions";
            this.PopConditionsCol.Name = "PopConditionsCol";
            this.PopConditionsCol.ReadOnly = true;
            // 
            // PopStrainsCol
            // 
            this.PopStrainsCol.HeaderText = "Strains";
            this.PopStrainsCol.Name = "PopStrainsCol";
            this.PopStrainsCol.ReadOnly = true;
            // 
            // PopTissueTypesCol
            // 
            this.PopTissueTypesCol.HeaderText = "Tissue Types";
            this.PopTissueTypesCol.Name = "PopTissueTypesCol";
            this.PopTissueTypesCol.ReadOnly = true;
            // 
            // PopCommentsCol
            // 
            this.PopCommentsCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PopCommentsCol.HeaderText = "Comments";
            this.PopCommentsCol.Name = "PopCommentsCol";
            // 
            // PopulationsPanel
            // 
            this.PopulationsPanel.Controls.Add(this.PopNewBtn);
            this.PopulationsPanel.Controls.Add(this.PopRemoveBtn);
            this.PopulationsPanel.Controls.Add(this.PopAddBtn);
            this.PopulationsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PopulationsPanel.Location = new System.Drawing.Point(3, 143);
            this.PopulationsPanel.Name = "PopulationsPanel";
            this.PopulationsPanel.Size = new System.Drawing.Size(671, 29);
            this.PopulationsPanel.TabIndex = 2;
            // 
            // PopNewBtn
            // 
            this.PopNewBtn.AutoSize = true;
            this.PopNewBtn.Location = new System.Drawing.Point(84, 3);
            this.PopNewBtn.Name = "PopNewBtn";
            this.PopNewBtn.Size = new System.Drawing.Size(75, 23);
            this.PopNewBtn.TabIndex = 4;
            this.PopNewBtn.Text = "Create New";
            this.PopNewBtn.UseVisualStyleBackColor = true;
            // 
            // PopRemoveBtn
            // 
            this.PopRemoveBtn.AutoSize = true;
            this.PopRemoveBtn.Location = new System.Drawing.Point(165, 3);
            this.PopRemoveBtn.Name = "PopRemoveBtn";
            this.PopRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.PopRemoveBtn.TabIndex = 3;
            this.PopRemoveBtn.Text = "Remove";
            this.PopRemoveBtn.UseVisualStyleBackColor = true;
            // 
            // PopAddBtn
            // 
            this.PopAddBtn.AutoSize = true;
            this.PopAddBtn.Location = new System.Drawing.Point(3, 3);
            this.PopAddBtn.Name = "PopAddBtn";
            this.PopAddBtn.Size = new System.Drawing.Size(75, 23);
            this.PopAddBtn.TabIndex = 2;
            this.PopAddBtn.Text = "Add";
            this.PopAddBtn.UseVisualStyleBackColor = true;
            // 
            // ViewProjectsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(697, 386);
            this.Controls.Add(this.MainTblLayout);
            this.MinimizeBox = false;
            this.Name = "ViewProjectsForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).EndInit();
            this.MainTblLayout.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.EntitiesTblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).EndInit();
            this.EntitiesPanel.ResumeLayout(false);
            this.EntitiesPanel.PerformLayout();
            this.AssocTabCtrl.ResumeLayout(false);
            this.PopulationsTab.ResumeLayout(false);
            this.AssocTblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PopulationsDGV)).EndInit();
            this.PopulationsPanel.ResumeLayout(false);
            this.PopulationsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.TabControl AssocTabCtrl;
        private System.Windows.Forms.TabPage PopulationsTab;
        private System.Windows.Forms.TableLayoutPanel EntitiesTblLayout;
        private System.Windows.Forms.DataGridView EntitiesDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateStartedCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsCol;
        private System.Windows.Forms.Panel EntitiesPanel;
        private System.Windows.Forms.TableLayoutPanel AssocTblLayout;
        private System.Windows.Forms.DataGridView PopulationsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopAgesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopConditionsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopStrainsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopTissueTypesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PopCommentsCol;
        private System.Windows.Forms.Panel PopulationsPanel;
        private System.Windows.Forms.Button PopNewBtn;
        private System.Windows.Forms.Button PopRemoveBtn;
        private System.Windows.Forms.Button PopAddBtn;
        private System.Windows.Forms.Button AssocBtn;
    }
}