using awtj.Controles.SubControles;
using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para PerfilPessoa.xam
    /// </summary>
    public partial class PerfilPessoa : UserControl {
        private UcFormEspecCurso fec;
        private UcFormEspecFerram fef;
        private UcFormEspecIdioma fei;
        private UcFormExperiencia fee;
        private ClientWindow CliWin;
        private PerfilPessoa PerPessoa;

        private ArrayList array_fec = new ArrayList();
        private ArrayList array_fef = new ArrayList();
        private ArrayList array_fei = new ArrayList();
        private ArrayList array_fee = new ArrayList();
        private ListaPessoas listp;
        private ListaEmpresas liste;

        private int mgCurso = 0;
        private int mgFerram = 0;
        private int mgIdioma = 0;
        private int mgExperi = 0;
        private int Indice;
        private string[] dados;

        private XmlMetodos xml = new XmlMetodos();
        private Restricoes restr = new Restricoes();

        public PerfilPessoa(int ind, ListaPessoas lp, ListaEmpresas le, ClientWindow cli) {
            InitializeComponent();
            SetCursoConteiner();
            SetFerramConteiner();
            SetIdiomaConteiner();
            SetExperiConteiner();
            listp = lp;
            liste = le;
            Indice = ind;
            CliWin = cli;
            dados = listp.GetUserData(Indice);
            SetInfo();
            SetImage(dados[16]);
        }

        public void SetPerfilPessoa(PerfilPessoa pp) {
            PerPessoa = pp;
            xml.GetCurriculoXML(dados[13], PerPessoa);
        }

        public void SetCaracteristicas(string atu, string esp, string esc) {
            TbAtuacao.Text = atu;
            TbEspecificacao.Text = esp;
            SetCombo(esc, CmbEscolaridade);
        }

        public string[] GetCaracteristicas() {
            string[] d = new string[3];
            d[0] = TbAtuacao.Text;
            d[1] = TbEspecificacao.Text;
            d[2] = CmbEscolaridade.Text;
            return d;
        }

        private void SetInfo() {
            if (dados[5].Contains("_") == false && dados[5] != "") {
                ChkTel2.IsChecked = true;
                MskTel2.IsEnabled = true;
                if (dados[6].Contains("_") == false && dados[6] != "") {
                    ChkTel3.IsChecked = true;
                    MskTel3.IsEnabled = true;
                }
            }
            TbNome.Text = dados[2]; TbSobrenome.Text = dados[3];
            MskTel1.Value = dados[4]; MskTel2.Value = dados[5]; MskTel3.Value = dados[6];
            TbCEP.Text = dados[7]; TbCidade.Text = dados[8]; SetCombo(dados[9], CmbEstado);
            TbBairro.Text = dados[12]; TbEndereco.Text = dados[10]; TbNumero.Text = dados[11];
            DateTime data = DateTime.Parse(dados[19]);
            DtpData.SelectedDate = data;
            TbFacebook.Text = dados[17]; TbLinkedin.Text = dados[18];
        }

        private void SetListaXML() {
            if (MskTel2.EnteredValue.Contains("_")) {
                MskTel2.Clear();
            }
            if (MskTel3.EnteredValue.Contains("_")) {
                MskTel3.Clear();
            }
            listp.SetUserData(Indice, TbNome.Text, TbSobrenome.Text, MskTel1.EnteredValue,
                MskTel2.EnteredValue, MskTel3.EnteredValue, TbCEP.Text, TbCidade.Text,
                CmbEstado.Text, TbEndereco.Text, TbNumero.Text, TbBairro.Text, dados[16],
                TbFacebook.Text, TbLinkedin.Text, DtpData.SelectedDate.Value.ToShortDateString());
            xml.GuardarXml(listp, liste);
            dados = listp.GetUserData(Indice);
            CliWin.SetButtons(dados[2] + " " + dados[3], dados[16]);
        }

        private void SetUcCurso() {
            fec = new UcFormEspecCurso() {
                Margin = new Thickness(0, mgCurso, 0, 0)
            };
            array_fec.Add(fec);
            mgCurso += 180;
        }

        private void SetUcFerramenta() {
            fef = new UcFormEspecFerram() {
                Margin = new Thickness(0, mgFerram, 0, 0)
            };
            array_fef.Add(fef);
            mgFerram += 90;
        }

        private void SetUcIdioma() {
            fei = new UcFormEspecIdioma() {
                Margin = new Thickness(0, mgIdioma, 0, 0)
            };
            array_fei.Add(fei);
            mgIdioma += 90;
        }

        private void SetUcExperiencia() {
            fee = new UcFormExperiencia() {
                Margin = new Thickness(0, mgExperi, 0, 0)
            };
            array_fee.Add(fee);
            mgExperi += 180;
        }

        public UcFormEspecCurso GetUcCursoTop() {
            return (UcFormEspecCurso) array_fec[array_fec.Count - 1];
        }

        public UcFormEspecFerram GetUcFerramTop() {
            return (UcFormEspecFerram) array_fef[array_fef.Count - 1];
        }

        public UcFormEspecIdioma GetUcIdiomaTop() {
            return (UcFormEspecIdioma) array_fei[array_fei.Count - 1];
        }

        public UcFormExperiencia GetUcExperiTop() {
            return (UcFormExperiencia) array_fee[array_fee.Count - 1];
        }

        public UcFormEspecCurso UcFormEspecCurso() {
            return fec;
        }
        public UcFormEspecFerram UcFormEspecFerram() {
            return fef;
        }
        public UcFormEspecIdioma UcFormEspecIdioma() {
            return fei;
        }
        public UcFormExperiencia GetUcFormExperiencia() {
            return fee;
        }

        public void SetCursoConteiner() {
            SetUcCurso();
            curso_conteiner.Children.Add(GetUcCursoTop());
        }

        public void SetFerramConteiner() {
            SetUcFerramenta();
            ferram_conteiner.Children.Add(GetUcFerramTop());
        }

        public void SetIdiomaConteiner() {
            SetUcIdioma();
            idioma_conteiner.Children.Add(GetUcIdiomaTop());
        }

        public void SetExperiConteiner() {
            SetUcExperiencia();
            experi_conteiner.Children.Add(GetUcExperiTop());
        }

        private string CopiaCola() {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog {
                DefaultExt = "jpg",
                Filter = "Imagem (*.jpg)|*.jpg"
            };
            Nullable<bool> result = open.ShowDialog();
            string des = null;
            if (result == true) {
                des = @".\Images\UserImages\" + Path.GetFileName(open.FileName);
                if (!Directory.Exists(@".\Images\UserImages")) {
                    Directory.CreateDirectory(@".\Images\UserImages");
                }
                try {
                    File.Copy(open.FileName, des, true);
                    dados[16] = des;
                } catch {
                    MessageBox.Show(String.Format("Esta imagem ja foi selecionada anteriormente.\nPara utiliza-la, encerre e abra o A Way to Job!"), "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                    des = @".\Images\SystemIcons\UserDefault.jpg";
                }
            }
            return des;
        }

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

        private bool CampoemBranco() {
            if (TbNome.Text == "" || TbCEP.Text == "" || MskTel1.EnteredValue.Contains("_")) {
                MessageBox.Show("Não deixe nenhum item obrigatório em branco!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            } else {
                return false;
            }
        }

        private void SetCombo(string est, ComboBox box) {
            for (int i = 0; i < box.Items.Count; i++) {
                box.SelectedIndex = i;
                if (box.SelectedItem.ToString().Contains(est)) {
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SetImage(CopiaCola());
        }

        private void AddCurso_Click(object sender, RoutedEventArgs e) {
            SetCursoConteiner();
            CurriculoFormOut.Height = CurriculoFormOut.ActualHeight + 180;
        }

        private void AddFerramenta_Click(object sender, RoutedEventArgs e) {
            SetFerramConteiner();
            CurriculoFormOut.Height = CurriculoFormOut.ActualHeight + 90;
            gridspliter1.Height = new GridLength(gridspliter1.ActualHeight + 90);
        }

        private void AddIdioma_Click(object sender, RoutedEventArgs e) {
            SetIdiomaConteiner();
            CurriculoFormOut.Height = CurriculoFormOut.ActualHeight + 90;
            gridspliter2.Height = new GridLength(gridspliter2.ActualHeight + 90);
        }

        private void AddOutro_Click(object sender, RoutedEventArgs e) {
            SetExperiConteiner();
            CurriculoFormOut.Height = CurriculoFormOut.ActualHeight + 180;
            gridspliter3.Height = new GridLength(gridspliter3.ActualHeight + 180);
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

        private void TbNome_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            restr.RestrSemEspaco(TbNome.Text, 15, e);
        }

        private void TbSobrenome_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            restr.RestrSemEspaco(TbSobrenome.Text, 15, e);
        }

        private void TbCEP_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            restr.RestrNumero(TbCEP.Text, 8, e);
        }

        private void SalvarCurri_Click(object sender, RoutedEventArgs e) {
            xml.SetCurriculoXML(dados[0], GetCaracteristicas(), array_fec, array_fef, array_fei, array_fee);
        }
    }
}
