using awtj.Controles.TL_SubControles;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para FormTimeLine.xam
    /// </summary>
    public partial class FormTimeLine : UserControl {
        Storyboard ani;
        private int Indice { set; get; }

        private FormPostar post;
        //array de postagens
        private ArrayList postagens = new ArrayList();

        private ListaPessoas listp;
        private ListaEmpresas liste;

        private XmlMetodos xml = new XmlMetodos();

        public FormTimeLine(int ind, ListaPessoas listaPessoas, ListaEmpresas listaEmpresas) {
            listp = listaPessoas;
            liste = listaEmpresas;
            InitializeComponent();
            Indice = ind;
        }

        public ListaEmpresas GetListaEmpresas() {
            return liste;
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e) {
            TlConteiner.Children.Clear();
            post = new FormPostar(Indice, GetListaEmpresas(), postagens);
            TlConteiner.Children.Add(post);
        }

        private void ExpandButton_Checked(object sender, System.Windows.RoutedEventArgs e) {
            ani = FindResource("Stage2") as Storyboard;
            ani.Begin();
        }

        private void ExpandButton_Unchecked(object sender, System.Windows.RoutedEventArgs e) {
            ani = FindResource("Stage1") as Storyboard;
            ani.Begin();
        }
    }
}
