using System.Windows;

namespace awtj {
    public class ListaPessoas {
        private Pessoa head, tail;
        public ListaPessoas() {
            head = null;
            tail = null;
        }

        public void Cadastrar(string usu, string sen, string nom, string sob, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string cur, string ema, string gen, string img,
            string fac, string lin, string data) {
            if (head == null) {
                head = new Pessoa(usu, sen, nom, sob, tel, tel1, tel2, cep, cid, est, end, num, bai, cur, ema, gen, img, fac, lin, data);
                tail = head;
            } else {
                tail.Next = new Pessoa(usu, sen, nom, sob, tel, tel1, tel2, cep, cid, est, end, num, bai, cur, ema, gen, img, fac, lin, data);
                tail = tail.Next;
            }
        }

        public void SetUserData(int indice, string nom, string sob, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string img, string fac, string lin, string data) {
            Pessoa aux = head;
            if (Size() > indice) {
                for(int i = 0; i < indice; i++) {
                    aux = aux.Next;
                }
                aux.Alterar(nom, sob, tel, tel1, tel2, cep, cid, est, end, num, bai, img, fac, lin, data);
            } else {
                MessageBox.Show("AlterarCadastro(): Índice Inexistente", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public int Size() {
            Pessoa aux = head;
            int count = 0;
            while (aux != null) {
                count++;
                aux = aux.Next;
            }
            return count;
        }

        public string[] GetUserData(int indice) {
            Pessoa aux = head;
            string[] strings = new string[20];
            if (Size() > indice) {
                for (int i = 0; i < indice; i++) {
                    aux = aux.Next;
                }
                strings[0] = aux.VarUsuario;
                strings[1] = aux.Senha;
                strings[2] = aux.Nome;
                strings[3] = aux.Sobrenome;
                strings[4] = aux.Telefone[0];
                strings[5] = aux.Telefone[1];
                strings[6] = aux.Telefone[2];
                strings[7] = aux.CEP;
                strings[8] = aux.Cidade;
                strings[9] = aux.Estado;
                strings[10] = aux.Endereco;
                strings[11] = aux.Numero;
                strings[12] = aux.Bairro;
                strings[13] = aux.DirCurriculo;
                strings[14] = aux.Email;
                strings[15] = aux.Genero;
                strings[16] = aux.ImgDestino;
                strings[17] = aux.Facebook;
                strings[18] = aux.Linkedin;
                strings[19] = aux.Data;
            } else {
                MessageBox.Show("GetUserData(): Índice Inexistente", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return strings;
        }

        public string[,] getAll() {
            Pessoa aux = head;
            string[,] strings = new string[Size(), 20];
            for (int i = 0; i < Size(); i++) {
                strings[i, 0] = aux.VarUsuario;
                strings[i, 1] = aux.Senha;
                strings[i, 2] = aux.Nome;
                strings[i, 3] = aux.Sobrenome;
                strings[i, 4] = aux.Telefone[0];
                strings[i, 5] = aux.Telefone[1];
                strings[i, 6] = aux.Telefone[2];
                strings[i, 7] = aux.CEP;
                strings[i, 8] = aux.Cidade;
                strings[i, 9] = aux.Estado;
                strings[i, 10] = aux.Endereco;
                strings[i, 11] = aux.Numero;
                strings[i, 12] = aux.Bairro;
                strings[i, 13] = aux.DirCurriculo;
                strings[i, 14] = aux.Email;
                strings[i, 15] = aux.Genero;
                strings[i, 16] = aux.ImgDestino;
                strings[i, 17] = aux.Facebook;
                strings[i, 18] = aux.Linkedin;
                strings[i, 19] = aux.Data;
                aux = aux.Next;
            }
            return strings;
        }
    }
}
