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
        private static AutoCompleteStringCollection _autoStrings;
        private static TreeNode[] _nodes;
        private static bool _loaded = false;

        public event EventHandler<EntitySelectedEventArgs> TissueTypeSelected;

        // CONSTRUCTORS
        public AddTissueTypeForm() {
            InitializeComponent();

            toggleLoadControls(false);

            // Asynchronously load TissueTypes and add them to the TreeView
            LoadEntityWorker.RunWorkerAsync();
        }
        
        // EVENT HANDLERS
        private void LoadEntityWorker_DoWork(object sender, DoWorkEventArgs e) {
            loadEntities(e);
        }
        private void LoadEntityWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            // Rethrow any errors, just return if work was cancelled
            if (e.Error != null)
                throw e.Error;
            if (e.Cancelled)
                return;

            // Use the names of the TissueTypes as autocomplete suggestions in the search box
            SearchTxt.AutoCompleteCustomSource = _autoStrings;

            // Update GUI
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
        private void MainTree_AfterSelect(object sender, TreeViewEventArgs e) {
            AddBtn.Enabled = true;
        }
        private void MainTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            // Allow the user to change selected node by clicking either mouse button
            if (e.Button == MouseButtons.Right)
                MainTree.SelectedNode = e.Node;
        }
        private void SearchTxt_Enter(object sender, EventArgs e) {
            SearchTxt.SelectAll();
            SearchTxt.Focus();
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
            Close();
        }
        private void AddTissueTypeForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Don't let the static array of TreeNodes maintain references to this instance of the TreeView
            MainTree.Nodes.Clear();
        }

        // HELPER FUNCTIONS
        private void loadEntities(DoWorkEventArgs args) {
            if (_loaded)
                return;

            // Load TissueTypes from the database
            IList<TissueType> entities = null;
            if (!LoadEntityWorker.CancellationPending) {
                entities = _db.QueryOver<TissueType>()
                              .OrderBy(e => e.Name).Asc
                              .List();
            }

            // Cache the names of the TissueTypes as autocomplete suggestions for the search box
            if (!LoadEntityWorker.CancellationPending) {
                _autoStrings = new AutoCompleteStringCollection();
                _autoStrings.AddRange(entities.Select(tt => tt.Name).ToArray());
            }

            // Wrap these TissueTypes in TreeNodes and add them to the TreeView
            if (!LoadEntityWorker.CancellationPending) {
                _nodes = entities.Where(tt => tt.Parent == null)
                                 .OrderBy(tt => tt.Name)
                                 .Select(tt => createNode(tt))
                                 .ToArray();
            }

            // Determine whether loading was cancelled or successfully completed
            if (LoadEntityWorker.CancellationPending)
                args.Cancel = true;
            else
                _loaded = true;
        }
        private void toggleLoadControls(bool loaded) {
            // Enable/disable controls
            SearchTxt.Enabled = loaded;
            MainTree.Enabled = loaded;
            AddBtn.Enabled = false;

            // Add the appropriate nodes to the TreeView
            MainTree.BeginUpdate();
            MainTree.Nodes.Clear();
            if (loaded)
                MainTree.Nodes.AddRange(_nodes);
            else
                MainTree.Nodes.Add(Properties.Resources.LoadingStr);
            MainTree.EndUpdate();

            // Set the focused control
            if (loaded)
                MainTree.Focus();
            else
                CancelBtn.Focus();
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
