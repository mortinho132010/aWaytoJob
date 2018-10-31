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

        private void Login() {
            string[] res = xml.ComparaXml(tbUsuario.Text, tbSenha.Password);
            if (res[4] == "false") {
                labelnfo.Content = "Usuário ou Senha Invalidos!";
            } else {
                Application.Current.MainWindow.Hide();
                ClientWindow c = new ClientWindow(res[0], res[1], res[2], Convert.ToInt32(res[3]), Convert.ToBoolean(res[4]));
                c.Show();
            }
        }

        private void tbUsuario_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if(e.Key == System.Windows.Input.Key.Return) {
                Login();
            }
        }

        private void tbSenha_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Return) {
                Login();
            }
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e) {
            Login();
        }
    }


}
