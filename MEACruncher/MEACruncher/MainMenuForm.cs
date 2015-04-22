using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEACruncher {
    public partial class MainMenuForm : Form {
        public MainMenuForm() {
            InitializeComponent();
        }

        private void ExitAppButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void NewProjectButton_Click(object sender, EventArgs e) {
            new NewProjectForm().Show();
        }
    }
}
