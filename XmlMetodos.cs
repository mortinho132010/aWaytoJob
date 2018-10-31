using System;
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
                    pes[i]["bairro"].InnerText, pes[i]["complemento"].InnerText, pes[i]["email"].InnerText, pes[i]["genero"].InnerText,
                    pes[i]["imagem"].InnerText, pes[i]["facebook"].InnerText, pes[i]["linkedin"].InnerText);
            }
            for (int i = 0; i < emp.Count; i++) {
                eList.Cadastrar(emp[i]["usuario"].InnerText, emp[i]["senha"].InnerText, emp[i]["nome"].InnerText,
                    emp[i]["telefone"].InnerText, emp[i]["telefone1"].InnerText, emp[i]["telefone2"].InnerText, emp[i]["cep"].InnerText,
                    emp[i]["cidade"].InnerText, emp[i]["estado"].InnerText, emp[i]["endereco"].InnerText, emp[i]["numero"].InnerText,
                    emp[i]["bairro"].InnerText, emp[i]["complemento"].InnerText, emp[i]["email"].InnerText, emp[i]["cnpj"].InnerText,
                    emp[i]["imagem"].InnerText, emp[i]["facebook"].InnerText, emp[i]["linkedin"].InnerText);
            }
        }

        public void GuardarXml(ListaPessoas pList, ListaEmpresas eList) {
            try {
                XmlTextWriter dxml = new XmlTextWriter(@".\Contas\dados.xml", null);
                string[,] pessoas = pList.getAll();
                string[,] empresas = eList.getAll();
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
                    dxml.WriteElementString("complemento", pessoas[i, 13]);
                    dxml.WriteElementString("email", pessoas[i, 14]);
                    dxml.WriteElementString("genero", pessoas[i, 15]);
                    dxml.WriteElementString("imagem", pessoas[i, 16]);
                    dxml.WriteElementString("facebook", pessoas[i, 17]);
                    dxml.WriteElementString("linkedin", pessoas[i, 18]);
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
                    dxml.WriteElementString("complemento", empresas[i, 12]);
                    dxml.WriteElementString("email", empresas[i, 13]);
                    dxml.WriteElementString("cnpj", empresas[i, 14]);
                    dxml.WriteElementString("imagem", empresas[i, 15]);
                    dxml.WriteElementString("facebook", empresas[i, 16]);
                    dxml.WriteElementString("linkedin", empresas[i, 17]);
                    dxml.WriteEndElement();
                }
                dxml.WriteFullEndElement();
                dxml.Close();
            } catch (Exception ex) {
                MessageBox.Show("Erro: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string[] ComparaXml(string usu, string sen) {
            string[] dados = new string[5];
            dados[4] = "false";
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\Contas\dados.xml");
            XmlNodeList usuarios;
            usuarios = xml.GetElementsByTagName("PESSOAS");
            for (int i = 0; i < usuarios.Count; i++) {
                if (usuarios[i]["usuario"].InnerText == usu && usuarios[i]["senha"].InnerText == sen) {
                    dados[0] = usuarios[i]["usuario"].InnerText;
                    dados[1] = usuarios[i]["nome"].InnerText + " " + usuarios[i]["sobrenome"].InnerText;
                    dados[2] = usuarios[i]["imagem"].InnerText;
                    dados[3] = "" + i;
                    dados[4] = "true";
                    break;
                }
            }
            usuarios = xml.GetElementsByTagName("EMPRESAS");
            for (int i = 0; i < usuarios.Count; i++) {
                if (usuarios[i]["usuario"].InnerText == usu && usuarios[i]["senha"].InnerText == sen) {
                    dados[0] = usuarios[i]["usuario"].InnerText;
                    dados[1] = usuarios[i]["nome"].InnerText + " " + usuarios[i]["sobrenome"].InnerText;
                    dados[2] = usuarios[i]["imagem"].InnerText;
                    dados[3] = "" + i;
                    dados[4] = "true";
                    break;
                }
            }
            return dados;
        }
    }
}
