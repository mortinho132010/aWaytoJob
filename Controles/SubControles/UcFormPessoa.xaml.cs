using Correios;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormPessoa.xam
    /// </summary>
    public partial class UcFormPessoa : UserControl {
        Restricoes rest;
        public string Cidade { set; get; }
        public string Estado { set; get; }
        public string Endereco { set; get; }
        public string Bairro { set; get; }

        public UcFormPessoa() {
            InitializeComponent();
            rest = new Restricoes();
        }

        public void Clear() {
            TextUsuario.Clear();
            TextPassSenha.Clear();
            TextPassConfirma.Clear();
            TextNome.Clear();
            TextTelefone.Clear();
            TextCEP.Clear();
            labVerifica.Content = "Status:";
            TextEmail.Clear();
            Data.SelectedDate = DateTime.Now;
            RadioM.IsChecked = true;
            RadioF.IsChecked = false;
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
            return TextTelefone.EnteredValue;
        }
        public string TextBoxCEP() {
            return TextCEP.Text;
        }
        public string TextBoxEmail() {
            return TextEmail.Text;
        }
        public string Date() {
            try {
                return Data.SelectedDate.Value.ToShortDateString();
            } catch {
                return DateTime.Now.ToShortDateString();
            }
        }

        public string RadioSelected() {
            if (RadioM.IsChecked == true) {
                return "masculino";
            } else {
                return "feminino";
            }
        }

        public bool VerificarCampos() {
            if (TextBoxUsuario() == "" || TextSenha() == "" || TextConfirma() == "" || TextBoxNome() == "" ||
                TextBoxTelefone().Contains("_") || TextBoxCEP() == "" || TextBoxEmail() == "") {
                return false;
            } else return true;
        }
        public bool VerificarSenhas() {
            if (TextSenha().Equals(TextConfirma())) {
                return true;
            } else return false;
        }

        public bool BuscarCep(string cep) {
            bool status = false;
            if (int.TryParse(cep, out int aux) == true) {
                CorreiosApi api = new CorreiosApi();
                try {
                    var res = api.consultaCEP(cep);
                    if (res.cidade != null) {
                        Cidade = res.cidade;
                        Bairro = res.bairro;
                        Endereco = res.end;
                        Estado = res.uf;
                        labVerifica.Content = "Status: OK";
                        status = true;
                    } else {
                        labVerifica.Content = "Status: INVALIDO";
                        Cidade = "";
                        Bairro = "";
                        Endereco = "";
                        Estado = "";
                        status = false;
                    }
                } catch (System.ServiceModel.FaultException) {
                    labVerifica.Content = "Status: INVALIDO";
                    Cidade = "";
                    Bairro = "";
                    Endereco = "";
                    Estado = "";
                    status = false;
                }
            } else {
                labVerifica.Content = "Status: INVALIDO";
                Cidade = "";
                Bairro = "";
                Endereco = "";
                Estado = "";
                status = false;
            }
            return status;
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

        private void TextEmail_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrEmail(TextEmail.Text, 30, e);
        }

        private void TextNome_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrSemEspaco(TextNome.Text, 15, e);
        }

        private void Verifica_Click(object sender, RoutedEventArgs e) {
            BuscarCep(TextCEP.Text);
        }

        private void TextCEP_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrNumero(TextCEP.Text, 8, e);
        }
    }
}
