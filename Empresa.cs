using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awtj {
    class Empresa : Usuario{
        public Empresa(string usu, string sen, string nom, string tel, string end, string ema, string cnp) {
            varUsuario = usu;
            Senha = sen;
            Nome = nom;
            Telefone = tel;
            Endereco = end;
            Email = ema;
            Cnpj = cnp;
            Next = null;
        }

        public Empresa Next { set; get; }
        public string Cnpj { set; get; }
    }
}
