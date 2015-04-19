using System.Windows.Forms;

namespace MEACruncher {

    public partial class MainForm : Form {
        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, System.EventArgs e) {
            this.Close();
        }

        private void NewButton_Click(object sender, System.EventArgs e) {
            new NewProjectForm().Show();
        }
    }

}