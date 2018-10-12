using System.Windows;
using awtj.Controles;
using awtj.Controles.SubControles;
namespace awtj {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            UcLogin log = new UcLogin();
            conteiner.Children.Add(log);
        }

        public void formRegistrar() {
            conteiner.Children.Clear();
            UcRegistrar reg = new UcRegistrar();
            conteiner.Children.Add(reg);
        }

        private void RegButton_Click(object sender, RoutedEventArgs e) {
            formRegistrar();
        }
    }
}
