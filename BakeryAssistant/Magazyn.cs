using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BakeryAssistant
{
    public partial class Magazyn : Form
    {
        List<ProduktyMagazyn> my_magasin = new List<ProduktyMagazyn>();
        public Magazyn()
        {
            InitializeComponent();
            XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.Load("magasin.xml");
                XmlNodeList DaneNodesList = oXmlDocument.GetElementsByTagName("ProduktyNaMagazynie");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    //my_magasin.Add(new ProduktyMagazyn({ Dana.FirstChild.InnerText, Dana.FirstChild.NextSibling.InnerText }, Dana.LastChild.PreviousSibling.PreviousSibling.InnerText, Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    //Do zrobienia lista która będzie brała itemki z listy produktów i dodawała ilosc na magazynie, cene hurtową z innego pliku.
                    ListViewItem order = new ListViewItem(my_magasin[my_magasin.Count - 1].ID.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].komponent);
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].ilosc_na_hurtowni.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].wymagana_minimalna_ilosc.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].jednostka);
                    listView1.Items.Add(order);
                }
            }
            catch
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
