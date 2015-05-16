namespace MEACruncher.Forms.AddForms {
    partial class AddExperimentersForm {
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
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.EntitiesDGV = new System.Windows.Forms.DataGridView();
            this.FullNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CancelAddButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
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
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayout.Size = new System.Drawing.Size(516, 283);
            this.MainTableLayout.TabIndex = 0;
            // 
            // EntitiesDGV
            // 
            this.EntitiesDGV.AllowUserToAddRows = false;
            this.EntitiesDGV.AllowUserToDeleteRows = false;
            this.EntitiesDGV.BackgroundColor = global::MEACruncher.Properties.Settings.Default.DgvBackColor;
            this.EntitiesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntitiesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.EntitiesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntitiesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullNameColumn,
            this.EmailColumn,
            this.PhoneColumn,
            this.CommentsColumn});
            this.EntitiesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntitiesDGV.EnableHeadersVisualStyles = false;
            this.EntitiesDGV.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.EntitiesDGV.GridColor = global::MEACruncher.Properties.Settings.Default.DgvGridColor;
            this.EntitiesDGV.Location = new System.Drawing.Point(3, 3);
            this.EntitiesDGV.Name = "EntitiesDGV";
            this.EntitiesDGV.ReadOnly = true;
            this.EntitiesDGV.RowHeadersVisible = false;
            this.EntitiesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EntitiesDGV.Size = new System.Drawing.Size(510, 242);
            this.EntitiesDGV.TabIndex = 1;
            // 
            // FullNameColumn
            // 
            this.FullNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullNameColumn.HeaderText = "Full Name";
            this.FullNameColumn.MaxInputLength = 30;
            this.FullNameColumn.Name = "FullNameColumn";
            this.FullNameColumn.ReadOnly = true;
            this.FullNameColumn.Width = 94;
            // 
            // EmailColumn
            // 
            this.EmailColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmailColumn.HeaderText = "Work Email";
            this.EmailColumn.MaxInputLength = 25;
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            this.EmailColumn.Width = 102;
            // 
            // PhoneColumn
            // 
            this.PhoneColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PhoneColumn.HeaderText = "Work Phone";
            this.PhoneColumn.MaxInputLength = 15;
            this.PhoneColumn.Name = "PhoneColumn";
            this.PhoneColumn.ReadOnly = true;
            this.PhoneColumn.Width = 109;
            // 
            // CommentsColumn
            // 
            this.CommentsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";
            this.CommentsColumn.ReadOnly = true;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CancelAddButton);
            this.BottomPanel.Controls.Add(this.AddButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 251);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(510, 29);
            this.BottomPanel.TabIndex = 0;
            // 
            // CancelAddButton
            // 
            this.CancelAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelAddButton.AutoSize = true;
            this.CancelAddButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.CancelAddButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelAddButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.CancelAddButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.CancelAddButton.Location = new System.Drawing.Point(432, -1);
            this.CancelAddButton.Name = "CancelAddButton";
            this.CancelAddButton.Size = new System.Drawing.Size(75, 31);
            this.CancelAddButton.TabIndex = 0;
            this.CancelAddButton.Text = "Cancel";
            this.CancelAddButton.UseVisualStyleBackColor = false;
            this.CancelAddButton.Click += new System.EventHandler(this.CancelAddButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.AutoSize = true;
            this.AddButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.AddButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.AddButton.Location = new System.Drawing.Point(351, -1);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 31);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddExperimentersForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.CancelButton = this.CancelAddButton;
            this.ClientSize = new System.Drawing.Size(516, 283);
            this.Controls.Add(this.MainTableLayout);
            this.MinimizeBox = false;
            this.Name = "AddExperimentersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add Experimenters";
            this.MainTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CancelAddButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView EntitiesDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsColumn;
    }
}