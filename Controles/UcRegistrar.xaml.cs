using awtj.Controles.SubControles;
using System.Windows.Controls;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para UcRegistrar.xam
    /// </summary>
    public partial class UcRegistrar : UserControl {
        public int RadioOp { private set; get; }
        private UcFormPessoa pes;
        private UcFormEmpresa emp;
        public UcRegistrar() {
            InitializeComponent();
            pes = new UcFormPessoa();
            emp = new UcFormEmpresa();
            FormPessoa();
            RadioOp = 0;
        }

        public UcFormPessoa ObjPessoa() {
            return pes;
        }

        public UcFormEmpresa ObjEmpresa() {
            return emp;
        }
        public void FormPessoa() {
            ConteinerForm.Children.Add(pes);
        }

        public void FormEmpresa() {
            ConteinerForm.Children.Add(emp);
        }

        private void ComboUser_DropDownClosed(object sender, System.EventArgs e) {
            if (ComboUser.SelectedIndex == 0) {
                ConteinerForm.Children.Clear();
                FormPessoa();
                RadioOp = 0;
            } else if (ComboUser.SelectedIndex == 1) {
                ConteinerForm.Children.Clear();
                FormEmpresa();
                RadioOp = 1;
            }
        }
    }
}
