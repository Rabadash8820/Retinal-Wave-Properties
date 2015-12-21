using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using MeaData;
using MEACruncher.Events;

namespace MEACruncher.Forms {

    internal partial class AddTissueTypeForm : BaseForm {
        private static TreeNode[] _nodes;
        private static bool _loaded = false;

        public event EventHandler<EntitySelectedEventArgs> TissueTypeSelected;

        // CONSTRUCTORS
        public AddTissueTypeForm() {
            InitializeComponent();

            toggleLoadControls(false);

            // Set up the background worker and run it
            LoadEntityWorker.DoWork += LoadEntityWorker_DoWork;
            LoadEntityWorker.RunWorkerCompleted += LoadEntityWorker_RunWorkerCompleted;
            LoadEntityWorker.RunWorkerAsync();
        }


        // EVENT HANDLERS
        private void LoadEntityWorker_DoWork(object sender, DoWorkEventArgs e) {
            loadEntities(e);
        }
        private void LoadEntityWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            toggleLoadControls(true);
        }
        private void TreeContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            ToolStripItem item = e.ClickedItem;

            // Expand/collapse TreeView nodes
            if (item == CollapseAllMenuItem)
                collapseAll();
            else if (item == ExpandAllMenuItem)
                expandAll();
            else if (item == CollapseCurrentMenuItem)
                collapseCurrent();
            else if (item == ExpandCurrentMenuItem)
                expandCurrent();
            else if (item == CollapseChildrenMenuItem)
                collapseCurrent();
            else if (item == ExpandChildrenMenuItem)
                expandChildren();

            else
                throw new NotImplementedException();
        }
        private void MainTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            // Allow the user to change selected node by clicking either mouse button
            if (e.Button == MouseButtons.Right)
                MainTree.SelectedNode = e.Node;
        }
        private void AddBtn_Click(object sender, EventArgs e) {
            // Fire the TissueTypeSelected
            TissueType tt = MainTree.SelectedNode.Tag as TissueType;
            EntitySelectedEventArgs args = new EntitySelectedEventArgs(tt);
            OnTissueTypeSelected(args);

            // Close the Form
            Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            LoadEntityWorker.CancelAsync();
        }
        private void AddTissueTypeForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Don't let the static array of TreeNodes maintain references to this instance of the TreeView
            MainTree.Nodes.Clear();
        }

        // HELPER FUNCTIONS
        private void loadEntities(DoWorkEventArgs e) {
            if (_loaded)
                return;

            // Load TissueTypes from the database
            if (e.Cancel) return;
            IList<TissueType> entities = _db.QueryOver<TissueType>()
                                            .OrderBy(tt => tt.Name).Asc
                                            .List();

            // Wrap these TissueTypes in TreeNodes and add them to the TreeView
            if (e.Cancel) return;
            _nodes = entities.Where(tt => tt.Parent == null)
                             .OrderBy(tt => tt.Name)
                             .Select(tt => createNode(tt))
                             .ToArray();

            if (e.Cancel) return;
            _loaded = true;
        }
        private void toggleLoadControls(bool loaded) {
            // Enable/disable controls
            SearchTxt.Enabled = loaded;
            MainTree.Enabled = loaded;
            AddBtn.Enabled = loaded;

            // Add the appropriate nodes to the TreeView
            MainTree.BeginUpdate();
            MainTree.Nodes.Clear();
            if (loaded)
                MainTree.Nodes.AddRange(_nodes);
            else
                MainTree.Nodes.Add(Properties.Resources.LoadingStr);
            MainTree.EndUpdate();
        }
        private TreeNode createNode(TissueType tissueType) {
            // Define the node for this TissueType
            TreeNode node = new TreeNode();
            node.Text = tissueType.Name;
            node.Tag = tissueType;

            // Add sub nodes for all of its child TissueTypes, sorted alphabetically
            node.Nodes.AddRange(
                tissueType.Children
                          .OrderBy(tt => tt.Name)
                          .Select(tt => createNode(tt))
                          .ToArray()
            );

            return node;
        }
        private void collapseAll() {
            MainTree.CollapseAll();
        }
        private void expandAll() {
            MainTree.ExpandAll();
        }
        private void collapseCurrent() {
            MainTree.SelectedNode.Collapse(true);
        }
        private void expandCurrent() {
            MainTree.SelectedNode.Expand();
        }
        private void collapseChildren() {
            MainTree.SelectedNode.Collapse(false);
        }
        private void expandChildren() {
            MainTree.SelectedNode.ExpandAll();
        }
        private void OnTissueTypeSelected(EntitySelectedEventArgs args) {
            TissueTypeSelected?.Invoke(this, args);
        }

    }

}
