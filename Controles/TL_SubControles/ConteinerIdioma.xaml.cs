using System.Collections;
using System.Windows.Controls;

namespace awtj.Controles.TL_SubControles {
    /// <summary>
    /// Interação lógica para ConteinerIdioma.xam
    /// </summary>
    public partial class ConteinerIdioma : UserControl {
        private string[] dados;
        private ArrayList array = new ArrayList();
        private MetodosConteiner met = new MetodosConteiner();

        public ConteinerIdioma() {
            InitializeComponent();
        }

        public void SetDados(string d, string n) {
            dados = new string[2];
            dados[0] = d;
            dados[1] = n;
        }

        public string[] GetDados() {
            return dados;
        }

        public ArrayList GetArray() {
            return array;
        }

        public void Limpar() {
            TbIdioma.Clear();
            CmbNivel.SelectedIndex = 0;
            List.Items.Clear();
            array.Clear();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            SetDados(TbIdioma.Text, CmbNivel.Text);
            met.Adicionar(GetDados(), array, List);
            met.Clear(TbIdioma, CmbNivel);
        }

        private void RemButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            met.Remover(array, List);
        }
    }
}
