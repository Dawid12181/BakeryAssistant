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
        List<Zamowienie> my_orders = new List<Zamowienie>();
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
                    ListViewItem order = new ListViewItem(my_orders[my_orders.Count - 1].Odbiorca);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Adres);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Data);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Zamowienie_tekst);
                    listView1.Items.Add(order);
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
<<<<<<< HEAD
            this.Hide();                                                   // Hide form MainWindow
            DodajZamowienie zamowienia = new DodajZamowienie();                     // Create new form - DodajZamowienie
            zamowienia.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zamowienie;
            zamowienie = listView1.SelectedItems[0].SubItems[3].Text;
            MessageBox.Show("Twoje zamowienie to: " + zamowienie);
=======
            this.Hide();                                                   // Hide form languageSelect
            DodajZamowienie s = new DodajZamowienie();                               // Create new form - Login
            s.Show();
            //just checking \/ listView; check for urself, dont think it will work because too much text for "Zamówienie" 
            ListViewItem order = new ListViewItem("Pani Zosia G.");
            order.SubItems.Add("Topolowa 24");
            order.SubItems.Add("codziennie od 5:00-5:30 oprócz sobót");
            order.SubItems.Add("3x bulka paryska, 5x chleb razowy, 10x bulka pszenna, 6x drozdzowka z makiem + paczki jak bedą robione");
            listView1.Items.Add(order);
>>>>>>> a8bb7e16cb1e5b8c5dad3b5072afa86dec0f9489
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zamowienie;
            zamowienie = listView1.SelectedItems[0].SubItems[3].Text;
            MessageBox.Show("Twoje zamowienie to:" + zamowienie);
        }
    }
}
