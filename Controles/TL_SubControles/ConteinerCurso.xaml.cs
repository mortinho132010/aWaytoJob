using System.Collections;
using System.Windows.Controls;

namespace awtj.Controles.TL_SubControles {
    /// <summary>
    /// Interação lógica para Conteiner.xam
    /// </summary>
    public partial class ConteinerCurso : UserControl {
        private string[] dados;
        private ArrayList array = new ArrayList();
        private MetodosConteiner met = new MetodosConteiner();

        public ConteinerCurso() {
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
            TbCurso.Clear();
            CmbNivel.SelectedIndex = 0;
            List.Items.Clear();
            array.Clear();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            SetDados(TbCurso.Text, CmbNivel.Text);
            met.Adicionar(GetDados(), array, List);
            met.Clear(TbCurso, CmbNivel);
        }

        private void RemButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            met.Remover(array, List);
        }
    }
}
