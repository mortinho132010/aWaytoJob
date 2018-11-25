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
        //animações
        private Storyboard ani;
        //listas de usuarios
        private ListaPessoas Lp;
        private ListaEmpresas Le;
        //referencia a janela principal
        private ClientWindow CliWin;
        //controles de usuários
        private PerfilPessoa pf;
        private FormPerfilEmpresa pe;
        private FormTimeLine tl;
        //Métodos para gerenciar XML
        private XmlMetodos xml = new XmlMetodos();

        public int Index { set; get; }
        public string Option { set; get; }
        public string[] Dados { set; get; }

        public ClientWindow(int ind, string op, ListaPessoas listp, ListaEmpresas liste) {
            Index = ind;
            Option = op;
            Lp = listp;
            Le = liste;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Dados = xml.GetDados(ind, op);
            if (op == "PESSOAS") {
                SetButtons(Dados[2] + " " + Dados[3], Dados[16]);
            } else {
                SetButtons(Dados[2], Dados[14]);
            }
        }

        //Métodos de acesso a referencias
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
        public PerfilPessoa GetPerfilPessoa() {
            return pf;
        }
        public FormPerfilEmpresa GetFormPerfilEmpresa() {
            return pe;
        }
        public FormTimeLine GetTimeLine() {
            return tl;
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
            main_conteiner.Children.Clear();
            if (Option == "PESSOAS") {
                pf = new PerfilPessoa(Index, GetListaPessoas(), GetListaEmpresas(), GetClient());
                pf.SetPerfilPessoa(GetPerfilPessoa());
                main_conteiner.Children.Add(pf);
            } else {
                pe = new FormPerfilEmpresa(Index, GetListaEmpresas(), GetListaPessoas(), GetClient());
                main_conteiner.Children.Add(pe);
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

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) {
            main_conteiner.Children.Clear();
            if (Option == "PESSOAS") {

            } else {
                tl = new FormTimeLine(Index, GetListaPessoas(), GetListaEmpresas());
                main_conteiner.Children.Add(tl);
            }
        }

        private void Expand_button_Click(object sender, RoutedEventArgs e) {
            if (expand_button.IsChecked == true) {
                ani = this.FindResource("MarginCompact") as Storyboard;
                ani.Begin();
            } else if (expand_button.IsChecked == false) {
                ani = this.FindResource("MarginExpand") as Storyboard;
                ani.Begin();
            }
        }
    }
}
