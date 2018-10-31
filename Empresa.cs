using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awtj {
    class Empresa : Usuario{
        public Empresa(string usu, string sen, string nom, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string cmp, string ema, string cnp, string img,
            string fac, string lin) {
            VarUsuario = usu;
            Senha = sen;
            Nome = nom;
            Telefone = new string[3];
            Telefone[0] = tel;
            Telefone[1] = tel1;
            Telefone[2] = tel2;
            CEP = cep;
            Cidade = cid;
            Estado = est;
            Endereco = end;
            Numero = num;
            Bairro = bai;
            Complemento = cmp;
            Email = ema;
            Cnpj = cnp;
            ImgDestino = img;
            Facebook = fac;
            Linkedin = lin;
            Next = null;
        }

        public Empresa Next { set; get; }
        public string Cnpj { set; get; }
    }
}
