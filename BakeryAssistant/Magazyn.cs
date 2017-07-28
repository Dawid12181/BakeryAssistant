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
            XmlDocument oXm2Document = new XmlDocument();
            try
            {
                oXm2Document.Load("skladniki.xml");
                XmlNodeList DaneNodesList = oXm2Document.GetElementsByTagName("ProduktyMagazyn");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    my_magasin.Add(new ProduktyMagazyn(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Dana.FirstChild.NextSibling.NextSibling.InnerText, Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText), Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.InnerText)));
                    ListViewItem order = new ListViewItem(my_magasin[my_magasin.Count - 1].ID.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].nazwa);
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].ilosc.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].wymagana_ilosc.ToString());
                    order.SubItems.Add("To Do");
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

        private void button2_Click(object sender, EventArgs e)
        {
           
            string jednostka="j";
            if (radioButton1.Checked)
                jednostka = "szt";
            else if (radioButton2.Checked)
                jednostka = "gram";
            else
                MessageBox.Show("Prosze wybrać jednostkę");
            my_magasin.Add(new ProduktyMagazyn(my_magasin.Count + 1,textBox3.Text, jednostka, Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), Double.Parse(textBox6.Text), Double.Parse(textBox7.Text)));
            ListViewItem order = new ListViewItem(my_magasin[my_magasin.Count - 1].ID.ToString());
            order.SubItems.Add(my_magasin[my_magasin.Count - 1].nazwa);
            order.SubItems.Add(my_magasin[my_magasin.Count - 1].ilosc.ToString());
            order.SubItems.Add(my_magasin[my_magasin.Count - 1].wymagana_ilosc.ToString());
            order.SubItems.Add(my_magasin[my_magasin.Count - 1].jednostka);
            listView1.Items.Add(order);
            }
        private void button3_Click(object sender, EventArgs e)
        {
            /* Początek serializacji */
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Skladniki";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<ProduktyMagazyn>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter("skladniki.xml");
                oSerializer.Serialize(oStreamWriter, my_magasin);
            }
            catch (Exception oException)
            {
                Console.WriteLine("Aplikacja wygenerowała następujący wyjątek: " + oException.Message);
            }
            finally
            {
                if (null != oStreamWriter)
                {
                    oStreamWriter.Dispose();
                }
            }
            /* Koniec serializacji do pliku skladniki.xml*/
            this.Hide();                                                   // Hide form AddNewProduct
            MainWindow s = new MainWindow();                               // Create new form - MainWindow
            s.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
