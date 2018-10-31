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
            string cmp, string ema, string cnp, string img,
            string fac, string lin) {
            if (head == null) {
                head = new Empresa(usu, sen, nom, tel, tel1, tel2, cep, cid, est, end, num, bai, cmp, ema, cnp, img, fac, lin);
                tail = head;
            } else {
                tail.Next = new Empresa(usu, sen, nom, tel, tel1, tel2, cep, cid, est, end, num, bai, cmp, ema, cnp, img, fac, lin);
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

        public string getDado(string dado, int tgt) {
            dado = dado.ToLower();
            Empresa aux = head;
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
                    case "cnpj":
                        return aux.Cnpj;
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
                strings[i, 12] = aux.Complemento;
                strings[i, 13] = aux.Email;
                strings[i, 14] = aux.Cnpj;
                strings[i, 15] = aux.ImgDestino;
                strings[i, 16] = aux.Facebook;
                strings[i, 17] = aux.Linkedin;
                aux = aux.Next;
            }
            return strings;
        }
    }
}
