using System;
using System.Windows;
using System.Windows.Controls;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormEspec.xam
    /// </summary>
    public partial class UcFormEspecCurso : UserControl {
        private ListBox list = new ListBox();

        public UcFormEspecCurso() {
            InitializeComponent();
        }

        public ListBox SetPopupList(TextBox box) {
            double left = box.Margin.Left;
            double top = box.Margin.Top;
            double right = box.Margin.Right;
            list.Margin = new Thickness(left, top + 25, right, 0);
            conteiner.Children.Add(list);
            return list;
        }

        public string GetTbDescricao() {
            return TbCurso.Text;
        }
        public string GetTbInstituicao() {
            return TbInstituicao.Text;
        }
        public string GetDateInicio() {
            try {
                return DateInicio.SelectedDate.Value.ToShortDateString();
            } catch {
                return DateTime.Now.ToShortDateString();
            }
        }
        public string GetDateConclusao() {
            try {
                return DateConclusao.SelectedDate.Value.ToShortDateString();
            } catch {
                return DateTime.Now.ToShortDateString();
            }
        }
        public string GetCmbNivel() {
            return CmbNivel.Text;
        }

        public void SetDadosCurso(string curso, string inst, string nivel, string ini, string fim){
            TbCurso.Text = curso; TbInstituicao.Text = inst;
            DateInicio.SelectedDate = DateTime.Parse(ini);
            DateConclusao.SelectedDate = DateTime.Parse(fim);
            SetNivel(nivel);
        }

        private void SetNivel(string n) {
            for (int i = 0; i < CmbNivel.Items.Count; i++) {
                CmbNivel.SelectedIndex = i;
                if (CmbNivel.SelectedItem.ToString().Contains(n)) {
                    break;
                }
            }
        }

        private void TbCurso_GotFocus(object sender, RoutedEventArgs e) {
            list = SetPopupList(TbCurso);
        }

        private void TbCurso_LostFocus(object sender, RoutedEventArgs e) {
            conteiner.Children.Remove(list);
        }

        private void TbInstituicao_GotFocus(object sender, RoutedEventArgs e) {
            list = SetPopupList(TbInstituicao);
        }

        private void TbInstituicao_LostFocus(object sender, RoutedEventArgs e) {
            conteiner.Children.Remove(list);
        }
    }
}
