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
    public partial class AddOrder : Form
    {
        List<Order> my_orders = new List<Order>();
        public AddOrder()
        {
            InitializeComponent();
            XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.Load("orders.xml");
                XmlNodeList DaneNodesList = oXmlDocument.GetElementsByTagName("Zamowienie");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    my_orders.Add(new Order(Dana.FirstChild.InnerText, Dana.FirstChild.NextSibling.InnerText, Dana.LastChild.PreviousSibling.PreviousSibling.InnerText, Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    ListViewItem order = new ListViewItem(my_orders[my_orders.Count - 1].ID);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Receiver);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Address);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Date);
                    order.SubItems.Add(my_orders[my_orders.Count - 1].Order_text);
                    listView1.Items.Add(order);
                }
            }
            catch
            {
            }
        }
        private void DodajZamowienie_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) // Validation
                MessageBox.Show("Wpisz odbiorcę!");
            else
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text)) // Validation
                    MessageBox.Show("Wpisz adres!");
                else
                {
                    if (string.IsNullOrWhiteSpace(textBox3.Text)) // Validation
                        MessageBox.Show("Wpisz datę!");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox4.Text)) // Validation
                            MessageBox.Show("Wpisz treść zamówenia!");
                        else
                        {
                            my_orders.Add(new Order((Int32.Parse(my_orders[my_orders.Count - 1].ID) + 1).ToString(), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text));
                            textBox1.Text = String.Empty;
                            textBox2.Text = String.Empty;
                            textBox3.Text = String.Empty;
                            textBox4.Text = String.Empty;
                            ListViewItem order = new ListViewItem(my_orders[my_orders.Count - 1].ID);
                            order.SubItems.Add(my_orders[my_orders.Count - 1].Receiver);
                            order.SubItems.Add(my_orders[my_orders.Count - 1].Address);
                            order.SubItems.Add(my_orders[my_orders.Count - 1].Date);
                            order.SubItems.Add(my_orders[my_orders.Count - 1].Order_text);
                            listView1.Items.Add(order);
                        }
                    }
                }
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            string orderstring;
            try
            {
                orderstring = listView1.SelectedItems[0].SubItems[4].Text;
                MessageBox.Show("Twoje zamowienie to:  " + orderstring);
            }
            catch
            {
                MessageBox.Show("Proszę podświetlić interesujące Cię zamówienie.");
            }
        }
       
        private void button3_Click(object sender, EventArgs e) // Button Powrót
        {
            /* Starting serialization */
            SaveData.serialization(("orders.xml"), my_orders, "Orders");
            /* Ending serialization */
            this.Hide();                                                   // Hide form Orders
            MainWindow s = new MainWindow();                               // Create new form - MainWindow
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e) // Button Usuń zamówienie
        {
            int i=0;
            bool j=false;
            Order delete = new Order(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, listView1.SelectedItems[0].SubItems[3].Text, listView1.SelectedItems[0].SubItems[4].Text);
            listView1.SelectedItems[0].Remove();
            foreach (Order item in my_orders)
            {
                if (item.ID == delete.ID)
                {
                    j = true;
                    break;
                }
                i++;
            }
            if(j)
            my_orders.RemoveAt(i);
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;      // X Button kill
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
