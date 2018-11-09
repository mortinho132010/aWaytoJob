using System;
using System.Windows;
using System.Windows.Controls;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para UcLogin.xam
    /// </summary>
    public partial class UcLogin : UserControl {
        private XmlMetodos xml;
        private ListaEmpresas eList;
        private ListaPessoas pList;
        private ClientWindow c;
        public UcLogin() {
            InitializeComponent();
            xml = new XmlMetodos();
            eList = new ListaEmpresas();
            pList = new ListaPessoas();
            xml.LerXml(pList, eList);
        }

        public ListaPessoas GetListPessoa() {
            return pList;
        }
        public ListaEmpresas GetListEmpresa() {
            return eList;
        }
        public void SetClient(int ind, string tipo) {
            c = new ClientWindow(ind, tipo, GetListPessoa(), GetListEmpresa());
        }
        public ClientWindow GetClient() {
            return c;
        }

        private void Login() {
            string[] res = xml.ComparaXml(tbUsuario.Text, tbSenha.Password);
            if (res[2] == "false") {
                labelnfo.Content = "Usuário ou Senha Invalidos!";
            } else {
                if (res[1] == "PESSOAS") {
                    Application.Current.MainWindow.Hide();
                    SetClient(Convert.ToInt32(res[0]), res[1]);
                    c.SetClient(GetClient());
                    c.Show();
                } else {
                    Application.Current.MainWindow.Hide();
                    SetClient(Convert.ToInt32(res[0]), res[1]);
                    c.Show();
                }
            }
        }

        private void TbUsuario_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Return) {
                Login();
            }
        }

        private void TbSenha_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Return) {
                Login();
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e) {
            Login();
        }
    }


}
