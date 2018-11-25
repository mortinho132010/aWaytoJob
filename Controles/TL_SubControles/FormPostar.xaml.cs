using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace awtj.Controles.TL_SubControles {
    /// <summary>
    /// Interação lógica para Postar.xam
    /// </summary>
    public partial class FormPostar : UserControl {

        private int Indice { set; get; }
        private string Cargo { set; get; }
        private string Numero { set; get; }
        private bool? Desejavel { set; get; }
        private bool? Necessario { set; get; }

        private XmlMetodos xml = new XmlMetodos();
        private ListaEmpresas Le;

        //array de postagens
        private ArrayList postagens = new ArrayList();

        //controles de usuario
        private Requisitos des = new Requisitos();
        private Requisitos nes = new Requisitos() {
            Background = new SolidColorBrush(Color.FromArgb(100, 207, 207, 209))
        };

        public FormPostar(int ind, ListaEmpresas l, ArrayList posts) {
            InitializeComponent();
            SetCmbNumero();
            Le = l;
            Indice = ind;
        }
        public bool? GetChkDesejavel() {
            return ChkDesejavel.IsChecked;
        }
        public bool? GetChkNecessario() {
            return ChkNecessario.IsChecked;
        }
        //define o combo box com 400 itens
        public void SetCmbNumero() {
            for (int i = 1; i <= 400; i++) {
                CmbNumero.Items.Add(i);
            }
            CmbNumero.SelectedIndex = 0;
        }
        //armazena as informações inseridas no formulario
        public void SetPostInfo() {
            Cargo = TbCargo.Text;
            Numero = CmbNumero.Text;
            Desejavel = GetChkDesejavel();
            Necessario = GetChkNecessario();
        }
        //define o formulário a ser exibido pelo conteiner através do combo box
        private void ReqCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ReqCombo.SelectedIndex == 0) {
                TopConteiner.Children.Clear();
                TopConteiner.Children.Add(des);
            } else {
                TopConteiner.Children.Clear();
                TopConteiner.Children.Add(nes);
            }
        }

        private void Clear() {
            TbCargo.Clear(); CmbNumero.SelectedIndex = 0;
            ReqCombo.SelectedIndex = 0;
            ChkDesejavel.IsChecked = false;
            ChkNecessario.IsChecked = false;
        }

        public void Postar() {
            SetPostInfo();
            Postagem post = new Postagem(Indice, Cargo, Numero, Desejavel, Necessario, des, nes, Le);
            postagens.Add(post);
            xml.SetPostagemXml(postagens);
            Clear();
            des.ClearAll(); nes.ClearAll();
        }

        private void BtnPostar_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (TbCargo.Text == "") {
                MessageBox.Show("Insira o cargo a qual esta vaga pertence.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            } else if (GetChkDesejavel() == false && GetChkNecessario() == false) {
                MessageBox.Show("Selecione o que deseja inserir, Desejável e/ou Necessário.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            } else if (GetChkDesejavel() == true && des.CheckCondition() == false || GetChkNecessario() == true && nes.CheckCondition() == false) {
                MessageBox.Show("Você não pode postar uma vaga em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            } else {
                Postar();
            }
        }
    }
}
