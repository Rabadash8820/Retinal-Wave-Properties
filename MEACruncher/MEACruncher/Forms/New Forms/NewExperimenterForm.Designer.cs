namespace MEACruncher.Forms {
    partial class NewExperimenterForm {
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
            this.EmailLabel = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.CommentsLabel = new System.Windows.Forms.Label();
            this.CommentsTextbox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelCreateButton = new System.Windows.Forms.Button();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.PhoneTextbox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(3, 29);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(3);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(61, 13);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Work Email";
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTextbox.Location = new System.Drawing.Point(76, 3);
            this.TitleTextbox.MaxLength = 50;
            this.TitleTextbox.Multiline = true;
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(380, 20);
            this.TitleTextbox.TabIndex = 0;
            this.TitleTextbox.Text = "Project1";
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Location = new System.Drawing.Point(3, 3);
            this.FullNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(54, 13);
            this.FullNameLabel.TabIndex = 0;
            this.FullNameLabel.Text = "Full Name";
            // 
            // CommentsLabel
            // 
            this.CommentsLabel.AutoSize = true;
            this.CommentsLabel.Location = new System.Drawing.Point(3, 81);
            this.CommentsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CommentsLabel.Name = "CommentsLabel";
            this.CommentsLabel.Size = new System.Drawing.Size(56, 13);
            this.CommentsLabel.TabIndex = 4;
            this.CommentsLabel.Text = "Comments";
            // 
            // CommentsTextbox
            // 
            this.CommentsTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsTextbox.Location = new System.Drawing.Point(76, 81);
            this.CommentsTextbox.Multiline = true;
            this.CommentsTextbox.Name = "CommentsTextbox";
            this.CommentsTextbox.Size = new System.Drawing.Size(380, 141);
            this.CommentsTextbox.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.FullNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EmailLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CommentsLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TitleTextbox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CommentsTextbox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PhoneLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.EmailTextbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PhoneTextbox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 260);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.CreateButton);
            this.panel1.Controls.Add(this.CancelCreateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 29);
            this.panel1.TabIndex = 14;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.Location = new System.Drawing.Point(288, 3);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelCreateButton
            // 
            this.CancelCreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCreateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCreateButton.Location = new System.Drawing.Point(369, 3);
            this.CancelCreateButton.Name = "CancelCreateButton";
            this.CancelCreateButton.Size = new System.Drawing.Size(75, 23);
            this.CancelCreateButton.TabIndex = 1;
            this.CancelCreateButton.Text = "Cancel";
            this.CancelCreateButton.UseVisualStyleBackColor = true;
            this.CancelCreateButton.Click += new System.EventHandler(this.CancelCreateButton_Click);
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(3, 55);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(3);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(67, 13);
            this.PhoneLabel.TabIndex = 2;
            this.PhoneLabel.Text = "Work Phone";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmailTextbox.Location = new System.Drawing.Point(76, 29);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(380, 20);
            this.EmailTextbox.TabIndex = 15;
            // 
            // PhoneTextbox
            // 
            this.PhoneTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhoneTextbox.Location = new System.Drawing.Point(76, 55);
            this.PhoneTextbox.Name = "PhoneTextbox";
            this.PhoneTextbox.Size = new System.Drawing.Size(380, 20);
            this.PhoneTextbox.TabIndex = 15;
            // 
            // NewExperimenterForm
            // 
            this.AcceptButton = this.CreateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelCreateButton;
            this.ClientSize = new System.Drawing.Size(459, 260);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "NewExperimenterForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Project";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label CommentsLabel;
        private System.Windows.Forms.TextBox CommentsTextbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelCreateButton;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox PhoneTextbox;
    }
}