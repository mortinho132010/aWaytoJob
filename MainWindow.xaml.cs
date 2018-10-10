using System.Windows;
using awtj.Controles;
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
    }
}
