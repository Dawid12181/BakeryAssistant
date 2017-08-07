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
    public partial class Warehouse : Form
    {
        List<ProductsClass> products = new List<ProductsClass>();
        List<ComponentsInWarehouse> my_magasin = new List<ComponentsInWarehouse>();
        public Warehouse(List<ProductsClass> product)
        {
            InitializeComponent();
            XmlDocument oXm2Document = new XmlDocument();
            try
            {
                oXm2Document.Load("skladniki.xml");
                XmlNodeList DaneNodesList = oXm2Document.GetElementsByTagName("ComponentsInWarehouse");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    my_magasin.Add(new ComponentsInWarehouse(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Dana.FirstChild.NextSibling.NextSibling.InnerText, Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText), Int32.Parse(Dana.LastChild.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.InnerText.Replace('.', ','))));
                    ListViewItem order = new ListViewItem(my_magasin[my_magasin.Count - 1].ID.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].name);
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].quantity.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].required_quantity.ToString());
                    order.SubItems.Add(my_magasin[my_magasin.Count - 1].unit);
                    listView1.Items.Add(order);
                }
            }
            catch
            {
            }
            products = product;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) // validation
                MessageBox.Show("Wpisz ilość!");
            else
            {
                int p = 0;
                bool o = false;
                string skladnikid = listView1.SelectedItems[0].SubItems[0].Text;
                listView1.SelectedItems[0].Remove();
                foreach (ComponentsInWarehouse item in my_magasin)
                {
                    if (item.ID == Int32.Parse(skladnikid))
                    {
                        o = true;
                        break;
                    }
                    p++;
                }
                if (o)
                {
                    my_magasin[p].quantity = my_magasin[p].quantity + Int32.Parse(textBox1.Text);
                    listView1.Items.Clear();
                    int item = 0;
                    foreach (ComponentsInWarehouse ite in my_magasin)
                    {
                        ListViewItem order = new ListViewItem(my_magasin[item].ID.ToString());
                        order.SubItems.Add(my_magasin[item].name);
                        order.SubItems.Add(my_magasin[item].quantity.ToString());
                        order.SubItems.Add(my_magasin[item].required_quantity.ToString());
                        order.SubItems.Add(my_magasin[item].unit);
                        listView1.Items.Add(order);
                        item++;
                    }
                    item = 0;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) // validation
                MessageBox.Show("Wpisz nazwę składnika!");
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)) // validation
                    MessageBox.Show("Wpisz początkową ilość!");
                else
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text)) // validation
                        MessageBox.Show("Wpisz minimalną wymaganą ilość!");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox1.Text)) // validation
                            MessageBox.Show("Wpisz cenę zakupu!");
                        else
                        {
                            string jednostka = "j";
                        if (radioButton1.Checked)
                            jednostka = "szt";
                        else if (radioButton2.Checked)
                            jednostka = "gram";
                        else
                            MessageBox.Show("Prosze wybrać jednostkę");
                        my_magasin.Add(new ComponentsInWarehouse(my_magasin.Count + 1, textBox3.Text, jednostka, Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), Double.Parse(textBox6.Text.Replace('.', ','))));
                        ListViewItem order = new ListViewItem(my_magasin[my_magasin.Count - 1].ID.ToString());
                        order.SubItems.Add(my_magasin[my_magasin.Count - 1].name);
                        order.SubItems.Add(my_magasin[my_magasin.Count - 1].quantity.ToString());
                        order.SubItems.Add(my_magasin[my_magasin.Count - 1].required_quantity.ToString());
                        order.SubItems.Add(my_magasin[my_magasin.Count - 1].unit);
                        listView1.Items.Add(order);
                    }
                }
            }
        }
            }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveData.serialization(("skladniki.xml"), my_magasin, "Skladniki");
            this.Hide();                                                   // Hide form AddNewProduct
            MainWindow s = new MainWindow();                               // Create new form - MainWindow
            s.Show();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
