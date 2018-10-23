using System.Windows;

namespace awtj {
    public class ListaPessoas {
        private Pessoa head, tail;
        public ListaPessoas() {
            head = null;
            tail = null;
        }
        public void Reiniciar() {
            head = null;
            tail = null;
        }
        public void Cadastrar(string usu, string sen, string nom, string tel, string end, string ema, string gen) {
            if (head == null) {
                head = new Pessoa(usu, sen, nom, tel, end, ema, gen);
                tail = head;
            } else {
                tail.Next = new Pessoa(usu, sen, nom, tel, end, ema, gen);
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
                        return aux.varUsuario;
                    case "senha":
                        return aux.Senha;
                    case "nome":
                        return aux.Nome;
                    case "telefone":
                        return aux.Telefone;
                    case "endereco":
                        return aux.Endereco;
                    case "email":
                        return aux.Email;
                    case "genero":
                        return aux.Genero;
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
            string[,] strings = new string[Size(), 7];
            for (int i = 0; i < Size(); i++) {
                strings[i, 0] = aux.varUsuario;
                strings[i, 1] = aux.Senha;
                strings[i, 2] = aux.Nome;
                strings[i, 3] = aux.Telefone;
                strings[i, 4] = aux.Endereco;
                strings[i, 5] = aux.Email;
                strings[i, 6] = aux.Genero;
                aux = aux.Next;
            }
            return strings;
        }
    }
}
