namespace MEACruncher.Forms {
    partial class NewProjectForm {
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
            this.TitleLbl = new System.Windows.Forms.Label();
            this.DateStartedLbl = new System.Windows.Forms.Label();
            this.CommentsLbl = new System.Windows.Forms.Label();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.DateStartedPicker = new System.Windows.Forms.DateTimePicker();
            this.CommentsTxt = new System.Windows.Forms.TextBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.RedoBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 2;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.Controls.Add(this.TitleLbl, 0, 0);
            this.MainTableLayout.Controls.Add(this.DateStartedLbl, 0, 1);
            this.MainTableLayout.Controls.Add(this.CommentsLbl, 0, 2);
            this.MainTableLayout.Controls.Add(this.TitleTxt, 1, 0);
            this.MainTableLayout.Controls.Add(this.DateStartedPicker, 1, 1);
            this.MainTableLayout.Controls.Add(this.CommentsTxt, 1, 2);
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 3);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 4;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTableLayout.Size = new System.Drawing.Size(410, 208);
            this.MainTableLayout.TabIndex = 0;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(3, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(27, 13);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Title";
            // 
            // DateStartedLbl
            // 
            this.DateStartedLbl.AutoSize = true;
            this.DateStartedLbl.Location = new System.Drawing.Point(3, 26);
            this.DateStartedLbl.Name = "DateStartedLbl";
            this.DateStartedLbl.Size = new System.Drawing.Size(67, 13);
            this.DateStartedLbl.TabIndex = 0;
            this.DateStartedLbl.Text = "Date Started";
            // 
            // CommentsLbl
            // 
            this.CommentsLbl.AutoSize = true;
            this.CommentsLbl.Location = new System.Drawing.Point(3, 52);
            this.CommentsLbl.Name = "CommentsLbl";
            this.CommentsLbl.Size = new System.Drawing.Size(56, 13);
            this.CommentsLbl.TabIndex = 0;
            this.CommentsLbl.Text = "Comments";
            // 
            // TitleTxt
            // 
            this.TitleTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTxt.Location = new System.Drawing.Point(76, 3);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(331, 20);
            this.TitleTxt.TabIndex = 1;
            // 
            // DateStartedPicker
            // 
            this.DateStartedPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateStartedPicker.Location = new System.Drawing.Point(76, 29);
            this.DateStartedPicker.Name = "DateStartedPicker";
            this.DateStartedPicker.Size = new System.Drawing.Size(331, 20);
            this.DateStartedPicker.TabIndex = 2;
            // 
            // CommentsTxt
            // 
            this.CommentsTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsTxt.Location = new System.Drawing.Point(76, 55);
            this.CommentsTxt.Multiline = true;
            this.CommentsTxt.Name = "CommentsTxt";
            this.CommentsTxt.Size = new System.Drawing.Size(331, 115);
            this.CommentsTxt.TabIndex = 3;
            // 
            // BottomPanel
            // 
            this.MainTableLayout.SetColumnSpan(this.BottomPanel, 2);
            this.BottomPanel.Controls.Add(this.CreateBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Controls.Add(this.RedoBtn);
            this.BottomPanel.Controls.Add(this.UndoBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(3, 176);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(404, 29);
            this.BottomPanel.TabIndex = 4;
            // 
            // UndoBtn
            // 
            this.UndoBtn.Location = new System.Drawing.Point(3, 3);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(75, 23);
            this.UndoBtn.TabIndex = 0;
            this.UndoBtn.Text = "Undo";
            this.UndoBtn.UseVisualStyleBackColor = true;
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // RedoBtn
            // 
            this.RedoBtn.Location = new System.Drawing.Point(84, 3);
            this.RedoBtn.Name = "RedoBtn";
            this.RedoBtn.Size = new System.Drawing.Size(75, 23);
            this.RedoBtn.TabIndex = 0;
            this.RedoBtn.Text = "Redo";
            this.RedoBtn.UseVisualStyleBackColor = true;
            this.RedoBtn.Click += new System.EventHandler(this.RedoBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(326, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 0;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateBtn.Location = new System.Drawing.Point(245, 3);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateBtn.TabIndex = 0;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.CreateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(410, 208);
            this.Controls.Add(this.MainTableLayout);
            this.MinimumSize = new System.Drawing.Size(350, 175);
            this.Name = "NewProjectForm";
            this.Text = "Create A New Project";
            this.MainTableLayout.ResumeLayout(false);
            this.MainTableLayout.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label DateStartedLbl;
        private System.Windows.Forms.Label CommentsLbl;
        private System.Windows.Forms.TextBox TitleTxt;
        private System.Windows.Forms.DateTimePicker DateStartedPicker;
        private System.Windows.Forms.TextBox CommentsTxt;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button RedoBtn;
        private System.Windows.Forms.Button UndoBtn;
    }
}