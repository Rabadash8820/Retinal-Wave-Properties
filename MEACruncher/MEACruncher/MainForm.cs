using System;
using System.Windows.Forms;

namespace MEACruncher {

    public partial class MainForm : Form {
        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            new MainMenuForm().Show();
        }
    }

}