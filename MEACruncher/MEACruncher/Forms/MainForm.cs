using System;
using System.Windows.Forms;

namespace MEACruncher.Forms {

    public partial class MainForm : Form {
        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.FormClosed += mainMenuForm_FormClosed;
            mainMenuForm.ShowDialog();
        }

        void mainMenuForm_FormClosed(object sender, FormClosedEventArgs e) {
            this.Close();
        }
    }

}