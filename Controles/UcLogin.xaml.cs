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

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (xml.ComparaXml(tbUsuario.Text, tbSenha.Password) == false) {
                labelnfo.Content = "Usuário ou Senha Invalidos!";
            } else {
                Application.Current.MainWindow.Hide();
                ClientWindow c = new ClientWindow();
                c.Show();
            }
        }
    }


}
