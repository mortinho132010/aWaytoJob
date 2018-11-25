using awtj.Controles;
using awtj.Controles.SubControles;
using System;
using System.Collections;
using System.Windows;
using System.Xml;

namespace awtj {
    class XmlMetodos {

        public void LerXml(ListaPessoas pList, ListaEmpresas eList) {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load(@".\Contas\dados.xml");
            } catch {
                XmlTextWriter dxml = new XmlTextWriter(@".\Contas\dados.xml", null);
                dxml.WriteStartDocument();
                dxml.WriteStartElement("USUARIOS");
                dxml.WriteFullEndElement();
                dxml.Close();
                xml.Load(@".\Contas\dados.xml");
            }
            XmlNodeList pes, emp;
            pes = xml.GetElementsByTagName("PESSOAS");
            emp = xml.GetElementsByTagName("EMPRESAS");
            for (int i = 0; i < pes.Count; i++) {
                pList.Cadastrar(pes[i]["usuario"].InnerText, pes[i]["senha"].InnerText, pes[i]["nome"].InnerText, pes[i]["sobrenome"].InnerText,
                    pes[i]["telefone"].InnerText, pes[i]["telefone1"].InnerText, pes[i]["telefone2"].InnerText, pes[i]["cep"].InnerText,
                    pes[i]["cidade"].InnerText, pes[i]["estado"].InnerText, pes[i]["endereco"].InnerText, pes[i]["numero"].InnerText,
                    pes[i]["bairro"].InnerText, pes[i]["curriculo"].InnerText, pes[i]["email"].InnerText, pes[i]["genero"].InnerText,
                    pes[i]["imagem"].InnerText, pes[i]["facebook"].InnerText, pes[i]["linkedin"].InnerText, pes[i]["data"].InnerText);
            }
            for (int i = 0; i < emp.Count; i++) {
                eList.Cadastrar(emp[i]["usuario"].InnerText, emp[i]["senha"].InnerText, emp[i]["nome"].InnerText,
                    emp[i]["telefone"].InnerText, emp[i]["telefone1"].InnerText, emp[i]["telefone2"].InnerText, emp[i]["cep"].InnerText,
                    emp[i]["cidade"].InnerText, emp[i]["estado"].InnerText, emp[i]["endereco"].InnerText, emp[i]["numero"].InnerText,
                    emp[i]["bairro"].InnerText, emp[i]["email"].InnerText, emp[i]["cnpj"].InnerText,
                    emp[i]["imagem"].InnerText, emp[i]["facebook"].InnerText, emp[i]["linkedin"].InnerText, emp[i]["data"].InnerText);
            }
        }

