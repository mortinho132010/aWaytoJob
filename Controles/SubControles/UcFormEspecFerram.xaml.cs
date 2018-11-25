using System.Windows.Controls;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormEspecFerram.xam
    /// </summary>
    public partial class UcFormEspecFerram : UserControl {
        public UcFormEspecFerram() {
            InitializeComponent();
        }

        public void SetDadosFerramentas(string fer, string niv) {
            TbFerramenta.Text = fer;
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

        public string GetFerramenta() {
            return TbFerramenta.Text;
        }

        public string GetNivel() {
            return CmbNivel.Text;
        }
    }
}
