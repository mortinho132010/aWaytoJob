using System.Collections;
using System.Windows.Controls;

namespace awtj.Controles.TL_SubControles {
    public class MetodosConteiner {
        public MetodosConteiner() { }

        public void Adicionar(string[] d, ArrayList array, ListBox list) {
            if (d[0] != "") {
                list.Items.Clear();
                array.Add(d);
                foreach (var ele in array) {
                    string[] x = (string[]) ele;
                    list.Items.Add(x[0] + " - " + x[1]);
                }
            }
        }

        public void Adicionar(string d, ArrayList array, ListBox list) {
            if (d != "") {
                list.Items.Clear();
                array.Add(d);
                foreach (var ele in array) {
                    list.Items.Add(ele);
                }
            }
        }

        public void Remover(ArrayList array, ListBox list) {
            if (list.SelectedIndex != -1) {
                array.RemoveAt(list.SelectedIndex);
                list.Items.Clear();
                foreach (var ele in array) {
                    string[] x = (string[]) ele;
                    list.Items.Add(x[0] + " - " + x[1]);
                }
            }
        }

        public void RemoverUnico(ArrayList array, ListBox list) {
            if (list.SelectedIndex != -1) {
                array.RemoveAt(list.SelectedIndex);
                list.Items.Clear();
                foreach (var ele in array) {
                    list.Items.Add(ele);
                }
            }
        }

        public void Clear(TextBox t, ComboBox c) {
            t.Clear(); c.SelectedIndex = 0;
        }

        public void Clear(TextBox t) {
            t.Clear();
        }
    }
}