        public void GuardarXml(ListaPessoas pList, ListaEmpresas eList) {
            try {
                XmlTextWriter dxml = new XmlTextWriter(@".\Contas\dados.xml", null);
                string[,] pessoas = pList.GetAll();
                string[,] empresas = eList.GetAll();
                dxml.WriteStartDocument();
                dxml.Formatting = Formatting.Indented;
                dxml.WriteStartElement("USUARIOS");
                for (int i = 0; i < pList.Size(); i++) {
                    dxml.WriteStartElement("PESSOAS");
                    dxml.WriteAttributeString("id", "" + i);
                    dxml.WriteElementString("usuario", pessoas[i, 0]);
                    dxml.WriteElementString("senha", pessoas[i, 1]);
                    dxml.WriteElementString("nome", pessoas[i, 2]);
                    dxml.WriteElementString("sobrenome", pessoas[i, 3]);
                    dxml.WriteElementString("telefone", pessoas[i, 4]);
                    dxml.WriteElementString("telefone1", pessoas[i, 5]);
                    dxml.WriteElementString("telefone2", pessoas[i, 6]);
                    dxml.WriteElementString("cep", pessoas[i, 7]);
                    dxml.WriteElementString("cidade", pessoas[i, 8]);
                    dxml.WriteElementString("estado", pessoas[i, 9]);
                    dxml.WriteElementString("endereco", pessoas[i, 10]);
                    dxml.WriteElementString("numero", pessoas[i, 11]);
                    dxml.WriteElementString("bairro", pessoas[i, 12]);
                    dxml.WriteElementString("curriculo", pessoas[i, 13]);
                    dxml.WriteElementString("email", pessoas[i, 14]);
                    dxml.WriteElementString("genero", pessoas[i, 15]);
                    dxml.WriteElementString("imagem", pessoas[i, 16]);
                    dxml.WriteElementString("facebook", pessoas[i, 17]);
                    dxml.WriteElementString("linkedin", pessoas[i, 18]);
                    dxml.WriteElementString("data", pessoas[i, 19]);
                    dxml.WriteEndElement();
                }
                for (int i = 0; i < eList.Size(); i++) {
                    dxml.WriteStartElement("EMPRESAS");
                    dxml.WriteAttributeString("id", "" + i);
                    dxml.WriteElementString("usuario", empresas[i, 0]);
                    dxml.WriteElementString("senha", empresas[i, 1]);
                    dxml.WriteElementString("nome", empresas[i, 2]);
                    dxml.WriteElementString("telefone", empresas[i, 3]);
                    dxml.WriteElementString("telefone1", empresas[i, 4]);
                    dxml.WriteElementString("telefone2", empresas[i, 5]);
                    dxml.WriteElementString("cep", empresas[i, 6]);
                    dxml.WriteElementString("cidade", empresas[i, 7]);
                    dxml.WriteElementString("estado", empresas[i, 8]);
                    dxml.WriteElementString("endereco", empresas[i, 9]);
                    dxml.WriteElementString("numero", empresas[i, 10]);
                    dxml.WriteElementString("bairro", empresas[i, 11]);
                    dxml.WriteElementString("email", empresas[i, 12]);
                    dxml.WriteElementString("cnpj", empresas[i, 13]);
                    dxml.WriteElementString("imagem", empresas[i, 14]);
                    dxml.WriteElementString("facebook", empresas[i, 15]);
                    dxml.WriteElementString("linkedin", empresas[i, 16]);
                    dxml.WriteElementString("data", empresas[i, 17]);
                    dxml.WriteEndElement();
                }
                dxml.WriteFullEndElement();
                dxml.Close();
            } catch (Exception ex) {
                MessageBox.Show("Erro ao Guardar XML: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string[] ComparaXml(string usu, string sen) {
            string[] dados = new string[3];
            dados[2] = "false";
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\Contas\dados.xml");
            XmlNodeList usuarios;
            usuarios = xml.GetElementsByTagName("PESSOAS");
            for (int i = 0; i < usuarios.Count; i++) {
                if (usuarios[i]["usuario"].InnerText == usu && usuarios[i]["senha"].InnerText == sen) {
                    dados[0] = "" + i;
                    dados[1] = "PESSOAS";
                    dados[2] = "true";
                    break;
                }
            }
            usuarios = xml.GetElementsByTagName("EMPRESAS");
            for (int i = 0; i < usuarios.Count; i++) {
                if (usuarios[i]["usuario"].InnerText == usu && usuarios[i]["senha"].InnerText == sen) {
                    dados[0] = "" + i;
                    dados[1] = "EMPRESAS";
                    dados[2] = "true";
                    break;
                }
            }
            return dados;
        }

        public string[] GetDados(int ind, string tip) {
            string[] dados = new string[20];
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\Contas\dados.xml");
            XmlNodeList list = xml.GetElementsByTagName(tip);
            if (tip == "PESSOAS") {
                dados[0] = list[ind]["usuario"].InnerText;
                dados[1] = list[ind]["senha"].InnerText;
                dados[2] = list[ind]["nome"].InnerText;
                dados[3] = list[ind]["sobrenome"].InnerText;
                dados[4] = list[ind]["telefone"].InnerText;
                dados[5] = list[ind]["telefone1"].InnerText;
                dados[6] = list[ind]["telefone2"].InnerText;
                dados[7] = list[ind]["cep"].InnerText;
                dados[8] = list[ind]["cidade"].InnerText;
                dados[9] = list[ind]["estado"].InnerText;
                dados[10] = list[ind]["endereco"].InnerText;
                dados[11] = list[ind]["numero"].InnerText;
                dados[12] = list[ind]["bairro"].InnerText;
                dados[13] = list[ind]["curriculo"].InnerText;
                dados[14] = list[ind]["email"].InnerText;
                dados[15] = list[ind]["genero"].InnerText;
                dados[16] = list[ind]["imagem"].InnerText;
                dados[17] = list[ind]["facebook"].InnerText;
                dados[18] = list[ind]["linkedin"].InnerText;
                dados[19] = list[ind]["data"].InnerText;
            } else {
                dados[0] = list[ind]["usuario"].InnerText;
                dados[1] = list[ind]["senha"].InnerText;
                dados[2] = list[ind]["nome"].InnerText;
                dados[3] = list[ind]["telefone"].InnerText;
                dados[4] = list[ind]["telefone1"].InnerText;
                dados[5] = list[ind]["telefone2"].InnerText;
                dados[6] = list[ind]["cep"].InnerText;
                dados[7] = list[ind]["cidade"].InnerText;
                dados[8] = list[ind]["estado"].InnerText;
                dados[9] = list[ind]["endereco"].InnerText;
                dados[10] = list[ind]["numero"].InnerText;
                dados[11] = list[ind]["bairro"].InnerText;
                dados[12] = list[ind]["email"].InnerText;
                dados[13] = list[ind]["cnpj"].InnerText;
                dados[14] = list[ind]["imagem"].InnerText;
                dados[15] = list[ind]["facebook"].InnerText;
                dados[16] = list[ind]["linkedin"].InnerText;
                dados[17] = list[ind]["data"].InnerText;
            }
            return dados;
        }

        public void SetCurriculoXML(string user, string[] carac, ArrayList fec, ArrayList fef, ArrayList fei, ArrayList fee) {
            UcFormEspecCurso curso;
            UcFormEspecFerram ferram;
            UcFormEspecIdioma idioma;
            UcFormExperiencia experi;
            try {
                XmlTextWriter dxml = new XmlTextWriter(@".\Curriculos\" + user + ".xml", null);
                dxml.WriteStartDocument();
                dxml.Formatting = Formatting.Indented;
                dxml.WriteStartElement("CURRICULO");
                dxml.WriteStartElement("CARACTERISTICAS");
                dxml.WriteElementString("atuacao", carac[0]);
                dxml.WriteElementString("especificacao", carac[1]);
                dxml.WriteElementString("escolaridade", carac[2]);
                dxml.WriteEndElement();
                string res = "";
                int i = 0;
                foreach (var ele in fec) {
                    curso = (UcFormEspecCurso) ele;
                    if (curso.GetTbDescricao() != "" || curso.GetTbInstituicao() != "") {
                        dxml.WriteStartElement("CURSOS");
                        dxml.WriteAttributeString("id", "" + i);
                        dxml.WriteElementString("descricao", curso.GetTbDescricao());
                        dxml.WriteElementString("instituicao", curso.GetTbInstituicao());
                        dxml.WriteElementString("nivel", curso.GetCmbNivel());
                        dxml.WriteElementString("inicio", curso.GetDateInicio());
                        dxml.WriteElementString("conclusao", curso.GetDateConclusao());
                        dxml.WriteEndElement();
                    } else {
                        res += (i + 1) + "º curso\n";
                    }
                    i++;
                }
                i = 0;
                foreach (var ele in fef) {
                    ferram = (UcFormEspecFerram) ele;
                    if (ferram.GetFerramenta() != "") {
                        dxml.WriteStartElement("FERRAMENTAS");
                        dxml.WriteAttributeString("id", "" + i);
                        dxml.WriteElementString("ferramenta", ferram.GetFerramenta());
                        dxml.WriteElementString("nivel", ferram.GetNivel());
                        dxml.WriteEndElement();
                    } else {
                        res += (i + 1) + "º ferramenta\n";
                    }
                    i++;
                }
                i = 0;
                foreach (var ele in fei) {
                    idioma = (UcFormEspecIdioma) ele;
                    if (idioma.GetIdioma() != "") {
                        dxml.WriteStartElement("IDIOMAS");
                        dxml.WriteAttributeString("id", "" + i);
                        dxml.WriteElementString("idioma", idioma.GetIdioma());
                        dxml.WriteElementString("nivel", idioma.GetNivel());
                        dxml.WriteEndElement();
                    } else {
                        res += (i + 1) + "º idioma\n";
                    }
                    i++;
                }
                i = 0;
                foreach (var ele in fee) {
                    experi = (UcFormExperiencia) ele;
                    if (experi.GetTbCargo() != "" || experi.GetTbEmpresa() != "") {
                        dxml.WriteStartElement("EXPERIENCIAS");
                        dxml.WriteAttributeString("id", "" + i);
                        dxml.WriteElementString("empresa", experi.GetTbEmpresa());
                        dxml.WriteElementString("cargo", experi.GetTbCargo());
                        dxml.WriteElementString("inicio", experi.GetDateInicio());
                        if (experi.GetCheckOption() == true) {
                            dxml.WriteElementString("conclusao", experi.GetDateConclusao());
                            dxml.WriteElementString("option", "" + experi.GetCheckOption());
                            dxml.WriteEndElement();
                        } else {
                            dxml.WriteElementString("conclusao", "");
                            dxml.WriteElementString("option", "" + experi.GetCheckOption());
                            dxml.WriteEndElement();
                        }
                    } else {
                        res += (i + 1) + "º experiencia\n";
                    }
                    i++;
                }
                if (res != "") {
                    MessageBox.Show(String.Format("Os elementos a seguir possuem alguma informação em branco e não foram salvos:\n{0}O restante foi salvo!", res),
                        "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                } else MessageBox.Show("Salvo", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                dxml.WriteFullEndElement();
                dxml.Close();
            } catch (Exception ex) {
                MessageBox.Show("Erro ao Guardar XML: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetCurriculoXML(string url, PerfilPessoa pp) {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load(url);
            } catch {
                XmlTextWriter dxml = new XmlTextWriter(url, null);
                dxml.WriteStartDocument();
                dxml.WriteStartElement("CURRICULO");
                dxml.WriteFullEndElement();
                dxml.Close();
                xml.Load(url);
            }
            XmlNodeList x = xml.GetElementsByTagName("CARACTERISTICAS");
            pp.SetCaracteristicas(x[0]["atuacao"].InnerText, x[0]["especificacao"].InnerText, x[0]["escolaridade"].InnerText);
            x = xml.GetElementsByTagName("CURSOS");
            for (int i = 0; i < x.Count; i++) {
                UcFormEspecCurso y = pp.GetUcCursoTop();
                y.SetDadosCurso(x[i]["descricao"].InnerText, x[i]["instituicao"].InnerText, x[i]["nivel"].InnerText, x[i]["inicio"].InnerText, x[i]["conclusao"].InnerText);
                if ((i + 1) < x.Count) {
                    pp.SetCursoConteiner();
                    pp.CurriculoFormOut.Height += 180;
                }
            }
            x = xml.GetElementsByTagName("FERRAMENTAS");
            for (int i = 0; i < x.Count; i++) {
                UcFormEspecFerram y = pp.GetUcFerramTop();
                y.SetDadosFerramentas(x[i]["ferramenta"].InnerText, x[i]["nivel"].InnerText);
                if ((i + 1) < x.Count) {
                    pp.SetFerramConteiner();
                    pp.CurriculoFormOut.Height += 90;
                    pp.gridspliter1.Height = new GridLength(pp.gridspliter1.Height.Value + 90);
                }
            }
            x = xml.GetElementsByTagName("IDIOMAS");
            for (int i = 0; i < x.Count; i++) {
                UcFormEspecIdioma y = pp.GetUcIdiomaTop();
                y.SetDadosIdioma(x[i]["idioma"].InnerText, x[i]["nivel"].InnerText);
                if ((i + 1) < x.Count) {
                    pp.SetFerramConteiner();
                    pp.CurriculoFormOut.Height += 90;
                    pp.gridspliter1.Height = new GridLength(pp.gridspliter1.Height.Value + 90);
                }
            }
            x = xml.GetElementsByTagName("EXPERIENCIAS");
            for (int i = 0; i < x.Count; i++) {
                UcFormExperiencia y = pp.GetUcExperiTop();
                y.SetDadosExperiencia(x[i]["empresa"].InnerText, x[i]["cargo"].InnerText,
                    x[i]["inicio"].InnerText, x[i]["conclusao"].InnerText, x[i]["option"].InnerText);
                if ((i + 1) < x.Count) {
                    pp.SetFerramConteiner();
                    pp.CurriculoFormOut.Height += 90;
                    pp.gridspliter1.Height = new GridLength(pp.gridspliter1.Height.Value + 90);
                }
            }
        }

        public void WriteArray(string[,] d, string eleFilho, XmlTextWriter xml) {
            if (d.Length / 2 > 0) {
                for (int j = 0; j < d.Length / 2; j++) {
                    xml.WriteStartElement(eleFilho);
                    xml.WriteAttributeString("desc", d[j, 0]);
                    xml.WriteAttributeString("nivel", d[j, 1]);
                    xml.WriteEndElement();
                }
            } else {
                xml.WriteStartElement(eleFilho);
                xml.WriteAttributeString("desc", "");
                xml.WriteAttributeString("nivel", "");
                xml.WriteEndElement();
            }
        }
        public void WriteArray(string[] d, string eleFilho, XmlTextWriter xml) {
            if (d.Length > 0) {
                for (int j = 0; j < d.Length; j++) {
                    xml.WriteStartElement(eleFilho);
                    xml.WriteAttributeString("desc", d[j]);
                    xml.WriteEndElement();
                }
            } else {
                xml.WriteStartElement(eleFilho);
                xml.WriteAttributeString("desc", "");
                xml.WriteEndElement();
            }
        }

        public void SetPostagemXml(ArrayList posts) {
            XmlTextWriter dxml = new XmlTextWriter(@".\Contas\postagens.xml", null);
            try {
                dxml.WriteStartDocument();
                dxml.Formatting = Formatting.Indented;
                dxml.WriteStartElement("POSTAGENS");
                int i = 0;
                foreach (var ele in posts) {
                    Postagem p = (Postagem) ele;
                    dxml.WriteStartElement("POST");
                    dxml.WriteAttributeString("id", "" + i);
                    dxml.WriteElementString("tipo", "" + p.Tipo);
                    dxml.WriteElementString("data", p.Data);
                    dxml.WriteElementString("hora", p.Hora);
                    dxml.WriteElementString("usuario", p.Usuario);
                    dxml.WriteElementString("nome", p.Nome);
                    dxml.WriteElementString("endereco", p.CompEndereco);
                    dxml.WriteElementString("cargo", p.Cargo);
                    dxml.WriteElementString("numero", p.NumVagas);
                    dxml.WriteElementString("desejavel", "" + p.Desejavel);
                    if (p.Desejavel == true) {
                        dxml.WriteStartElement("DESEJAVEL");
                        WriteArray(p.DesCur, "curso", dxml);
                        WriteArray(p.DesFer, "ferramenta", dxml);
                        WriteArray(p.DesIdi, "idioma", dxml);
                        WriteArray(p.DesExp, "experiencia", dxml);
                        dxml.WriteEndElement();
                    }
                    dxml.WriteElementString("necessario", "" + p.Necessario);
                    if (p.Necessario == true) {
                        dxml.WriteStartElement("NECESSARIO");
                        WriteArray(p.NesCur, "curso", dxml);
                        WriteArray(p.NesFer, "ferramenta", dxml);
                        WriteArray(p.NesIdi, "idioma", dxml);
                        WriteArray(p.NesExp, "experiencia", dxml);
                        dxml.WriteEndElement();
                    }
                    dxml.WriteEndElement();
                    if(p.Inscritos.Count > 0) {
                        dxml.WriteStartElement("INSCRITOS");
                        foreach(var ment in p.Inscritos) {
                            dxml.WriteStartElement("user");
                            dxml.WriteAttributeString("id", ment.ToString());
                            dxml.WriteEndElement();
                        }
                    }
                }
                dxml.WriteFullEndElement();
                dxml.Close();
            } catch (Exception ex) {
                dxml.Close();
                MessageBox.Show(String.Format("Erro ao Guardar XML: {0}\nOrigem: {1}", ex.Message, ex.Source),
                    "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetRequisitos(string[,] d, XmlReader x, string info) {
            int i = 0;
            while (x.ReadToFollowing(info)) {
                d[i, 0] = x.GetAttribute("desc");
                d[i, 0] = x.GetAttribute("nivel");
                i++;
            }
        }

        public void GetRequisitos(string[] d, XmlReader x, string info) {
            int i = 0;
            while (x.ReadToFollowing(info)) {
                d[i] = x.GetAttribute("desc");
                i++;
            }
        }

        public void GetPostagemXml(ArrayList array) {
            XmlReader xml = XmlReader.Create(@".\Contas\postagens.xml");
            while (xml.ReadToFollowing("POST")) {
                Postagem post = new Postagem();
                xml.ReadToFollowing("data");
                post.Data = xml.ReadElementContentAsString();
                xml.ReadToFollowing("hora");
                post.Hora = xml.ReadElementContentAsString();
                xml.ReadToFollowing("usuario");
                post.Usuario = xml.ReadElementContentAsString();
                xml.ReadToFollowing("nome");
                post.Nome = xml.ReadElementContentAsString();
                xml.ReadToFollowing("endereco");
                post.CompEndereco = xml.ReadElementContentAsString();
                xml.ReadToFollowing("cargo");
                post.Cargo = xml.ReadElementContentAsString();
                xml.ReadToFollowing("numero");
                post.NumVagas = xml.ReadElementContentAsString();

                xml.ReadToFollowing("desejavel");
                if(xml.ReadElementContentAsString() == "True")
                    post.Desejavel = true;
                else
                    post.Desejavel = false;
                if (post.Desejavel == true) {
                    xml.ReadToFollowing("DESEJAVEL");
                    GetRequisitos(post.DesCur, xml, "curso");
                    GetRequisitos(post.DesFer, xml, "ferramenta");
                    GetRequisitos(post.DesIdi, xml, "idioma");
                    GetRequisitos(post.DesExp, xml, "experiencia");
                }

                xml.ReadToFollowing("necessario");
                if (xml.ReadElementContentAsString() == "True")
                    post.Necessario = true;
                else
                    post.Necessario = false;
                if (post.Necessario == true) {
                    xml.ReadToFollowing("NECESSARIO");
                    GetRequisitos(post.DesCur, xml, "curso");
                    GetRequisitos(post.DesFer, xml, "ferramenta");
                    GetRequisitos(post.DesIdi, xml, "idioma");
                    GetRequisitos(post.DesExp, xml, "experiencia");
                }
                array.Add(post);
            }
        }
    }
}
