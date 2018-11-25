using System;
using System.Windows;
using System.Windows.Controls;

namespace awtj.Controles.SubControles {
    /// <summary>
    /// Interação lógica para UcFormExperiencia.xam
    /// </summary>
    public partial class UcFormExperiencia : UserControl {
        public UcFormExperiencia() {
            InitializeComponent();
        }

        public void SetDadosExperiencia(string emp, string car, string ini, string fim, string option) {
            TbEmpresa.Text = emp; TbCargo.Text = car;
            if (ini != "") {
                DateInicio.SelectedDate = DateTime.Parse(ini);
            }
            if (option == "True" && fim != "") {
                DateConclusao.SelectedDate = DateTime.Parse(fim);
                Check.IsChecked = true;
                DateConclusao.IsEnabled = true;
            }
        }

        public string GetTbEmpresa() {
            return TbEmpresa.Text;
        }
        public string GetTbCargo() {
            return TbCargo.Text;
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
        public bool GetCheckOption() {
            if (Check.IsChecked == true) {
                return true;
            } else return false;
        }

        private void Check_Checked(object sender, RoutedEventArgs e) {
            DateConclusao.IsEnabled = true;
        }

        private void Check_Unchecked(object sender, RoutedEventArgs e) {
            DateConclusao.IsEnabled = false;
        }
    }
}
