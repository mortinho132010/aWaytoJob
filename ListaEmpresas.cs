using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awtj {
    class ListaEmpresas {
        private Empresa head, tail;
        public ListaEmpresas() {
            head = null;
            tail = null;
        }

        public void Cadastrar(string usu, string sen, string nom, string tel, string end, string ema, string cnp) {
            if (head == null) {
                head = new Empresa(usu, sen, nom, tel, end, ema, cnp);
                tail = head;
            } else {
                tail.Next = new Empresa(usu, sen, nom, tel, end, ema, cnp);
                tail = tail.Next;
            }
        }

        public int Size() {
            Empresa aux = head;
            int count = 0;
            while (aux != null) {
                count++;
            }
            return count;
        }

        public string[] getUsuarios() {
            Empresa aux = head;
            string[] strings = new string[Size()];
            for (int i = 0; i < strings.Length; i++) {
                strings[i] = aux.varUsuario;
            }
            return strings;
        }

        public string[] getSenhas() {
            Empresa aux = head;
            string[] strings = new string[Size()];
            for (int i = 0; i < strings.Length; i++) {
                strings[i] = aux.Senha;
            }
            return strings;
        }
    }
}
