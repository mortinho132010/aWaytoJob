using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para MenuPessoa.xam
    /// </summary>
    public partial class MenuPessoa : UserControl {
        ClientWindow obj;
        public MenuPessoa(object objeto) {
            InitializeComponent();
            obj = (ClientWindow)objeto;
            MessageBox.Show("" + objeto);
            MessageBox.Show("" + obj);
        }

        private void ButtonSair_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void ButtonUsuario_Checked(object sender, RoutedEventArgs e) {
            PerfilPessoa pes = new PerfilPessoa();
            obj.main_conteiner.Children.Add(pes);
        }
    }
}
