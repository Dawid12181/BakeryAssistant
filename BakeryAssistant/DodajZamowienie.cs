using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using System.IO;
using System.Xml;
using System.Xml.Serialization;
=======
>>>>>>> a8bb7e16cb1e5b8c5dad3b5072afa86dec0f9489

namespace BakeryAssistant
{
    public partial class DodajZamowienie : Form
    {
<<<<<<< HEAD
        List<Zamowienie> my_orders = new List<Zamowienie>();
        public DodajZamowienie()
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
            textBox5.Text = (my_orders.Count+1).ToString();
        }
=======
        Zamowienie zam = new Zamowienie();
        public DodajZamowienie()
        {
            InitializeComponent();
        }

>>>>>>> a8bb7e16cb1e5b8c5dad3b5072afa86dec0f9489
        private void DodajZamowienie_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            my_orders.Add(new Zamowienie((int.Parse(textBox5.Text)).ToString(), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text));
=======
            zam.ID = textBox5.Text;
            zam.Odbiorca = textBox1.Text;
            zam.Adres = textBox2.Text;
            zam.Data = textBox3.Text;
            zam.Zamowienie_tekst = textBox4.Text;
            ListViewItem order = new ListViewItem(zam.Odbiorca);
            order.SubItems.Add(zam.Adres);
            order.SubItems.Add(zam.Data);
            order.SubItems.Add(zam.Zamowienie_tekst);
            listView1.Items.Add(order);
>>>>>>> a8bb7e16cb1e5b8c5dad3b5072afa86dec0f9489
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
<<<<<<< HEAD
            ListViewItem order = new ListViewItem(my_orders[my_orders.Count-1].Odbiorca);
            order.SubItems.Add(my_orders[my_orders.Count-1].Adres);
            order.SubItems.Add(my_orders[my_orders.Count-1].Data);
            order.SubItems.Add(my_orders[my_orders.Count-1].Zamowienie_tekst);
            listView1.Items.Add(order);
=======
>>>>>>> a8bb7e16cb1e5b8c5dad3b5072afa86dec0f9489
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            string zamowienie;
<<<<<<< HEAD
            try
            {
                zamowienie = listView1.SelectedItems[0].SubItems[3].Text;
                MessageBox.Show("Twoje zamowienie to:  " + zamowienie);
            }
            catch
            {
                MessageBox.Show("Proszę podświetlić interesujące Cię zamówienie.");
            }
        }
       
        private void button3_Click(object sender, EventArgs e) //Przycisk Powrót, serializacja i powrót do mainwindow
        {
            /* Początek serializacji */
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Orders";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Zamowienie>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter("orders.xml");
                oSerializer.Serialize(oStreamWriter, my_orders);
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
            /* Koniec serializacji do pliku orders.xml*/
            this.Hide();                                                   // Hide form AddNewProduct
            MainWindow s = new MainWindow();                               // Create new form - MainWindow
            s.Show();
=======
            zamowienie = listView1.SelectedItems[0].SubItems[3].Text;
            MessageBox.Show("Twoje zamowienie to:  " + zamowienie);
>>>>>>> a8bb7e16cb1e5b8c5dad3b5072afa86dec0f9489
        }
    }
}
