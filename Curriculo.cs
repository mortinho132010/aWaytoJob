using System.Collections;

namespace awtj {
    public class Curriculo {
        //Profissional
        private string Atuacao { set; get; }
        private string Especif { set; get; }
        private string Escolar { set; get; }
        //Cursos
        private ArrayList CurDescr = new ArrayList();
        private ArrayList CurInsti = new ArrayList();
        private ArrayList CurNivel = new ArrayList();
        private ArrayList CurInici = new ArrayList();
        private ArrayList CurConcl = new ArrayList();
        //Ferramentas
        private ArrayList Ferramen = new ArrayList();
        private ArrayList FerNivel = new ArrayList();
        //Idiomas
        private ArrayList Idioma = new ArrayList();
        private ArrayList IdiNivel = new ArrayList();
        //Experiencia
        private ArrayList ExpEmpre = new ArrayList();
        private ArrayList ExpCargo = new ArrayList();
        private ArrayList ExpInici = new ArrayList();
        private ArrayList ExpOp = new ArrayList();
        private ArrayList ExpEncer = new ArrayList();

        public void SetInfoProfissional(string act, string esp, string esc) {
            Atuacao = act; Especif = esp; Escolar = esc;
        }

        public void SetCursos(string des, string ins, string niv, string dIni, string dCon) {
            CurDescr.Add(des); CurInsti.Add(ins); CurNivel.Add(niv);
            CurInici.Add(dIni); CurConcl.Add(dCon);
        }

        public void SetFerramentas(string fer, string niv) {
            Ferramen.Add(fer); FerNivel.Add(niv);
        }

        public void SetIdiomas(string idi, string niv) {
            Idioma.Add(idi); IdiNivel.Add(niv);
        }

        public void SetExperiencia(string emp, string car, string dIni, bool op, string dEnc) {
            ExpEmpre.Add(emp); ExpCargo.Add(car); ExpInici.Add(dIni);
            ExpOp.Add(op);
            if (op == true) {
                ExpEncer.Add(dEnc);
            } else ExpEncer.Add("");
        }

        public string[] GetInfoProfissional() {
            string[] strings = new string[3];
            strings[0] = Atuacao;
            strings[1] = Especif;
            strings[2] = Escolar;
            return strings;
        }

        public string[] GetCurso(int i) {
            string[] strings = new string[5];
            strings[0] = CurDescr[i].ToString();
            strings[1] = CurInsti[i].ToString();
            strings[2] = CurNivel[i].ToString();
            strings[3] = CurInici[i].ToString();
            strings[4] = CurConcl[i].ToString();
            return strings;
        }

        public string[] GetFerramentas(int i) {
            string[] strings = new string[2];
            strings[0] = Ferramen[i].ToString();
            strings[1] = FerNivel[i].ToString();
            return strings;
        }

        public string[] GetIdiomas(int i) {
            string[] strings = new string[2];
            strings[0] = Idioma[i].ToString();
            strings[1] = IdiNivel[i].ToString();
            return strings;
        }

        public string[] GetExperiencia(int i) {
            string[] strings = new string[5];
            strings[0] = ExpEmpre[i].ToString();
            strings[1] = ExpCargo[i].ToString();
            strings[2] = ExpInici[i].ToString();
            strings[3] = ExpOp[i].ToString();
            strings[4] = ExpEncer[i].ToString();
            return strings;
        }
    }
}
