using System.Windows;

namespace awtj {
    public class ListaEmpresas {
        private Empresa head, tail;
        public ListaEmpresas() {
            head = null;
            tail = null;
        }

        public void Cadastrar(string usu, string sen, string nom, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string ema, string cnp, string img,
            string fac, string lin, string data) {
            if (head == null) {
                head = new Empresa(usu, sen, nom, tel, tel1, tel2, cep, cid, est, end, num, bai, ema, cnp, img, fac, lin, data);
                tail = head;
            } else {
                tail.Next = new Empresa(usu, sen, nom, tel, tel1, tel2, cep, cid, est, end, num, bai, ema, cnp, img, fac, lin, data);
                tail = tail.Next;
            }
        }

        public int Size() {
            Empresa aux = head;
            int count = 0;
            while (aux != null) {
                count++;
                aux = aux.Next;
            }
            return count;
        }

        public string[] GetUserData(int indice) {
            Empresa aux = head;
            string[] strings = new string[18];
            if (Size() > indice) {
                for (int i = 0; i < indice; i++) {
                    aux = aux.Next;
                }
                strings[0] = aux.VarUsuario;
                strings[1] = aux.Senha;
                strings[2] = aux.Nome;
                strings[3] = aux.Telefone[0];
                strings[4] = aux.Telefone[1];
                strings[5] = aux.Telefone[2];
                strings[6] = aux.CEP;
                strings[7] = aux.Cidade;
                strings[8] = aux.Estado;
                strings[9] = aux.Endereco;
                strings[10] = aux.Numero;
                strings[11] = aux.Bairro;
                strings[12] = aux.Email;
                strings[13] = aux.Cnpj;
                strings[14] = aux.ImgDestino;
                strings[15] = aux.Facebook;
                strings[16] = aux.Linkedin;
                strings[17] = aux.Data;
            } else {
                MessageBox.Show("GetUserData(): Índice Inexistente", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return strings;
        }

        public string[,] getAll() {
            Empresa aux = head;
            string[,] strings = new string[Size(), 18];
            for (int i = 0; i < Size(); i++) {
                strings[i, 0] = aux.VarUsuario;
                strings[i, 1] = aux.Senha;
                strings[i, 2] = aux.Nome;
                strings[i, 3] = aux.Telefone[0];
                strings[i, 4] = aux.Telefone[1];
                strings[i, 5] = aux.Telefone[2];
                strings[i, 6] = aux.CEP;
                strings[i, 7] = aux.Cidade;
                strings[i, 8] = aux.Estado;
                strings[i, 9] = aux.Endereco;
                strings[i, 10] = aux.Numero;
                strings[i, 11] = aux.Bairro;
                strings[i, 12] = aux.Email;
                strings[i, 13] = aux.Cnpj;
                strings[i, 14] = aux.ImgDestino;
                strings[i, 15] = aux.Facebook;
                strings[i, 16] = aux.Linkedin;
                strings[i, 17] = aux.Data;
                aux = aux.Next;
            }
            return strings;
        }
    }
}
