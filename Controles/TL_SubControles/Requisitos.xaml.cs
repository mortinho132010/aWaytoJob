using System.Windows.Controls;

namespace awtj.Controles.TL_SubControles {
    /// <summary>
    /// Interação lógica para Requisitos.xam
    /// </summary>
    public partial class Requisitos : UserControl {
        //formulários
        private ConteinerCurso cur = new ConteinerCurso();
        private ConteinerFerram fer = new ConteinerFerram();
        private ConteinerIdioma idi = new ConteinerIdioma();
        private ConteinerExperi exp = new ConteinerExperi();

        public Requisitos() {
            InitializeComponent();
        }

        public ConteinerCurso GetConteinerCurso() {
            return cur;
        }
        public ConteinerFerram GetConteinerFerram() {
            return fer;
        }
        public ConteinerIdioma GetConteinerIdioma() {
            return idi;
        }
        public ConteinerExperi GetConteinerExperi() {
            return exp;
        }

        public void ClearAll() {
            cur.Limpar(); fer.Limpar(); idi.Limpar(); exp.Limpar();
        }

        public bool CheckCondition() {
            if (cur.GetArray() == null && fer.GetArray() == null && idi.GetArray() == null && exp.GetArray() == null) {
                return false;
            } else if (cur.GetArray().Count <= 0 && fer.GetArray().Count <= 0 && idi.GetArray().Count <= 0 && exp.GetArray().Count <= 0) {
                return false;
            } else {
                return true;
            }
        }

        private void RdCurso_Checked(object sender, System.Windows.RoutedEventArgs e) {
            ReqConteiner.Children.Clear();
            ReqConteiner.Children.Add(cur);
        }

        private void RdFerramenta_Checked(object sender, System.Windows.RoutedEventArgs e) {
            ReqConteiner.Children.Clear();
            ReqConteiner.Children.Add(fer);
        }

        private void RdIdioma_Checked(object sender, System.Windows.RoutedEventArgs e) {
            ReqConteiner.Children.Clear();
            ReqConteiner.Children.Add(idi);
        }

        private void RdExperiencia_Checked(object sender, System.Windows.RoutedEventArgs e) {
            ReqConteiner.Children.Clear();
            ReqConteiner.Children.Add(exp);
        }
    }
}
