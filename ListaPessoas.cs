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
            string cmp, string ema, string gen, string img,
            string fac, string lin) {
            if (head == null) {
                head = new Pessoa(usu, sen, nom, sob, tel, tel1, tel2, cep, cid, est, end, num, bai, cmp, ema, gen, img, fac, lin);
                tail = head;
            } else {
                tail.Next = new Pessoa(usu, sen, nom, sob, tel, tel1, tel2, cep, cid, est, end, num, bai, cmp, ema, gen, img, fac, lin);
                tail = tail.Next;
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

        public string getDado(string dado, int tgt) {
            dado = dado.ToLower();
            Pessoa aux = head;
            if (tgt < Size()) {
                for (int i = 0; i < tgt; i++) {
                    aux = aux.Next;
                }
                switch (dado) {
                    case "usuario":
                        return aux.VarUsuario;
                    case "senha":
                        return aux.Senha;
                    case "nome":
                        return aux.Nome;
                    case "sobrenome":
                        return aux.Sobrenome;
                    case "telefone":
                        return aux.Telefone[0];
                    case "telefone1":
                        return aux.Telefone[1];
                    case "telefone2":
                        return aux.Telefone[2];
                    case "cep":
                        return aux.CEP;
                    case "cidade":
                        return aux.Cidade;
                    case "estado":
                        return aux.Estado;
                    case "endereco":
                        return aux.Endereco;
                    case "numero":
                        return aux.Numero;
                    case "bairro":
                        return aux.Bairro;
                    case "complemento":
                        return aux.Complemento;
                    case "email":
                        return aux.Email;
                    case "genero":
                        return aux.Genero;
                    case "imagem":
                        return aux.ImgDestino;
                    case "facebook":
                        return aux.Facebook;
                    case "linkedin":
                        return aux.Linkedin;
                    default:
                        MessageBox.Show("Dado Inexistente", "Erro");
                        return "";
                }
            } else {
                MessageBox.Show("Índice Inexistente", "Erro");
                return "";
            }
        }

        public string[,] getAll() {
            Pessoa aux = head;
            string[,] strings = new string[Size(), 19];
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
                strings[i, 13] = aux.Complemento;
                strings[i, 14] = aux.Email;
                strings[i, 15] = aux.Genero;
                strings[i, 16] = aux.ImgDestino;
                strings[i, 17] = aux.Facebook;
                strings[i, 18] = aux.Linkedin;
                aux = aux.Next;
            }
            return strings;
        }
    }
}
