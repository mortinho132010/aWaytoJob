using awtj.Controles.TL_SubControles;
using System;
using System.Collections;

namespace awtj {
    public class Postagem{
        private ListaEmpresas list;
        private readonly string[] dados;

        public string Data { set; get; }
        public string Hora { set; get; }
        public string Usuario { set; get; }
        public string Nome { set; get; }
        public string CompEndereco { set; get; }
        public string Cargo { set; get; }
        public string NumVagas { set; get; }
        public bool? Desejavel { set; get; }
        public string[,] DesCur { set; get; }
        public string[,] DesFer { set; get; }
        public string[,] DesIdi { set; get; }
        public string[] DesExp { set; get; }
        public bool? Necessario { set; get; }
        public string[,] NesCur { set; get; }
        public string[,] NesFer { set; get; }
        public string[,] NesIdi { set; get; }
        public string[] NesExp { set; get; }
        public ArrayList Inscritos = new ArrayList();
        public string Tipo { set; get; }
        //Avenida Luís Bitencourt, 287 - Itagaçaba, Cruzeiro - State of São Paulo
        public Postagem(int id, string car, string num, bool? desOp, bool? nesOp, Requisitos des, Requisitos nes, ListaEmpresas le) {
            list = le;
            dados = list.GetUserData(id);
            Data = DateTime.Today.ToShortDateString(); Hora = DateTime.Now.ToShortTimeString();
            Usuario = dados[0]; Nome = dados[2]; CompEndereco = dados[9] + ", " + dados[10] + " - " + dados[11] + ", " + dados[7];
            Cargo = car; NumVagas = num;
            Desejavel = desOp; Necessario = nesOp;
            if(Desejavel == true) {
                ConteinerCurso cur = des.GetConteinerCurso();
                ConteinerFerram fer = des.GetConteinerFerram();
                ConteinerIdioma idi = des.GetConteinerIdioma();
                ConteinerExperi exp = des.GetConteinerExperi();
                SetDesejavel(cur.GetArray(), fer.GetArray(), idi.GetArray(), exp.GetArray());
            }
            if (Necessario == true) {
                ConteinerCurso cur = nes.GetConteinerCurso();
                ConteinerFerram fer = nes.GetConteinerFerram();
                ConteinerIdioma idi = nes.GetConteinerIdioma();
                ConteinerExperi exp = nes.GetConteinerExperi();
                SetDesejavel(cur.GetArray(), fer.GetArray(), idi.GetArray(), exp.GetArray());
            }
            Tipo = "empresa";
        }

        public Postagem() { }

        public void AdicionarInscrito(string user) {
            Inscritos.Add(user);
        }

        public void RemoverInscrito(string user) {
            Inscritos.Remove(user);
        }

        public void SetDesejavel(ArrayList cur, ArrayList fer, ArrayList idi, ArrayList exp) {
            if(cur.Count > 0 && cur != null) {
                DesCur = new string[cur.Count,2];
                for(int i = 0; i < cur.Count; i++) {
                    string[] d = (string[]) cur[i];
                    DesCur[i, 0] = d[0];
                    DesCur[i, 1] = d[1];
                }
            } else {
                DesCur = new string[1,2];
                DesCur[0, 0] = "";
                DesCur[0, 1] = "";
            }
            if (fer.Count > 0 && fer != null) {
                DesFer = new string[fer.Count, 2];
                for (int i = 0; i < fer.Count; i++) {
                    string[] d = (string[]) fer[i];
                    DesFer[i, 0] = d[0];
                    DesFer[i, 1] = d[1];
                }
            } else {
                DesFer = new string[1, 2];
                DesFer[0, 0] = "";
                DesFer[0, 1] = "";
            }
            if (idi.Count > 0 && idi != null) {
                DesIdi = new string[idi.Count, 2];
                for (int i = 0; i < idi.Count; i++) {
                    string[] d = (string[]) idi[i];
                    DesIdi[i, 0] = d[0];
                    DesIdi[i, 1] = d[1];
                }
            } else {
                DesIdi = new string[1, 2];
                DesIdi[0, 0] = "";
                DesIdi[0, 1] = "";
            }
            if (exp.Count > 0 && exp != null) {
                DesExp = new string[exp.Count];
                for (int i = 0; i < exp.Count; i++) {
                    DesExp[i] = exp[i].ToString();
                }
            } else {
                DesExp = new string[1];
                DesExp[0] = "";
            }
        }

        public void SetNecessario(ArrayList cur, ArrayList fer, ArrayList idi, ArrayList exp) {
            if (cur.Count > 0) {
                NesCur = new string[cur.Count, 2];
                for (int i = 0; i < cur.Count; i++) {
                    string[] d = (string[]) cur[i];
                    NesCur[i, 0] = d[0];
                    NesCur[i, 1] = d[1];
                }
            } else {
                NesCur = new string[1, 2];
                NesCur[0, 0] = "";
                NesCur[0, 1] = "";
            }
            if (fer.Count > 0) {
                NesFer = new string[fer.Count, 2];
                for (int i = 0; i < fer.Count; i++) {
                    string[] d = (string[]) fer[i];
                    NesFer[i, 0] = d[0];
                    NesFer[i, 1] = d[1];
                }
            } else {
                NesFer = new string[1, 2];
                NesFer[0, 0] = "";
                NesFer[0, 1] = "";
            }
            if (idi.Count > 0) {
                NesIdi = new string[idi.Count, 2];
                for (int i = 0; i < idi.Count; i++) {
                    string[] d = (string[]) idi[i];
                    NesIdi[i, 0] = d[0];
                    NesIdi[i, 1] = d[1];
                }
            } else {
                NesIdi = new string[1, 2];
                NesIdi[0, 0] = "";
                NesIdi[0, 1] = "";
            }
            if (exp.Count > 0) {
                NesExp = new string[exp.Count];
                for (int i = 0; i < exp.Count; i++) {
                    string[] d = (string[]) exp[i];
                    NesExp[i] = d[0];
                }
            } else {
                NesExp = new string[1];
                NesExp[0] = "";
            }
        }
    }
}
