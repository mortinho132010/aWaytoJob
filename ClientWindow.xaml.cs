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
        private XmlMetodos xml = new XmlMetodos();
        private PerfilPessoa pf;
        private ListaPessoas Lp;
        private ListaEmpresas Le;
        private ClientWindow CliWin;

        public int Index { set; get; }
        public string Option { set; get; }
        public string[] Dados { set; get; }

        public ClientWindow(int ind, string op, ListaPessoas listp, ListaEmpresas liste) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Index = ind;
            Option = op;
            Dados = xml.GetDados(ind, op);
            if (op == "PESSOAS") {
                SetButtons(Dados[2] + " " + Dados[3], Dados[16]);
                Lp = (ListaPessoas) listp;
                Le = (ListaEmpresas) liste;
            } else {
                SetButtons(Dados[2], Dados[14]);
                Lp = (ListaPessoas) listp;
                Le = (ListaEmpresas) liste;
            }
        }

        public ListaPessoas GetListaPessoas() {
            return Lp;
        }
        public ListaEmpresas GetListaEmpresas() {
            return Le;
        }
        public void SetClient(ClientWindow cli) {
            CliWin = cli;
        }
        public ClientWindow GetClient() {
            return CliWin;
        }
        public void SetButtons(string nome, string url) {
            if (System.IO.File.Exists(url)) {
                ImageBrush img = new ImageBrush { ImageSource = new BitmapImage(new Uri(url, UriKind.Relative)) };
                img.Stretch = Stretch.Uniform;
                UserButton.Background = img;
                UserButton.Content = nome;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            if (Option == "PESSOAS") {
                pf = new PerfilPessoa(Index, GetListaPessoas(), GetListaEmpresas(), GetClient());
                main_conteiner.Children.Add(pf);
            } else {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            try {
                Application.Current.MainWindow.Close();
            } catch { }
        }

        private void Expand_button_Click(object sender, RoutedEventArgs e) {
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
