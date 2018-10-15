using System.Windows.Controls;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormPessoa.xam
    /// </summary>
    public partial class UcFormPessoa : UserControl {
        public UcFormPessoa() {
            InitializeComponent();
        }

        public string TextBoxUsuario() {
            return TextUsuario.Text;
        }
        public string TextSenha() {
            return TextPassSenha.Password;
        }
        public string TextConfirma() {
            return TextPassConfirma.Password;
        }
        public string TextBoxNome() {
            return TextNome.Text;
        }
        public string TextBoxTelefone() {
            return TextTelefone.Text;
        }
        public string TextBoxEndereco() {
            return TextEndereco.Text;
        }
        public string TextBoxEmail() {
            return TextEmail.Text;
        }
        public string RadioSelected() {
            if (RadioM.IsChecked == true) {
                return "masculino";
            } else {
                return "feminino";
            }
        }
    }
}
