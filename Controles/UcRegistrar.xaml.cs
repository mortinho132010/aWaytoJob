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
using awtj.Controles.SubControles;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para UcRegistrar.xam
    /// </summary>
    public partial class UcRegistrar : UserControl {
        public UcRegistrar() {
            InitializeComponent();
            UcFormPessoa pes = new UcFormPessoa();
            ConteinerForm.Children.Add(pes);
            ComboUser.SelectedIndex = 0;
        }

        private void ComboUser_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(ComboUser.SelectedIndex == 0) {
                ConteinerForm.Children.Clear();
                UcFormPessoa pes = new UcFormPessoa();
                ConteinerForm.Children.Add(pes);
            }
        }
    }
}
