using System;
using System.Windows;
using System.Xml;

namespace awtj {
    class XmlMetodos {

        public void LerXml(ListaPessoas pList, ListaEmpresas eList) {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load(@".\Contas\dados.xml");
            }catch{
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
                pList.Cadastrar(pes[i]["usuario"].InnerText, pes[i]["senha"].InnerText, pes[i]["nome"].InnerText, pes[i]["telefone"].InnerText,
                    pes[i]["endereco"].InnerText, pes[i]["email"].InnerText, pes[i]["genero"].InnerText);
            }
            for (int i = 0; i < emp.Count; i++) {
                eList.Cadastrar(emp[i]["usuario"].InnerText, emp[i]["senha"].InnerText, emp[i]["nome"].InnerText, emp[i]["telefone"].InnerText,
                    emp[i]["endereco"].InnerText, emp[i]["email"].InnerText, emp[i]["cnpj"].InnerText);
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
                    dxml.WriteElementString("telefone", pessoas[i, 3]);
                    dxml.WriteElementString("endereco", pessoas[i, 4]);
                    dxml.WriteElementString("email", pessoas[i, 5]);
                    dxml.WriteElementString("genero", pessoas[i, 6]);
                    dxml.WriteEndElement();
                }
                for (int i = 0; i < eList.Size(); i++) {
                    dxml.WriteStartElement("EMPRESAS");
                    dxml.WriteAttributeString("id", "" + i);
                    dxml.WriteElementString("usuario", empresas[i, 0]);
                    dxml.WriteElementString("senha", empresas[i, 1]);
                    dxml.WriteElementString("nome", empresas[i, 2]);
                    dxml.WriteElementString("telefone", empresas[i, 3]);
                    dxml.WriteElementString("endereco", empresas[i, 4]);
                    dxml.WriteElementString("email", empresas[i, 5]);
                    dxml.WriteElementString("cnpj", empresas[i, 6]);
                    dxml.WriteEndElement();
                }
                dxml.WriteFullEndElement();
                dxml.Close();
            } catch (Exception ex) {
                MessageBox.Show("Erro: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ComparaXml(string usu, string sen) {
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\Contas\dados.xml");
            XmlNodeList usuarios;
            usuarios = xml.GetElementsByTagName("PESSOAS");
            for (int i = 0; i < usuarios.Count; i++) {
                if (usuarios[i]["usuario"].InnerText == usu && usuarios[i]["senha"].InnerText == sen) {
                    return true;
                }
            }
            usuarios = xml.GetElementsByTagName("EMPRESAS");
            for (int i = 0; i < usuarios.Count; i++) {
                if (usuarios[i]["usuario"].InnerText == usu && usuarios[i]["senha"].InnerText == sen) {
                    return true;
                }
            }
            return false;
        }
    }
}
