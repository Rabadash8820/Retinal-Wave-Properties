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
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonsPnl = new System.Windows.Forms.Panel();
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
            // LoadEntityWorker
            // 
            this.LoadEntityWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadEntityWorker_DoWork);
            this.LoadEntityWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadEntityWorker_RunWorkerCompleted);
            // 
            // EntityBS
            // 
            this.EntityBS.AllowNew = false;
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.ButtonsPnl, 0, 2);
            this.MainTblLayout.Controls.Add(this.MainTree, 0, 1);
            this.MainTblLayout.Controls.Add(this.SearchTxt, 0, 0);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 3;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTblLayout.Size = new System.Drawing.Size(399, 284);
            this.MainTblLayout.TabIndex = 1;
            // 
            // ButtonsPnl
            // 
            this.ButtonsPnl.Controls.Add(this.AddBtn);
            this.ButtonsPnl.Controls.Add(this.CancelBtn);
            this.ButtonsPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPnl.Location = new System.Drawing.Point(3, 252);
            this.ButtonsPnl.Name = "ButtonsPnl";
            this.ButtonsPnl.Size = new System.Drawing.Size(393, 29);
            this.ButtonsPnl.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBtn.AutoSize = true;
            this.AddBtn.Enabled = false;
            this.AddBtn.Location = new System.Drawing.Point(234, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(315, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MainTree
            // 
            this.MainTree.ContextMenuStrip = this.TreeContextMenu;
            this.MainTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTree.Enabled = false;
            this.MainTree.HideSelection = false;
            this.MainTree.Location = new System.Drawing.Point(3, 27);
            this.MainTree.Name = "MainTree";
            this.MainTree.Size = new System.Drawing.Size(393, 219);
            this.MainTree.TabIndex = 0;
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
            this.TreeContextMenu.Size = new System.Drawing.Size(179, 142);
            this.TreeContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TreeContextMenu_ItemClicked);
            // 
            // CollapseAllMenuItem
            // 
            this.CollapseAllMenuItem.Name = "CollapseAllMenuItem";
            this.CollapseAllMenuItem.Size = new System.Drawing.Size(178, 22);
            this.CollapseAllMenuItem.Text = "Collapse All";
            // 
            // CollapseCurrentMenuItem
            // 
            this.CollapseCurrentMenuItem.Name = "CollapseCurrentMenuItem";
            this.CollapseCurrentMenuItem.Size = new System.Drawing.Size(178, 22);
            this.CollapseCurrentMenuItem.Text = "Collapse Current (-)";
            // 
            // CollapseChildrenMenuItem
            // 
            this.CollapseChildrenMenuItem.Name = "CollapseChildrenMenuItem";
            this.CollapseChildrenMenuItem.Size = new System.Drawing.Size(178, 22);
            this.CollapseChildrenMenuItem.Text = "Collapse Children";
            // 
            // ExpandCollapseMenuSeparator
            // 
            this.ExpandCollapseMenuSeparator.Name = "ExpandCollapseMenuSeparator";
            this.ExpandCollapseMenuSeparator.Size = new System.Drawing.Size(175, 6);
            // 
            // ExpandAllMenuItem
            // 
            this.ExpandAllMenuItem.Name = "ExpandAllMenuItem";
            this.ExpandAllMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ExpandAllMenuItem.Text = "Expand All";
            // 
            // ExpandCurrentMenuItem
            // 
            this.ExpandCurrentMenuItem.Name = "ExpandCurrentMenuItem";
            this.ExpandCurrentMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ExpandCurrentMenuItem.Text = "Expand Current (+)";
            // 
            // ExpandChildrenMenuItem
            // 
            this.ExpandChildrenMenuItem.Name = "ExpandChildrenMenuItem";
            this.ExpandChildrenMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ExpandChildrenMenuItem.Text = "Expand Children (*)";
            // 
            // SearchTxt
            // 
            this.SearchTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.SearchTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTxt.Enabled = false;
            this.SearchTxt.Location = new System.Drawing.Point(3, 3);
            this.SearchTxt.MaxLength = 45;
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.Size = new System.Drawing.Size(393, 20);
            this.SearchTxt.TabIndex = 1;
            this.SearchTxt.Leave += new System.EventHandler(this.SearchTxt_Leave);
            this.SearchTxt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SearchTxt_MouseUp);
            // 
            // AddTissueTypeForm
            // 
            this.AcceptButton = this.AddBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(399, 284);
            this.Controls.Add(this.MainTblLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(180, 130);
            this.Name = "AddTissueTypeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Tissue Type";
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
    }
}