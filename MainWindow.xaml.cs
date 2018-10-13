using awtj.Controles;
using System.Windows;
using System.Windows.Controls;
namespace awtj {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        UcLogin log;
        UcRegistrar reg;
        UcRedefinir red;
        public MainWindow() {
            InitializeComponent();
            reg = new UcRegistrar();
            log = new UcLogin();
            red = new UcRedefinir();
            conteiner.Children.Add(log);
        }

        public void formLogin() {
            conteiner.Children.Clear();
            conteiner.Children.Add(log);
        }

        public void formRegistrar() {
            conteiner.Children.Clear();
            conteiner.Children.Add(reg);
        }

        public void formRedefinir() {
            conteiner.Children.Clear();
            conteiner.Children.Add(red);
        }
        public void AlinharBotoes(Button bt1, double left, double top, double right, double botton) {
            bt1.Margin = new Thickness(left, top, right, botton);
        }

        private void RegButton_Click(object sender, RoutedEventArgs e) {
            if (RegButton.Content.Equals("Registrar-se")) {
                formRegistrar();
                LabelReg.Content = "";
                LabelRes.Content = "";
                RegButton.Content = "Concluir";
                ResButton.Content = "Voltar";
                AlinharBotoes(RegButton, 158, 11, 0, 0);
                AlinharBotoes(ResButton, 158, 54, 0, 0);
            } else if (RegButton.Content.Equals("Concluir")) {

            } else {
                formLogin();
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
                formRedefinir();
                LabelReg.Content = "";
                LabelRes.Content = "";
                RegButton.Content = "Voltar";
                ResButton.Content = "Concluir";
                AlinharBotoes(RegButton, 158, 54, 0, 0);
                AlinharBotoes(ResButton, 158, 11, 0, 0);
            } else if (ResButton.Content.Equals("Concluir")) {

            } else {
                formLogin();
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
