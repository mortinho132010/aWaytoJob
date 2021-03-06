﻿namespace awtj {
    class Empresa : Usuario {

        public Empresa Next { set; get; }
        public string Cnpj { set; get; }

        public Empresa(string usu, string sen, string nom, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string ema, string cnp, string img,
            string fac, string lin, string data) {
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
            Email = ema;
            Cnpj = cnp;
            ImgDestino = img;
            Facebook = fac;
            Linkedin = lin;
            Data = data;
            conexoes = new System.Collections.ArrayList();
            Next = null;
        }

        public void Alterar(string nom, string tel, string tel1, 
            string tel2, string cep, string cid, string est,
            string end, string num, string bai, string cnp, string img,
            string fac, string lin, string data) {
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
            Cnpj = cnp;
            ImgDestino = img;
            Facebook = fac;
            Linkedin = lin;
            Data = data;
        }

        public void AdicionarConxeao(object post) {
            conexoes.Add(post);
        }

        public void RemoverPostagem(object post) {
            conexoes.Remove(post);
        }
    }
}
