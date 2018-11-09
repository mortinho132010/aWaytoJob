namespace awtj {
    class Pessoa : Usuario {
        public Pessoa(string usu, string sen, string nom, string sob, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string cur, string ema, string gen, string img,
            string fac, string lin, string data) {
            VarUsuario = usu;
            Senha = sen;
            Nome = nom;
            Sobrenome = sob;
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
            DirCurriculo = cur;
            Email = ema;
            Genero = gen;
            ImgDestino = img;
            Facebook = fac;
            Linkedin = lin;
            Data = data;
            Next = null;
        }
        public void Alterar(string nom, string sob, string tel,
            string tel1, string tel2, string cep, string cid,
            string est, string end, string num, string bai,
            string img, string fac, string lin,string data) {
            Nome = nom;
            Sobrenome = sob;
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
            ImgDestino = img;
            Facebook = fac;
            Linkedin = lin;
            Data = data;
        }
        public Pessoa Next { set; get; }
        public string Sobrenome { set; get; }
        public string Genero { set; get; }
        public string DirCurriculo { set; get; }
    }
}
