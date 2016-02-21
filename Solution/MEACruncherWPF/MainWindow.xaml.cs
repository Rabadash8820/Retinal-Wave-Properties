using System;
using System.Windows;
using System.Reflection;
using System.Windows.Media.Animation;

using Gat.Controls;

namespace MEACruncher {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // CONSTRUCTORS
        public MainWindow() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void ViewProjectsBtn_Click(object sender, RoutedEventArgs e) {
            ViewProjectsWindow win = new ViewProjectsWindow();
            win.Show();
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

        private void Derp(object sender, RoutedEventArgs e) {
            FrameworkElement elem = sender as FrameworkElement;

            Duration halfSec = new Duration(TimeSpan.FromSeconds(0.5d));

            Storyboard sb = new Storyboard();
            
            DoubleAnimation animX = new DoubleAnimation(0d, 1d, halfSec);
            DoubleAnimation animY = new DoubleAnimation(0d, 1d, halfSec);
            sb.Children.Add(animX);
            sb.Children.Add(animY);

            Storyboard.SetTarget(animX, elem);
            Storyboard.SetTarget(animY, elem);
            Storyboard.SetTargetProperty(animX, new PropertyPath("RenderTransform.(ScaleTransform.ScaleX)"));
            Storyboard.SetTargetProperty(animY, new PropertyPath("RenderTransform.(ScaleTransform.ScaleY)"));

            sb.Begin();
        }
    }
}
