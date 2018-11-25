using System.Windows.Controls;

namespace awtj.Controles.TL_SubControles {
    /// <summary>
    /// Interação lógica para PostViewer.xam
    /// </summary>
    public partial class PostViewer : UserControl {

        private Postagem conteudo;
        private int Indice { set; get; }
        private string ImgDestino { set; get; }

        public PostViewer(int id, Postagem post) {
            InitializeComponent();
            conteudo = post;
            Indice = id;
        }

        public void SetDados() {

        }
    }
}
