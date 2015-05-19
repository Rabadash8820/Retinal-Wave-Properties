namespace MEACruncher.Forms.ViewForms {
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
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.EntitiesDGV = new System.Windows.Forms.DataGridView();
            this.TitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateStartedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.NewButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 1;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.EntitiesDGV, 0, 0);
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 2;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayout.Size = new System.Drawing.Size(510, 236);
            this.MainTableLayout.TabIndex = 1;
            // 
            // EntitiesDGV
            // 
            this.EntitiesDGV.AllowUserToAddRows = false;
            this.EntitiesDGV.BackgroundColor = global::MEACruncher.Properties.Settings.Default.DgvBackColor;
            this.EntitiesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntitiesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.EntitiesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntitiesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleColumn,
            this.DateStartedColumn,
            this.CommentsColumn});
            this.EntitiesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntitiesDGV.EnableHeadersVisualStyles = false;
            this.EntitiesDGV.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.EntitiesDGV.GridColor = global::MEACruncher.Properties.Settings.Default.DgvGridColor;
            this.EntitiesDGV.Location = new System.Drawing.Point(3, 3);
            this.EntitiesDGV.MultiSelect = false;
            this.EntitiesDGV.Name = "EntitiesDGV";
            this.EntitiesDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.EntitiesDGV.Size = new System.Drawing.Size(504, 195);
            this.EntitiesDGV.TabIndex = 0;
            this.EntitiesDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntitiesDGV_CellDoubleClick);
            this.EntitiesDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EntitiesDGV_CellFormatting);
            this.EntitiesDGV.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EntitiesDGV_CellValidating);
            this.EntitiesDGV.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntitiesDGV_RowValidated);
            this.EntitiesDGV.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EntitiesDGV_RowValidating);
            this.EntitiesDGV.SelectionChanged += new System.EventHandler(this.EntitiesDGV_SelectionChanged);
            this.EntitiesDGV.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.EntitiesDGV_UserDeletingRow);
            // 
            // TitleColumn
            // 
            this.TitleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TitleColumn.HeaderText = "Title";
            this.TitleColumn.MaxInputLength = 25;
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.Width = 58;
            // 
            // DateStartedColumn
            // 
            this.DateStartedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateStartedColumn.HeaderText = "Date Started";
            this.DateStartedColumn.Name = "DateStartedColumn";
            this.DateStartedColumn.Width = 110;
            // 
            // CommentsColumn
            // 
            this.CommentsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.NewButton);
            this.BottomPanel.Controls.Add(this.DeleteButton);
            this.BottomPanel.Controls.Add(this.EditButton);
            this.BottomPanel.Controls.Add(this.CloseButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 204);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(504, 29);
            this.BottomPanel.TabIndex = 1;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.AutoSize = true;
            this.NewButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.NewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.NewButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.NewButton.Location = new System.Drawing.Point(177, -1);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 31);
            this.NewButton.TabIndex = 0;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = false;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.AutoSize = true;
            this.DeleteButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.DeleteButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.DeleteButton.Location = new System.Drawing.Point(339, -1);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.AutoSize = true;
            this.EditButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.EditButton.Enabled = false;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.EditButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.EditButton.Location = new System.Drawing.Point(258, -1);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 31);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.AutoSize = true;
            this.CloseButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CloseButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.CloseButton.Location = new System.Drawing.Point(420, -1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 31);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            // 
            // ViewProjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(510, 236);
            this.Controls.Add(this.MainTableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 150);
            this.Name = "ViewProjectsForm";
            this.ShowInTaskbar = false;
            this.Text = "Projects";
            this.MainTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.DataGridView EntitiesDGV;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateStartedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;

    }
}