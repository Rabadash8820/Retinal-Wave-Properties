namespace MEACruncher.Forms {
    partial class AddEntitiesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEntitiesForm));
            this.EntitiesDGV = new System.Windows.Forms.DataGridView();
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelAddButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).BeginInit();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.EntitiesDGV.Size = new System.Drawing.Size(750, 387);
            this.EntitiesDGV.TabIndex = 1;
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
            this.MainTableLayout.Size = new System.Drawing.Size(756, 428);
            this.MainTableLayout.TabIndex = 1;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.AddButton);
            this.BottomPanel.Controls.Add(this.CancelAddButton);
            this.BottomPanel.Controls.Add(this.NewButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 396);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(750, 29);
            this.BottomPanel.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.AutoSize = true;
            this.AddButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.AddButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.AddButton.Location = new System.Drawing.Point(591, -1);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 31);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
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
            this.CancelAddButton.Location = new System.Drawing.Point(672, -1);
            this.CancelAddButton.Name = "CancelAddButton";
            this.CancelAddButton.Size = new System.Drawing.Size(75, 31);
            this.CancelAddButton.TabIndex = 0;
            this.CancelAddButton.Text = "Cancel";
            this.CancelAddButton.UseVisualStyleBackColor = false;
            // 
            // NewButton
            // 
            this.NewButton.AutoSize = true;
            this.NewButton.BackColor = global::MEACruncher.Properties.Settings.Default.ButtonBackColor;
            this.NewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewButton.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.NewButton.ForeColor = global::MEACruncher.Properties.Settings.Default.ButtonForeColor;
            this.NewButton.Location = new System.Drawing.Point(510, -1);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 31);
            this.NewButton.TabIndex = 0;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = false;
            // 
            // AddEntitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::MEACruncher.Properties.Settings.Default.FormBackColor;
            this.ClientSize = new System.Drawing.Size(756, 428);
            this.Controls.Add(this.MainTableLayout);
            this.Font = global::MEACruncher.Properties.Settings.Default.ControlFont;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "AddEntitiesForm";
            this.Text = "AddEntitiesForm";
            ((System.ComponentModel.ISupportInitialize)(this.EntitiesDGV)).EndInit();
            this.MainTableLayout.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        protected System.Windows.Forms.DataGridView EntitiesDGV;
        protected System.Windows.Forms.Panel BottomPanel;
        protected System.Windows.Forms.Button AddButton;
        protected System.Windows.Forms.Button CancelAddButton;
        protected System.Windows.Forms.Button NewButton;
    }
}