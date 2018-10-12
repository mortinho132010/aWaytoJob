using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awtj {
    class ListaPessoas {
        private Pessoa head, tail;
        public ListaPessoas() {
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
            }
            return count;
        }

        public string[] getUsuarios() {
            Pessoa aux = head;
            string[] strings = new string[Size()];
            for (int i = 0; i < strings.Length; i++) {
                strings[i] = aux.varUsuario;
            }
            return strings;
        }

        public string[] getSenhas() {
            Pessoa aux = head;
            string[] strings = new string[Size()];
            for (int i = 0; i < strings.Length; i++) {
                strings[i] = aux.Senha;
            }
            return strings;
        }
    }
}
