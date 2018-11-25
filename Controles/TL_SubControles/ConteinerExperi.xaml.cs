using System.Collections;
using System.Windows.Controls;

namespace awtj.Controles.TL_SubControles {
    /// <summary>
    /// Interação lógica para ConteinerExperi.xam
    /// </summary>
    public partial class ConteinerExperi : UserControl {
        private ArrayList array = new ArrayList();
        private MetodosConteiner met = new MetodosConteiner();

        public ConteinerExperi() {
            InitializeComponent();
        }

        public ArrayList GetArray() {
            return array;
        }

        public void Limpar() {
            TbCargo.Clear();
            List.Items.Clear();
            array.Clear();
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            met.Adicionar(TbCargo.Text, array, List);
            met.Clear(TbCargo);
        }

        private void RemButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            met.RemoverUnico(array, List);
        }
    }
}
