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
    public partial class MainWindow : Form
    {
        List<Produkty> produkt = new List<Produkty>();
        List<Zamowienie> my_orders = new List<Zamowienie>();
        List<ProduktyMagazyn> my_magasin = new List<ProduktyMagazyn>();
        List<Skladnik> skladnik = new List<Skladnik>();
        List<Produkty> produkty_do_zrobienia = new List<Produkty>();
        List<Produkty> produkty_zrobione = new List<Produkty>();
        public MainWindow()
        {
            InitializeComponent();
            XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.Load("orders.xml");
                XmlNodeList DaneNodesList = oXmlDocument.GetElementsByTagName("Zamowienie");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    my_orders.Add(new Zamowienie(Dana.FirstChild.InnerText, Dana.FirstChild.NextSibling.InnerText, Dana.LastChild.PreviousSibling.PreviousSibling.InnerText, Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    ListViewItem order = new ListViewItem(my_orders[my_orders.Count - 1].ID);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Odbiorca);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Adres);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Data);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Zamowienie_tekst);
                    listView1.Items.Add(order);
                }
            }
            catch
            {
            }
            XmlDocument oXm2Document = new XmlDocument();
            try
            {
                oXm2Document.Load("skladniki.xml");
                XmlNodeList DaneNodesList = oXm2Document.GetElementsByTagName("ProduktyMagazyn");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    my_magasin.Add(new ProduktyMagazyn(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Dana.FirstChild.NextSibling.NextSibling.InnerText, Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText), Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.PreviousSibling.InnerText.Replace('.', ',')), Double.Parse(Dana.LastChild.InnerText.Replace('.', ','))));
                }
                int k = 0;
                int item=0;
                foreach (ProduktyMagazyn ite in my_magasin)
                {
                    
                    if (my_magasin[item].ilosc < my_magasin[item].wymagana_ilosc)
                    {
                        ListViewItem order = new ListViewItem(my_magasin[item].ID.ToString());
                        order.SubItems.Add(my_magasin[item].nazwa);
                        order.SubItems.Add(my_magasin[item].ilosc.ToString());
                        order.SubItems.Add(my_magasin[item].wymagana_ilosc.ToString());
                        order.SubItems.Add("To Do");
                        order.SubItems.Add(my_magasin[item].jednostka);
                        listView2.Items.Add(order);
                        if (my_magasin[item].ilosc < my_magasin[item].wymagana_ilosc)
                            listView2.Items[k].BackColor = Color.Yellow;
                        if (my_magasin[item].ilosc < 0.5 * my_magasin[item].wymagana_ilosc)
                            listView2.Items[k].BackColor = Color.Red;

                        k++;
                    }
                    item++;
                }
                item = 0;
                k = 0; // Wyświetlanie listview2 czyli listy z niedoborem składników.
            }

            catch
            {
            }
            XmlDocument oXm3Document = new XmlDocument();
            try
            {
                oXm3Document.Load("produkty.xml");
                XmlNodeList DaneNodesList3 = oXm3Document.GetElementsByTagName("Produkty");
                foreach (XmlNode Dana in DaneNodesList3)
                {
                    produkt.Add(new Produkty(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    listBox1.Items.Add(produkt[produkt.Count - 1].nazwa);
                    List<int> ids = new List<int>(Array.ConvertAll(produkt[0].idskladnika.Split(','), int.Parse));
                    List<int> ilosci = new List<int>(Array.ConvertAll(produkt[0].iloscproduktu.Split(','), int.Parse));
                    skladnik.Add(new Skladnik(ids, ilosci, produkt[produkt.Count - 1].ID));
                }
            }
            catch
            {
            }
            XmlDocument oXm4Document = new XmlDocument();
            try
            {
                oXm4Document.Load("produkty_do_zrobienia.xml");
                XmlNodeList DaneNodesList4 = oXm4Document.GetElementsByTagName("Produkty");
                foreach (XmlNode Dana in DaneNodesList4)
                {
                    produkt.Add(new Produkty(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    listBox1.Items.Add(produkt[produkt.Count - 1].nazwa);
                    List<int> ids = new List<int>(Array.ConvertAll(produkt[0].idskladnika.Split(','), int.Parse));
                    List<int> ilosci = new List<int>(Array.ConvertAll(produkt[0].iloscproduktu.Split(','), int.Parse));
                    skladnik.Add(new Skladnik(ids, ilosci, produkt[produkt.Count - 1].ID));
                }
            }
            catch
            {
            }
            XmlDocument oXm5Document = new XmlDocument();
            try
            {
                oXm5Document.Load("produkty_zrobione.xml");
                XmlNodeList DaneNodesList5 = oXm5Document.GetElementsByTagName("Produkty");
                foreach (XmlNode Dana in DaneNodesList5)
                {
                    produkt.Add(new Produkty(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    listBox1.Items.Add(produkt[produkt.Count - 1].nazwa);
                    List<int> ids = new List<int>(Array.ConvertAll(produkt[0].idskladnika.Split(','), int.Parse));
                    List<int> ilosci = new List<int>(Array.ConvertAll(produkt[0].iloscproduktu.Split(','), int.Parse));
                    skladnik.Add(new Skladnik(ids, ilosci, produkt[produkt.Count - 1].ID));
                }
            }
            catch
            {
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("You are in the ListView.ItemActivate event.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();                                                   // Hide form MainWindow
            AddNewProduct produkt = new AddNewProduct();                   // Create new form - AddNewProduct
            produkt.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void ListView1_ItemActivate(Object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();                                                   // Hide form MainWindow
            DodajZamowienie zamowienia = new DodajZamowienie();                     // Create new form - DodajZamowienie
            zamowienia.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zamowienie;
            try
            {
                zamowienie = listView1.SelectedItems[0].SubItems[4].Text;
                MessageBox.Show("Twoje zamowienie to:  " + zamowienie);
            }
            catch
            {
                MessageBox.Show("Proszę podświetlić interesujące Cię zamówienie.");
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();                                                   // Hide form MainWindow
            Magazyn magazyn = new Magazyn(produkt);                     // Create new form - Magazyn
            magazyn.Show();
        }

        private void button6_Click(object sender, EventArgs e) // przycisk done
        {
            int usunID = Int32.Parse(listView3.SelectedItems[0].SubItems[0].Text);
            listView3.SelectedItems[0].Remove();
            foreach (Produkty item in produkty_do_zrobienia)
            {
                if (item.ID == usunID)
                {
                    produkty_zrobione.Add(item);
                }

            }
            listView4.Items.Clear();
            int it = 0;
            foreach (Produkty ite in produkty_zrobione)
            {
                ListViewItem order = new ListViewItem(produkty_zrobione[it].ID.ToString());
                order.SubItems.Add(produkty_zrobione[it].nazwa);
                order.SubItems.Add(produkty_zrobione[it].ilosc.ToString());
                order.SubItems.Add(produkty_zrobione[it].jednostka);
                listView4.Items.Add(order);
                it++;
            }
            it = 0;

        }

        private void button7_Click(object sender, EventArgs e) //Dodanie produktu do zrobienia
        {
            int ID;
            ID = listBox1.SelectedIndex+1;
            foreach (Produkty item in produkt)
            {
                if (item.ID == ID)
                {
                    produkty_do_zrobienia.Add(item);
                    produkty_do_zrobienia[produkty_do_zrobienia.Count - 1].ilosc = Int32.Parse(textBox5.Text);
                    ListViewItem order = new ListViewItem(produkty_do_zrobienia[produkty_do_zrobienia.Count - 1].ID.ToString());
                    order.SubItems.Add(produkty_do_zrobienia[produkty_do_zrobienia.Count - 1].nazwa);
                    order.SubItems.Add(produkty_do_zrobienia[produkty_do_zrobienia.Count - 1].ilosc.ToString());
                    order.SubItems.Add(produkty_do_zrobienia[produkty_do_zrobienia.Count - 1].jednostka);
                    listView3.Items.Add(order);
                }
            }

        }
    }
}
