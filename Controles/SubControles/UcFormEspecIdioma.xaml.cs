using System.Windows.Controls;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormEspecIdioma.xam
    /// </summary>
    public partial class UcFormEspecIdioma : UserControl {
        public UcFormEspecIdioma() {
            InitializeComponent();
        }

        public void SetDadosIdioma(string idi, string niv) {
            TbIdioma.Text = idi;
            SetNivel(niv);
        }

        private void SetNivel(string n) {
            for (int i = 0; i < CmbNivel.Items.Count; i++) {
                CmbNivel.SelectedIndex = i;
                if (CmbNivel.SelectedItem.ToString().Contains(n)) {
                    break;
                }
            }
        }

        public string GetIdioma() {
            return TbIdioma.Text;
        }

        public string GetNivel() {
            return CmbNivel.Text;
        }
    }
}
