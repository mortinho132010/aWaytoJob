using Correios;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormEmpresa.xam
    /// </summary>
    public partial class UcFormEmpresa : UserControl {
        Restricoes rest;
        public string Cidade { set; get; }
        public string Estado { set; get; }
        public string Endereco { set; get; }
        public string Bairro { set; get; }
        public UcFormEmpresa() {
            InitializeComponent();
            rest = new Restricoes();
        }

        public void Clear() {
            TextUsuario.Clear();
            TextSenha.Clear();
            TextConfirma.Clear();
            TextNome.Clear();
            TextTelefone.Clear();
            TextCEP.Clear();
            labVerifica.Content = "Status:";
            TextEmail.Clear();
            Data.SelectedDate = DateTime.Now;
            TextCnpj.Clear();
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
            return TextTelefone.EnteredValue;
        }
        public string TextBoxCEP() {
            return TextCEP.Text;
        }
        public string TextBoxEmail() {
            return TextEmail.Text;
        }
        public string TextBoxCnpj() {
            return TextCnpj.EnteredValue;
        }
        public string Date() {
            try {
                return Data.SelectedDate.Value.ToShortDateString();
            } catch {
                return DateTime.Now.ToShortDateString();
            }
        }

        public bool VerificarCampos() {
            if (TextBoxUsuario() == "" || TextPassSenha() == "" || TextPassConfirma() == "" || TextBoxNome() == "" ||
                TextBoxTelefone().Contains("_") || TextBoxCEP() == "" || TextBoxEmail() == "" || TextBoxCnpj().Contains("_")) {
                return false;
            } else return true;
        }
        public bool VerificarSenhas() {
            if (TextPassSenha().Equals(TextPassConfirma())) {
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

        private void TextSenha_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextSenha.Password, 18, e);
        }

        private void TextConfirma_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrTamanho(TextConfirma.Password, 18, e);
        }

        private void TextNome_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrNome(TextNome.Text, 30, e);
        }

        private void TextEmail_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrEmail(TextEmail.Text, 30, e);
        }

        private void TextCEP_PreviewKeyDown(object sender, KeyEventArgs e) {
            rest.RestrNumero(TextCEP.Text, 8, e);
        }

        private void Verifica_Click(object sender, System.Windows.RoutedEventArgs e) {
            BuscarCep(TextBoxCEP());
        }
    }
}
