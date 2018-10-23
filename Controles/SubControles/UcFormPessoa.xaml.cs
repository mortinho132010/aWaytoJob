using System.Windows.Controls;
using System.Windows.Input;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormPessoa.xam
    /// </summary>
    public partial class UcFormPessoa : UserControl {
        Restricoes rest;
        public UcFormPessoa() {
            InitializeComponent();
            rest = new Restricoes();
            RadioM.IsChecked = true;
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

        private void TextUsuario_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrSemEspaco(TextUsuario.Text, 20, e);
        }

        private void TextPassSenha_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextPassSenha.Password, 18, e);
        }

        private void TextPassConfirma_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextPassConfirma.Password, 18, e);
        }

        private void TextNome_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrNome(TextNome.Text, 30, e);
        }

        private void TextEndereco_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextEndereco.Text, 30, e);
        }

        private void TextEmail_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrEmail(TextEmail.Text, 30, e);
        }
    }
}
