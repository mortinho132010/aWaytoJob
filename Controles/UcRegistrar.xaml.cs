using awtj.Controles.SubControles;
using System.Windows.Controls;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para UcRegistrar.xam
    /// </summary>
    public partial class UcRegistrar : UserControl {
        public UcRegistrar() {
            InitializeComponent();
            FormPessoa();
        }

        public void FormPessoa() {
            UcFormPessoa pes = new UcFormPessoa();
            ConteinerForm.Children.Add(pes);
        }

        public void FormEmpresa() {
            UcFormEmpresa emp = new UcFormEmpresa();
            ConteinerForm.Children.Add(emp);
        }

        private void ComboUser_DropDownClosed(object sender, System.EventArgs e) {
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
