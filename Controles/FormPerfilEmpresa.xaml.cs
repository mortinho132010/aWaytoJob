using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para FormPerfilEmpresa.xam
    /// </summary>
    public partial class FormPerfilEmpresa : UserControl {
        private ListaEmpresas liste;
        private ListaPessoas listp;
        private ClientWindow CliWin;
        private XmlMetodos xml = new XmlMetodos();
        private Restricoes restr = new Restricoes();

        private string[] dados;
        private int Indice;

        public FormPerfilEmpresa(int ind, ListaEmpresas le, ListaPessoas lp, ClientWindow cli) {
            InitializeComponent();
            //definindo as referencias as listas
            liste = le;
            listp = lp;
            //definindo as referencias a janela principal do cliente
            CliWin = cli;
            //valor de indice do usuário carregado
            Indice = ind;
            //armazenando dados do perfil do usuário carregado
            dados = liste.GetUserData(Indice);
            // carrega as informações contidas no perfil
            SetInfo();
            SetImage(dados[14]);
        }
        //Insere as informações nos campos do formulário
        private void SetInfo() {
            if (dados[4].Contains("_") == false && dados[4] != "") {
                ChkTel2.IsChecked = true;
                MskTel2.IsEnabled = true;
                if (dados[5].Contains("_") == false && dados[5] != "") {
                    ChkTel3.IsChecked = true;
                    MskTel3.IsEnabled = true;
                }
            }
            TbNome.Text = dados[2]; MskCnpj.Value = dados[13];
            MskTel1.Value = dados[3]; MskTel2.Value = dados[4]; MskTel3.Value = dados[5];
            TbCEP.Text = dados[6]; TbCidade.Text = dados[7]; SetCombo(dados[8], CmbEstado);
            TbBairro.Text = dados[11]; TbEndereco.Text = dados[9]; TbNumero.Text = dados[10];
            DateTime data = DateTime.Parse(dados[17]);
            DtpData.SelectedDate = data;
            TbFacebook.Text = dados[15]; TbLinkedin.Text = dados[16];
        }
        //Define o ComboBox
        private void SetCombo(string est, ComboBox box) {
            for (int i = 0; i < box.Items.Count; i++) {
                box.SelectedIndex = i;
                if (box.SelectedItem.ToString().Contains(est)) {
                    break;
                }
            }
        }
        //Define a imagem de usuário no ImagePicker
        private void SetImage(string destino) {
            if (System.IO.File.Exists(destino)) {
                if (destino == @".\Images\SystemIcons\UserDefault.jpg") {
                    ImageBrush img = new ImageBrush {
                        ImageSource = new BitmapImage(new Uri(destino, UriKind.Relative))
                    };
                    img.Stretch = Stretch.Uniform;
                    ImagePicker.Background = img;
                    ImagePicker.Content = "SELECIONE UMA IMAGEM DE PERFIL";
                } else if (destino != null && destino != @".\Images\SystemIcons\UserDefault.jpg") {
                    ImageBrush img = new ImageBrush {
                        ImageSource = new BitmapImage(new Uri(destino, UriKind.Relative))
                    };
                    img.Stretch = Stretch.Uniform;
                    ImagePicker.Background = img;
                    ImagePicker.Content = "";
                }
            }
        }
        //Copia uma imagem JPG para o destino padrão de imagens
        private string CopiaCola() {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog {
                DefaultExt = "jpg",
                Filter = "Imagem (*.jpg)|*.jpg"
            };
            Nullable<bool> result = open.ShowDialog();
            string des = null;
            if (result == true) {
                des = @".\Images\UserImages\" + System.IO.Path.GetFileName(open.FileName);
                if (!Directory.Exists(@".\Images\UserImages")) {
                    Directory.CreateDirectory(@".\Images\UserImages");
                }
                try {
                    File.Copy(open.FileName, des, true);
                    dados[14] = des;
                } catch {
                    MessageBox.Show(String.Format("Esta imagem ja foi selecionada anteriormente.\n" +
                        "Para utiliza-la, encerre e abra o A Way to Job!"),
                        "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                    des = @".\Images\SystemIcons\UserDefault.jpg";
                }
            }
            return des;
        }
        //Retorna verdadeiro se existir algum campo em branco obrigatório
        private bool CampoemBranco() {
            if (TbNome.Text == "" || TbCEP.Text == "" || MskTel1.EnteredValue.Contains("_") || MskCnpj.EnteredValue.Contains("_")) {
                MessageBox.Show("Não deixe nenhum item obrigatório em branco!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            } else {
                return false;
            }
        }
        //Salva as informações do formulário em XML
        private void SetListaXML() {
            if (MskTel2.EnteredValue.Contains("_")) {
                MskTel2.Clear();
            }
            if (MskTel3.EnteredValue.Contains("_")) {
                MskTel3.Clear();
            }
            //reescreve os valores do usuário na origem de sua referencia na memoria
            liste.SetUserData(Indice, TbNome.Text, MskCnpj.EnteredValue, MskTel1.EnteredValue,
            MskTel2.EnteredValue, MskTel3.EnteredValue, TbCEP.Text, TbCidade.Text,
            CmbEstado.Text, TbEndereco.Text, TbNumero.Text, TbBairro.Text, dados[14],
            TbFacebook.Text, TbLinkedin.Text, DtpData.SelectedDate.Value.ToShortDateString());
            //reescreve o arquivo xml
            xml.GuardarXml(listp, liste);
            //atualiza os dados anteriormente carregados
            dados = liste.GetUserData(Indice);
            //modifica as caracteristicas da janela cliente
            CliWin.SetButtons(dados[2], dados[14]);
        }

        private void TbCEP_PreviewKeyDown(object sender, KeyEventArgs e) {
            restr.RestrNumero(TbCEP.Text, 8, e);
        }

        private void SalvarInfo_Click(object sender, RoutedEventArgs e) {
            if (CampoemBranco() == false) {
                SetListaXML();
            }
        }

        private void ChkTel2_Checked(object sender, RoutedEventArgs e) {
            MskTel2.IsEnabled = true;
        }

        private void ChkTel3_Checked(object sender, RoutedEventArgs e) {
            MskTel3.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SetImage(CopiaCola());
        }

        private void ChkTel2_Unchecked(object sender, RoutedEventArgs e) {
            MskTel2.IsEnabled = false;
            if (MskTel2.EnteredValue.Contains("_")) {
                MskTel2.Clear();
            }
        }

        private void ChkTel3_Unchecked(object sender, RoutedEventArgs e) {
            MskTel3.IsEnabled = false;
            if (MskTel3.EnteredValue.Contains("_")) {
                MskTel3.Clear();
            }
        }
    }
}
