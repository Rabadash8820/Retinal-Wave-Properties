using System;
using System.Windows;
using System.Reflection;

using Gat.Controls;

namespace MEACruncher {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void ViewProjectsBtn_Click(object sender, RoutedEventArgs e) {

        }
        private void AboutBtn_Click(object sender, RoutedEventArgs e) {
            Assembly a = Assembly.GetExecutingAssembly();

            AboutControlView about = new AboutControlView();
            AboutControlViewModel aboutVM = (AboutControlViewModel)about.FindResource("ViewModel");

            string notes = "Some pretty interesting and very technical additional notes.";

            aboutVM.AdditionalNotes = notes;
            aboutVM.ApplicationLogo = null;
            aboutVM.Copyright = a.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            aboutVM.Description = a.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            aboutVM.Hyperlink = new Uri("https://danvicarel.com", UriKind.Absolute);
            aboutVM.HyperlinkText = a.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            aboutVM.IsSemanticVersioning = true;
            aboutVM.Publisher = "Danware";
            aboutVM.PublisherLogo = null;
            aboutVM.Title = a.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            aboutVM.Version = a.GetName().Version.ToString();
            
            aboutVM.Window.Content = about;
            aboutVM.Window.Show();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
