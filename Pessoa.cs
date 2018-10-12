using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awtj {
    class Pessoa : Usuario{
        public Pessoa(string usu, string sen, string nom, string tel, string end, string ema, string gen) {
            varUsuario = usu;
            Senha = sen;
            Nome = nom;
            Telefone = tel;
            Endereco = end;
            Email = ema;
            Genero = gen;
            Next = null;
        }

        public Pessoa Next { set; get; }
        public string Genero { set; get; }
    }
}
