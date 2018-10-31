using awtj.Controles;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace awtj {
    /// <summary>
    /// Lógica interna para ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window {
        private Storyboard sini, sfin;

        public string User { set; get; }
        public string Names { set; get; }
        public string Image { set; get; }
        public int Index { set; get; }
        public bool Option { set; get; }

        public ClientWindow(string usu, string nom, string img, int ind, bool op) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SetButtons(nom, img);
        }

        public void SetButtons(string nome, string url) {
            ImageBrush img = new ImageBrush { ImageSource = new BitmapImage(new Uri(url, UriKind.Relative)) };
            img.Stretch = Stretch.Uniform;
            UserButton.Background = img;
            UserButton.Content = nome;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            PerfilPessoa pf = new PerfilPessoa();
            main_conteiner.Children.Add(pf);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            try {
                Application.Current.MainWindow.Close();
            } catch { }
        }

        private void expand_button_Click(object sender, RoutedEventArgs e) {
            if (expand_button.IsChecked == true) {
                sini = this.FindResource("MarginCompact") as Storyboard;
                sini.Begin();
            } else if (expand_button.IsChecked == false) {
                sfin = this.FindResource("MarginExpand") as Storyboard;
                sfin.Begin();
            }
        }
    }
}
