using awtj.Controles;
using awtj.Controles.SubControles;
using System.Windows;
using System.Windows.Controls;
namespace awtj {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {

        private UcLogin log;
        private UcRegistrar reg;
        private UcRedefinir red;
        private ListaPessoas listaPessoas;
        private ListaEmpresas listaEmpresas;
        private XmlMetodos xmlMet;

        public MainWindow() {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            reg = new UcRegistrar();
            log = new UcLogin();
            red = new UcRedefinir();
            listaPessoas = log.GetListPessoa();
            listaEmpresas = log.GetListEmpresa();
            xmlMet = new XmlMetodos();
            conteiner.Children.Add(log);
        }

        public void FormLogin() {
            conteiner.Children.Clear();
            conteiner.Children.Add(log);
        }

        public void FormRegistrar() {
            conteiner.Children.Clear();
            conteiner.Children.Add(reg);
        }

        public void FormRedefinir() {
            conteiner.Children.Clear();
            conteiner.Children.Add(red);
        }

        public void AlinharBotoes(Button bt1, double left, double top, double right, double botton) {
            bt1.Margin = new Thickness(left, top, right, botton);
        }

        private void RegButton_Click(object sender, RoutedEventArgs e) {
            if (RegButton.Content.Equals("Registrar-se")) {
                FormRegistrar();
                LabelReg.Content = "";
                LabelRes.Content = "";
                RegButton.Content = "Concluir";
                ResButton.Content = "Voltar";
                AlinharBotoes(RegButton, 158, 11, 0, 0);
                AlinharBotoes(ResButton, 158, 54, 0, 0);
            } else if (RegButton.Content.Equals("Concluir")) {
                if (reg.RadioOp == 0) {
                    UcFormPessoa x = reg.ObjPessoa();
                    if (x.BuscarCep(x.TextBoxCEP()) == true && x.VerificarCampos() == true && x.VerificarSenhas() == true) {
                        listaPessoas.Cadastrar(x.TextBoxUsuario(), x.TextConfirma(), x.TextBoxNome(), "",
                            x.TextBoxTelefone(), "", "", x.TextBoxCEP(), x.Cidade, x.Estado, x.Endereco,
                            "", x.Bairro, "", x.TextBoxEmail(), x.RadioSelected(), @".\Images\SystemIcons\UserDefault.jpg", "", "");
                        xmlMet.GuardarXml(listaPessoas, listaEmpresas);
                    } else {
                        MessageBox.Show("Não deixe nenhum campo em branco, e verifique se o CEP é válido",
                            "Verifique os campos!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } else {
                    UcFormEmpresa x = reg.ObjEmpresa();
                    if (x.BuscarCep(x.TextBoxCEP()) == true && x.VerificarCampos() == true && x.VerificarSenhas() == true) {
                        listaEmpresas.Cadastrar(x.TextBoxUsuario(), x.TextPassConfirma(), x.TextBoxNome(),
                            x.TextBoxTelefone(), "", "", x.TextBoxCEP(), x.Cidade, x.Estado, x.Endereco, "",
                            x.Bairro, "", x.TextBoxEmail(), x.TextBoxCnpj(), @".\Images\SystemIcons\UserDefault.jpg", "", "");
                        xmlMet.GuardarXml(listaPessoas, listaEmpresas);
                    } else {
                        MessageBox.Show("Não deixe nenhum campo em branco, e verifique se o CEP é válido",
                            "Verifique os campos!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            } else {
                FormLogin();
                LabelReg.Content = "Ainda não possui uma conta para acessar?";
                LabelRes.Content = "Não se Lembra de sua senha? Obtenha uma nova:";
                RegButton.Content = "Registrar-se";
                ResButton.Content = "Redefinir";
                AlinharBotoes(RegButton, 290, 11, 0, 0);
                AlinharBotoes(ResButton, 290, 54, 0, 0);
            }
        }

        private void ResButton_Click(object sender, RoutedEventArgs e) {
            if (ResButton.Content.Equals("Redefinir")) {
                FormRedefinir();
                LabelReg.Content = "";
                LabelRes.Content = "";
                RegButton.Content = "Voltar";
                ResButton.Content = "Concluir";
                AlinharBotoes(RegButton, 158, 54, 0, 0);
                AlinharBotoes(ResButton, 158, 11, 0, 0);
            } else if (ResButton.Content.Equals("Concluir")) {

            } else {
                FormLogin();
                LabelReg.Content = "Ainda não possui uma conta para acessar?";
                LabelRes.Content = "Não se Lembra de sua senha? Obtenha uma nova:";
                RegButton.Content = "Registrar-se";
                ResButton.Content = "Redefinir";
                AlinharBotoes(RegButton, 290, 11, 0, 0);
                AlinharBotoes(ResButton, 290, 54, 0, 0);
            }
        }
    }
}
