using System;
using System.Windows.Forms;

namespace MEACruncher {
    public partial class MainMenuForm : Form {
        public MainMenuForm() {
            InitializeComponent();
        }

        private void ExitAppButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void LoadProjectButton_Click(object sender, EventArgs e) {
            new ViewProjectsForm().Show();
        }
    }
}
