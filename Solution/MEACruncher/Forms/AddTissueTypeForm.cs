using System;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using MeaData;
using MEACruncher.Events;
using Mea = MEACruncher.Properties;

namespace MEACruncher.Forms {

    internal partial class AddTissueTypeForm : BaseForm {
        // HIDDEN FIELDS
        private static AutoCompleteStringCollection _autoStrings;
        private static TreeNode[] _nodes;
        private static bool _loaded = false;
        private bool _searchFocused;

        // EVENTS
        public event EventHandler<EntitySelectedEventArgs> TissueTypeSelected;

        // CONSTRUCTORS
        public AddTissueTypeForm() {
            InitializeComponent();

            // Keep these before running the BackgroundWorker, to prevent races on enabling/disabling controls
            toggleLoadControls(false);
            toggleSelectionCtrls(false);

            // Asynchronously add TissueTypes data to the TreeView
            LoadEntityWorker.RunWorkerAsync();

            SearchTxt.GotFocus    += SearchTxt_GotFocus;        // Don't know why this event isn't available in the Designer...
            SearchTxt.TextChanged += SearchTxt_TextChanged;     // This will need to be dynamically registered/unregistered
        }

        // EVENT HANDLERS
        private void LoadEntityWorker_DoWork(object sender, DoWorkEventArgs e) {
            loadNodes(e);
        }
        private void LoadEntityWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            // Rethrow any errors, just return if work was cancelled
            if (e.Error != null)
                throw e.Error;
            if (e.Cancelled)
                return;

            // Use the names of the TissueTypes as autocomplete suggestions in the search box
            //SearchTxt.AutoCompleteCustomSource = _autoStrings;

            // Update GUI
            toggleLoadControls(true);
        }
        private void TreeContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            ToolStripItem item = e.ClickedItem;

            // Expand/collapse TreeView nodes
            if (item == CollapseAllMenuItem)
                MainTree.CollapseAll();
            else if (item == ExpandAllMenuItem)
                MainTree.ExpandAll();
            else if (item == CollapseCurrentMenuItem)
                MainTree.SelectedNode.Collapse(true);
            else if (item == ExpandCurrentMenuItem)
                MainTree.SelectedNode.Expand();
            else if (item == CollapseChildrenMenuItem)
                MainTree.SelectedNode.Collapse(false);
            else if (item == ExpandChildrenMenuItem)
                MainTree.SelectedNode.ExpandAll();

            else
                throw new NotImplementedException();
        }
        private void MainTree_AfterSelect(object sender, TreeViewEventArgs e) {
            TissueType tt = e.Node.Tag as TissueType;
            toggleSelectionCtrls(tt.IsSelectable);
            if (!tt.IsSelectable)
                InfoLbl.Text = Mea.Resources.GeneralTissueTypeWarning;
        }
        private void MainTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            // Allow the user to change selected node by clicking either mouse button
            if (e.Button == MouseButtons.Right)
                MainTree.SelectedNode = e.Node;
        }
        private void SearchTxt_Leave(object sender, EventArgs e) {
            _searchFocused = false;

            // If the Textbox is now empty, reset it with a prompt string
            if (SearchTxt.Text == "") {
                SearchTxt.TextChanged -= SearchTxt_TextChanged;
                SearchTxt.Text = $"{Mea.Resources.SearchStr}...";
                SearchTxt.TextChanged += SearchTxt_TextChanged;
            }
        }
        private void SearchTxt_GotFocus(object sender, EventArgs e) {
            // Select all text only if the mouse isn't down.
            // This lets tabbing to the textbox give focus.
            if (MouseButtons == MouseButtons.None) {
                SearchTxt.SelectAll();
                _searchFocused = true;
            }
        }
        private void SearchTxt_MouseUp(object sender, MouseEventArgs e) {
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            if (!_searchFocused && SearchTxt.SelectionLength == 0) {
                _searchFocused = true;
                SearchTxt.SelectAll();
            }
        }
        private void SearchTxt_TextChanged(object sender, EventArgs e) {
            // Get TreeNodes for all the TissueTypes whose names match the search string
            // Or, if no search string was given, get the cached TreeNodes
            string query = SearchTxt.Text;
            bool queryGiven = (query != "");
            TreeNode[] nodes = (queryGiven ? matchingNodes(query) : _nodes);

            // Refresh the TreeView with only these nodes
            MainTree.Nodes.Clear();
            MainTree.Nodes.AddRange(nodes);

            toggleSelectionCtrls(false);
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
        private void loadNodes(DoWorkEventArgs args) {
            if (_loaded)
                return;

            // Cache the names of the TissueTypes as autocomplete suggestions for the search box
            IList<TissueType> tissueTypes = Program.TissueTypes;
            if (!LoadEntityWorker.CancellationPending) {
                _autoStrings = new AutoCompleteStringCollection();
                _autoStrings.AddRange(tissueTypes.Select(tt => tt.Name).ToArray());
            }

            // Wrap these TissueTypes in TreeNodes and add them to the TreeView
            if (!LoadEntityWorker.CancellationPending) {
                _nodes = tissueTypes.Where(tt => tt.Parent == null)
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

            // Add the appropriate nodes to the TreeView and adjust it
            MainTree.BeginUpdate();
            MainTree.Nodes.Clear();
            if (loaded) {
                MainTree.Nodes.AddRange(_nodes);
                MainTree.CollapseAll();
                MainTree.Nodes[0].EnsureVisible();
                MainTree.SelectedNode = null;
            }
            else
                MainTree.Nodes.Add($"{Mea.Resources.LoadingStr}...");
            MainTree.EndUpdate();

            // Adjust the search box text
            SearchTxt.Text = $"{Mea.Resources.SearchStr}...";

            // Set the focused control
            if (loaded)
                SearchTxt.Select();
            else
                CancelBtn.Select();
        }
        private void toggleSelectionCtrls(bool nodeSelected) {
            AddBtn.Enabled = nodeSelected;
            InfoLbl.Text = (nodeSelected ? "" : Mea.Resources.NoTissueTypeWarning);
        }
        private TreeNode createNode(TissueType tissueType) {
            // Define the node for this TissueType
            TreeNode node = new TreeNode {
                Text = tissueType.Name,
                Tag = tissueType
            };

            // Add sub nodes for all of its child TissueTypes, sorted alphabetically
            node.Nodes.AddRange(
                tissueType.Children
                          .OrderBy(tt => tt.Name)
                          .Select(tt => createNode(tt))
                          .ToArray()
            );

            return node;
        }
        private TreeNode[] matchingNodes(string query) {
            int length = query.Length;
            CompareInfo ci = CultureInfo.InvariantCulture.CompareInfo;
            TreeNode[] nodes = Program.TissueTypes.Where(tt =>
                                            tt.IsSelectable &&
                                            ci.IndexOf(tt.Name, query, CompareOptions.IgnoreCase) != -1)
                                       .Select(tt =>
                                            new TreeNode() { Text = tt.Name, Tag = tt })
                                       .ToArray();
            return nodes;
        }
        private void OnTissueTypeSelected(EntitySelectedEventArgs args) {
            TissueTypeSelected?.Invoke(this, args);
        }

    }

}
