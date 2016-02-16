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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTissueTypeForm));
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonsPnl = new System.Windows.Forms.Panel();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTree = new System.Windows.Forms.TreeView();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CollapseAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollapseCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollapseChildrenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandCollapseMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExpandAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandChildrenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).BeginInit();
            this.MainTblLayout.SuspendLayout();
            this.ButtonsPnl.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainWorker
            // 
            this.MainWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadEntityWorker_DoWork);
            this.MainWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadEntityWorker_RunWorkerCompleted);
            // 
            // EntityBS
            // 
            this.EntityBS.AllowNew = false;
            // 
            // MainTblLayout
            // 
            resources.ApplyResources(this.MainTblLayout, "MainTblLayout");
            this.MainTblLayout.Controls.Add(this.ButtonsPnl, 0, 2);
            this.MainTblLayout.Controls.Add(this.MainTree, 0, 1);
            this.MainTblLayout.Controls.Add(this.SearchTxt, 0, 0);
            this.MainTblLayout.Name = "MainTblLayout";
            // 
            // ButtonsPnl
            // 
            this.ButtonsPnl.Controls.Add(this.InfoLbl);
            this.ButtonsPnl.Controls.Add(this.AddBtn);
            this.ButtonsPnl.Controls.Add(this.CancelBtn);
            resources.ApplyResources(this.ButtonsPnl, "ButtonsPnl");
            this.ButtonsPnl.Name = "ButtonsPnl";
            // 
            // InfoLbl
            // 
            resources.ApplyResources(this.InfoLbl, "InfoLbl");
            this.InfoLbl.Name = "InfoLbl";
            // 
            // AddBtn
            // 
            resources.ApplyResources(this.AddBtn, "AddBtn");
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CancelBtn
            // 
            resources.ApplyResources(this.CancelBtn, "CancelBtn");
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MainTree
            // 
            this.MainTree.ContextMenuStrip = this.TreeContextMenu;
            resources.ApplyResources(this.MainTree, "MainTree");
            this.MainTree.HideSelection = false;
            this.MainTree.Name = "MainTree";
            this.MainTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTree_AfterSelect);
            this.MainTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MainTree_NodeMouseClick);
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CollapseAllMenuItem,
            this.CollapseCurrentMenuItem,
            this.CollapseChildrenMenuItem,
            this.ExpandCollapseMenuSeparator,
            this.ExpandAllMenuItem,
            this.ExpandCurrentMenuItem,
            this.ExpandChildrenMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            resources.ApplyResources(this.TreeContextMenu, "TreeContextMenu");
            this.TreeContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TreeContextMenu_ItemClicked);
            // 
            // CollapseAllMenuItem
            // 
            this.CollapseAllMenuItem.Name = "CollapseAllMenuItem";
            resources.ApplyResources(this.CollapseAllMenuItem, "CollapseAllMenuItem");
            // 
            // CollapseCurrentMenuItem
            // 
            this.CollapseCurrentMenuItem.Name = "CollapseCurrentMenuItem";
            resources.ApplyResources(this.CollapseCurrentMenuItem, "CollapseCurrentMenuItem");
            // 
            // CollapseChildrenMenuItem
            // 
            this.CollapseChildrenMenuItem.Name = "CollapseChildrenMenuItem";
            resources.ApplyResources(this.CollapseChildrenMenuItem, "CollapseChildrenMenuItem");
            // 
            // ExpandCollapseMenuSeparator
            // 
            this.ExpandCollapseMenuSeparator.Name = "ExpandCollapseMenuSeparator";
            resources.ApplyResources(this.ExpandCollapseMenuSeparator, "ExpandCollapseMenuSeparator");
            // 
            // ExpandAllMenuItem
            // 
            this.ExpandAllMenuItem.Name = "ExpandAllMenuItem";
            resources.ApplyResources(this.ExpandAllMenuItem, "ExpandAllMenuItem");
            // 
            // ExpandCurrentMenuItem
            // 
            this.ExpandCurrentMenuItem.Name = "ExpandCurrentMenuItem";
            resources.ApplyResources(this.ExpandCurrentMenuItem, "ExpandCurrentMenuItem");
            // 
            // ExpandChildrenMenuItem
            // 
            this.ExpandChildrenMenuItem.Name = "ExpandChildrenMenuItem";
            resources.ApplyResources(this.ExpandChildrenMenuItem, "ExpandChildrenMenuItem");
            // 
            // SearchTxt
            // 
            this.SearchTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.SearchTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.SearchTxt, "SearchTxt");
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.Leave += new System.EventHandler(this.SearchTxt_Leave);
            this.SearchTxt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SearchTxt_MouseUp);
            // 
            // AddTissueTypeForm
            // 
            this.AcceptButton = this.AddBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.Controls.Add(this.MainTblLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTissueTypeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddTissueTypeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).EndInit();
            this.MainTblLayout.ResumeLayout(false);
            this.MainTblLayout.PerformLayout();
            this.ButtonsPnl.ResumeLayout(false);
            this.ButtonsPnl.PerformLayout();
            this.TreeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.Panel ButtonsPnl;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TreeView MainTree;
        private System.Windows.Forms.TextBox SearchTxt;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CollapseAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollapseCurrentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandCurrentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollapseChildrenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandChildrenMenuItem;
        private System.Windows.Forms.ToolStripSeparator ExpandCollapseMenuSeparator;
        private System.Windows.Forms.Label InfoLbl;
    }
}