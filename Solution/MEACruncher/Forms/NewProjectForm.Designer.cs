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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.DateStartedLbl = new System.Windows.Forms.Label();
            this.CommentsLbl = new System.Windows.Forms.Label();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.DateStartedPicker = new System.Windows.Forms.DateTimePicker();
            this.CommentsTxt = new System.Windows.Forms.TextBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).BeginInit();
            this.MainTableLayout.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            resources.ApplyResources(this.MainTableLayout, "MainTableLayout");
            this.MainTableLayout.Controls.Add(this.TitleLbl, 0, 0);
            this.MainTableLayout.Controls.Add(this.DateStartedLbl, 0, 1);
            this.MainTableLayout.Controls.Add(this.CommentsLbl, 0, 2);
            this.MainTableLayout.Controls.Add(this.TitleTxt, 1, 0);
            this.MainTableLayout.Controls.Add(this.DateStartedPicker, 1, 1);
            this.MainTableLayout.Controls.Add(this.CommentsTxt, 1, 2);
            this.MainTableLayout.Controls.Add(this.BottomPanel, 0, 3);
            this.MainTableLayout.Name = "MainTableLayout";
            // 
            // TitleLbl
            // 
            resources.ApplyResources(this.TitleLbl, "TitleLbl");
            this.TitleLbl.Name = "TitleLbl";
            // 
            // DateStartedLbl
            // 
            resources.ApplyResources(this.DateStartedLbl, "DateStartedLbl");
            this.DateStartedLbl.Name = "DateStartedLbl";
            // 
            // CommentsLbl
            // 
            resources.ApplyResources(this.CommentsLbl, "CommentsLbl");
            this.CommentsLbl.Name = "CommentsLbl";
            // 
            // TitleTxt
            // 
            resources.ApplyResources(this.TitleTxt, "TitleTxt");
            this.TitleTxt.Name = "TitleTxt";
            // 
            // DateStartedPicker
            // 
            resources.ApplyResources(this.DateStartedPicker, "DateStartedPicker");
            this.DateStartedPicker.Name = "DateStartedPicker";
            // 
            // CommentsTxt
            // 
            resources.ApplyResources(this.CommentsTxt, "CommentsTxt");
            this.CommentsTxt.Name = "CommentsTxt";
            // 
            // BottomPanel
            // 
            this.MainTableLayout.SetColumnSpan(this.BottomPanel, 2);
            this.BottomPanel.Controls.Add(this.CreateBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            resources.ApplyResources(this.BottomPanel, "BottomPanel");
            this.BottomPanel.Name = "BottomPanel";
            // 
            // CreateBtn
            // 
            resources.ApplyResources(this.CreateBtn, "CreateBtn");
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // CancelBtn
            // 
            resources.ApplyResources(this.CancelBtn, "CancelBtn");
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.CreateBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.Controls.Add(this.MainTableLayout);
            this.MinimizeBox = false;
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).EndInit();
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
    }
}