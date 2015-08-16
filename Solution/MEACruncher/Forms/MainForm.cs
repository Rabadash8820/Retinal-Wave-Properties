﻿using System;
using System.Drawing;
using System.Windows.Forms;

using MEACruncher.Properties;

namespace MEACruncher.Forms {

    internal partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        private double _aspectRatio;

        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();

            _aspectRatio = (double)this.Height / (double)this.Width;
        }

        // EVENT HANDLERS
        private void ProjectsBtn_Click(object sender, EventArgs e) {
            ViewProjectsForm form = new ViewProjectsForm();
            form.ShowDialog();
        }
        private void ExitAppButton_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void TitleLbl_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(
                e.Graphics,
                TitleLbl.DisplayRectangle,
                Settings.Default.LabelForeColor,
                ButtonBorderStyle.Solid);
        }
        private void MainTblLayout_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(
                e.Graphics,
                MainTblLayout.DisplayRectangle,
                Settings.Default.LabelForeColor,
                ButtonBorderStyle.Solid);
        }
    }

}