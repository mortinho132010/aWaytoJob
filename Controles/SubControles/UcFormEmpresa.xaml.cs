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

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormEmpresa.xam
    /// </summary>
    public partial class UcFormEmpresa : UserControl {
        Restricoes rest;
        public UcFormEmpresa() {
            InitializeComponent();
            rest = new Restricoes();
        }

        public string TextBoxUsuario() {
            return TextUsuario.Text;
        }
        public string TextPassSenha() {
            return TextSenha.Password;
        }
        public string TextPassConfirma() {
            return TextConfirma.Password;
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
        public string TextBoxCnpj() {
            return TextCnpj.Text;
        }

        private void TextUsuario_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrSemEspaco(TextUsuario.Text, 20, e);
        }

        private void TextSenha_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextSenha.Password, 18, e);
        }

        private void TextConfirma_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextConfirma.Password, 18, e);
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
