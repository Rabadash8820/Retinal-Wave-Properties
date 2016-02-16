namespace MEACruncher.Forms {
    partial class BaseForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.MainWorker = new System.ComponentModel.BackgroundWorker();
            this.EntityBS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).BeginInit();
            this.SuspendLayout();
            // 
            // MainWorker
            // 
            this.MainWorker.WorkerReportsProgress = true;
            this.MainWorker.WorkerSupportsCancellation = true;
            // 
            // BaseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.EntityBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.ComponentModel.BackgroundWorker MainWorker;
        protected System.Windows.Forms.BindingSource EntityBS;
    }
}