namespace MEACruncher.Forms {
    partial class ViewEntitiesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewEntitiesForm));
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.NewButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.EntitiesDGV = new System.Windows.Forms.DataGridView();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 1;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayout.Controls.Add(this.EntitiesDGV, 0, 0);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 2;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayout.Size = new System.Drawing.Size(627, 328);
            this.MainTableLayout.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.NewButton);
            this.BottomPanel.Controls.Add(this.EditButton);
            this.BottomPanel.Controls.Add(this.DeleteButton);
            this.BottomPanel.Controls.Add(this.CloseButton);
            this.BottomPanel.Controls.Add(this.RedoButton);
            this.BottomPanel.Controls.Add(this.UndoButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 296);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(621, 29);
            this.BottomPanel.TabIndex = 0;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.AutoSize = true;
            this.NewButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.NewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.NewButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.NewButton.Location = new System.Drawing.Point(300, -1);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 31);
            this.NewButton.TabIndex = 0;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = false;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
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
            this.EditButton.Location = new System.Drawing.Point(381, -1);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 31);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
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
            this.DeleteButton.Location = new System.Drawing.Point(462, -1);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(543, -1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 31);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            // 
            // RedoButton
            // 
            this.RedoButton.AutoSize = true;
            this.RedoButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.RedoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedoButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.RedoButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.RedoButton.Location = new System.Drawing.Point(84, -1);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(75, 31);
            this.RedoButton.TabIndex = 0;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = false;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.AutoSize = true;
            this.UndoButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.UndoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UndoButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.UndoButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.UndoButton.Location = new System.Drawing.Point(3, -1);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 31);
            this.UndoButton.TabIndex = 0;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = false;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // EntitiesDGV
            // 
            this.EntitiesDGV.AllowUserToAddRows = false;
            this.EntitiesDGV.BackgroundColor = global::MEACruncher.Properties.Settings.Default.DgvBackColor;
            this.EntitiesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntitiesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntitiesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntitiesDGV.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.EntitiesDGV.GridColor = global::MEACruncher.Properties.Settings.Default.DgvGridColor;
            this.EntitiesDGV.Location = new System.Drawing.Point(3, 3);
            this.EntitiesDGV.Name = "EntitiesDGV";
            this.EntitiesDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.EntitiesDGV.Size = new System.Drawing.Size(621, 287);
            this.EntitiesDGV.TabIndex = 1;
            // 
            // ViewEntitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(627, 328);
            this.Controls.Add(this.MainTableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ViewEntitiesForm";
            this.Text = "ViewEntitiesForm";
            this.MainTableLayout.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel MainTableLayout;
        protected System.Windows.Forms.Panel BottomPanel;
        protected System.Windows.Forms.Button DeleteButton;
        protected System.Windows.Forms.Button CloseButton;
        protected System.Windows.Forms.Button RedoButton;
        protected System.Windows.Forms.Button UndoButton;
        protected System.Windows.Forms.Button NewButton;
        protected System.Windows.Forms.Button EditButton;
        protected System.Windows.Forms.DataGridView EntitiesDGV;

    }
}