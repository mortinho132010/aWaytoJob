using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace awtj.Controles {
    /// <summary>
    /// Interação lógica para PerfilPessoa.xam
    /// </summary>
    public partial class PerfilPessoa : UserControl {
        public PerfilPessoa() {
            InitializeComponent();
        }

        public string CopiaCola() {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog {
                DefaultExt = "jpg",
                Filter = "Imagem (*.jpg)|*.jpg"
            };
            Nullable<bool> result = open.ShowDialog();
            string des = null;
            if (result == true) {
                des = @".\Images\UserImages\" + Path.GetFileName(open.FileName);
                if (!Directory.Exists(@".\Images\UserImages")) {
                    Directory.CreateDirectory(@".\Images\UserImages");
                }
                File.Copy(open.FileName, des, true);
            }
            return des;
        }

        public void SetImage(string destino) {
            if (destino != null) {
                ImageBrush img = new ImageBrush {
                    ImageSource = new BitmapImage(new Uri(destino, UriKind.Relative))
                };
                img.Stretch = Stretch.Uniform;
                ImagePicker.Background = img;
                ImagePicker.Content = "";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            SetImage(CopiaCola());
        }
    }
}
