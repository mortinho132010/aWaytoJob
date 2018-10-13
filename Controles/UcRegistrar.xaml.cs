using awtj.Controles.SubControles;
using System.Windows.Controls;

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

        public void FormPessoa() {
            UcFormPessoa pes = new UcFormPessoa();
            ConteinerForm.Children.Add(pes);
        }

        public void FormEmpresa() {
            UcFormEmpresa emp = new UcFormEmpresa();
            ConteinerForm.Children.Add(emp);
        }
        private void ComboUser_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ComboUser.SelectedIndex == 0) {
                ConteinerForm.Children.Clear();
                FormPessoa();
            } else if (ComboUser.SelectedIndex == 1) {
                ConteinerForm.Children.Clear();
                FormEmpresa();
            }
        }
    }
}
