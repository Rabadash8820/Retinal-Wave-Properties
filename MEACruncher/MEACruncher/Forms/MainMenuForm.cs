using System;
using System.Windows.Forms;
using MEACruncher.Forms.ViewForms;

namespace MEACruncher.Forms {

    internal partial class MainMenuForm : Form {
        public MainMenuForm() {
            InitializeComponent();
        }

        private void ExitAppButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void LoadProjectButton_Click(object sender, EventArgs e) {
            new ViewProjectsForm().ShowDialog();
        }

        private void ExperimentersButton_Click(object sender, EventArgs e) {
            new ViewExperimentersForm().ShowDialog();
        }
    }

}