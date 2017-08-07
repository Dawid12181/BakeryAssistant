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
        List<ProductsClass> product = new List<ProductsClass>();
        List<Order> my_orders = new List<Order>();
        List<ComponentsInWarehouse> my_magasin = new List<ComponentsInWarehouse>();
        List<Component> component = new List<Component>();
        List<ProductsClass> products_to_do = new List<ProductsClass>();
        List<ProductsClass> products_already_done = new List<ProductsClass>();
        string date = DateTime.Now.ToString("dd_MM_yyyy");

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
            XmlDocument oXm2Document = new XmlDocument();
            try
            {
                oXm2Document.Load("skladniki.xml");
                XmlNodeList DaneNodesList = oXm2Document.GetElementsByTagName("ComponentsInWarehouse");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    my_magasin.Add(new ComponentsInWarehouse(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Dana.FirstChild.NextSibling.NextSibling.InnerText, Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText), Int32.Parse(Dana.LastChild.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.InnerText.Replace('.', ','))));
                }
                int k = 0;
                int item = 0;
                foreach (ComponentsInWarehouse ite in my_magasin)
                {

                    if (my_magasin[item].quantity < my_magasin[item].required_quantity)
                    {
                        ListViewItem order = new ListViewItem(my_magasin[item].ID.ToString());
                        order.SubItems.Add(my_magasin[item].name);
                        order.SubItems.Add(my_magasin[item].quantity.ToString());
                        order.SubItems.Add(my_magasin[item].required_quantity.ToString());
                        order.SubItems.Add(my_magasin[item].unit);
                        listView2.Items.Add(order);
                        if (my_magasin[item].quantity < my_magasin[item].required_quantity)
                            listView2.Items[k].BackColor = Color.Yellow;
                        if (my_magasin[item].quantity < 0.5 * my_magasin[item].required_quantity)
                            listView2.Items[k].BackColor = Color.Red;

                        k++;
                    }
                    item++;
                }
                item = 0;
                k = 0; // Showing listview2
            }

            catch
            {
            }
            XmlDocument oXm3Document = new XmlDocument();
            try
            {
                oXm3Document.Load("produkty.xml");
                XmlNodeList DaneNodesList3 = oXm3Document.GetElementsByTagName("ProductsClass");
                foreach (XmlNode Dana in DaneNodesList3)
                {
                    product.Add(new ProductsClass(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    listBox1.Items.Add(product[product.Count - 1].name);
                }
            }
            catch
            {
            }
            
            XmlDocument oXm4Document = new XmlDocument();
            try
            {
                oXm4Document.Load(date + "do_zrobienia.xml");
                XmlNodeList DaneNodesList4 = oXm4Document.GetElementsByTagName("ProductsClass");
                foreach (XmlNode Dana in DaneNodesList4)
                {
                    products_to_do.Add(new ProductsClass(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    ListViewItem order = new ListViewItem(products_to_do[products_to_do.Count - 1].ID.ToString());
                    order.SubItems.Add(products_to_do[products_to_do.Count - 1].name);
                    order.SubItems.Add(products_to_do[products_to_do.Count - 1].quantity.ToString());
                    order.SubItems.Add(products_to_do[products_to_do.Count - 1].unit);
                    listView3.Items.Add(order);
                    List<int> ids = new List<int>(Array.ConvertAll(products_to_do[products_to_do.Count - 1].componentID.Split(','), int.Parse));
                    List<int> quantities = new List<int>(Array.ConvertAll(products_to_do[products_to_do.Count - 1].quantityofproducts.Split(','), int.Parse));
                    component.Add(new Component(ids, quantities, products_to_do[products_to_do.Count - 1].ID));
                }
            }
            catch
            {
            }
            XmlDocument oXm5Document = new XmlDocument();
            try
            {
                oXm5Document.Load(date + "zrobione.xml");
                XmlNodeList DaneNodesList5 = oXm5Document.GetElementsByTagName("ProductsClass");
                foreach (XmlNode Dana in DaneNodesList5)
                {
                    products_already_done.Add(new ProductsClass(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    ListViewItem order = new ListViewItem(products_already_done[products_already_done.Count - 1].ID.ToString());
                    order.SubItems.Add(products_already_done[products_already_done.Count - 1].name);
                    order.SubItems.Add(products_already_done[products_already_done.Count - 1].quantity.ToString());
                    order.SubItems.Add(products_already_done[products_already_done.Count - 1].unit);
                    listView4.Items.Add(order);
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
            /* Starting serialization */
            SaveData.serialization((date + "do_zrobienia.xml"), products_to_do, "Products");
            SaveData.serialization((date + "zrobione.xml"), products_already_done, "Products");
            SaveData.serialization(("skladniki.xml"), my_magasin, "Skladniki");
            /* Ending serialization */

            this.Hide();                                                   // Hide form MainWindow
            AddNewProduct productt = new AddNewProduct();                   // Create new form - AddNewProduct
            productt.Show();
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
            /* Starting serialization */
            SaveData.serialization((date + "do_zrobienia.xml"), products_to_do, "Products");
            SaveData.serialization((date + "zrobione.xml"), products_already_done, "Products");
            SaveData.serialization(("skladniki.xml"), my_magasin, "Skladniki");
            /* Ending serialization */
            this.Hide();                                                   // Hide form MainWindow
            AddOrder orders = new AddOrder();                     // Create new form - DodajZamowienie
            orders.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string order_string;
            try
            {
                order_string = listView1.SelectedItems[0].SubItems[4].Text;
                MessageBox.Show("Twoje zamowienie to:  " + order_string);
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
            /* Starting serialization */
            SaveData.serialization((date + "do_zrobienia.xml"), products_to_do, "Products");
            SaveData.serialization((date + "zrobione.xml"), products_already_done, "Products");
            SaveData.serialization(("skladniki.xml"), my_magasin, "Skladniki");
            /* Ending serialization */
            this.Hide();                                                   // Hide form MainWindow
            Warehouse warehouse = new Warehouse(product);                     // Create new form - Magazyn
            warehouse.Show();
        }

        private void button6_Click(object sender, EventArgs e) // done button
        {
            int deleteID = Int32.Parse(listView3.SelectedItems[0].SubItems[0].Text);
            try
            {
                // Substracting quantity
                foreach (Component s in component)
                {
                    if (s.productID == deleteID)
                    {
                        int p = 0;
                        foreach (int k in s.ID)
                        {
                            int o = 0;
                            foreach (ComponentsInWarehouse prod in my_magasin)
                            {
                                if (prod.ID == k)
                                {
                                    //MessageBox.Show("id: " + prod.ID.ToString());
                                    //MessageBox.Show("ilosc: " + s.ilosc[p].ToString());
                                    if (my_magasin[o].quantity - s.quantity[p] * product[deleteID - 1].quantity > 0)
                                        my_magasin[o].quantity = my_magasin[o].quantity - s.quantity[p] * product[deleteID - 1].quantity;
                                    else
                                    {
                                        MessageBox.Show("Masz za mało składników aby zrobić to zamówienie!!!");
                                        goto et1;
                                    }
                                }
                                o++;
                            }

                        }
                        p++;
                    }
                }
                listView2.Items.Clear();
                int l = 0;
                int op = 0;
                foreach (ComponentsInWarehouse ite in my_magasin)
                {
                    if (my_magasin[op].quantity < my_magasin[op].required_quantity)
                    {
                        ListViewItem order1 = new ListViewItem(ite.ID.ToString());
                        order1.SubItems.Add(ite.name);
                        order1.SubItems.Add(ite.quantity.ToString());
                        order1.SubItems.Add(ite.required_quantity.ToString());
                        order1.SubItems.Add(ite.unit);
                        listView2.Items.Add(order1);
                        if (my_magasin[op].quantity < my_magasin[op].required_quantity)
                            listView2.Items[l].BackColor = Color.Yellow;
                        if (my_magasin[op].quantity < 0.5 * my_magasin[op].required_quantity)
                            listView2.Items[l].BackColor = Color.Red;

                        l++;
                    }
                    op++;
                }
                op = 0;
                l = 0; // Showing listview2
                listView3.SelectedItems[0].Remove();
                int i = 0;
                bool j = false;
                foreach (ProductsClass item in products_to_do)
                {
                    if (item.ID == deleteID)
                    {
                        products_already_done.Add(item);
                        j = true;
                        break;
                    }
                    i++;
                }
                if (j)
                    products_to_do.RemoveAt(i);
                listView4.Items.Clear();
                int it = 0;
                foreach (ProductsClass ite in products_already_done)
                {
                    ListViewItem order = new ListViewItem(products_already_done[it].ID.ToString());
                    order.SubItems.Add(products_already_done[it].name);
                    order.SubItems.Add(products_already_done[it].quantity.ToString());
                    order.SubItems.Add(products_already_done[it].unit);
                    listView4.Items.Add(order);
                    it++;
                }
                it = 0;
            }
            catch
            {
                MessageBox.Show("Proszę podświetlić zrobione zamówienie.");
            }
            et1: deleteID++;
        }

        private void button7_Click(object sender, EventArgs e) // Adding product to do
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text)) // Validation
                MessageBox.Show("Wpisz Ilość!");
            else
            {
                int ID;
                ID = listBox1.SelectedIndex + 1;
                foreach (ProductsClass item in product)
                {
                    if (item.ID == ID)
                    {
                        products_to_do.Add(item);
                        product[ID - 1].quantity = Int32.Parse(textBox5.Text);
                        ListViewItem order = new ListViewItem(products_to_do[products_to_do.Count - 1].ID.ToString());
                        order.SubItems.Add(products_to_do[products_to_do.Count - 1].name);
                        order.SubItems.Add(products_to_do[products_to_do.Count - 1].quantity.ToString());
                        order.SubItems.Add(products_to_do[products_to_do.Count - 1].unit);
                        listView3.Items.Add(order);
                        List<int> ids = new List<int>(Array.ConvertAll(products_to_do[products_to_do.Count - 1].componentID.Split(','), int.Parse));
                        List<int> ilosci = new List<int>(Array.ConvertAll(products_to_do[products_to_do.Count - 1].quantityofproducts.Split(','), int.Parse));
                        component.Add(new Component(ids, ilosci, products_to_do[products_to_do.Count - 1].ID));
                    }
                }
                // Quantity after order

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /* Starting serialization */
            SaveData.serialization((date + "do_zrobienia.xml"), products_to_do, "Products");
            SaveData.serialization((date + "zrobione.xml"), products_already_done, "Products");
            SaveData.serialization(("skladniki.xml"), my_magasin, "Skladniki");
            /* Ending serialization */
            Application.Exit();
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

        private void button9_Click(object sender, EventArgs e)     // Button which opens RaportForm
        {
            /* Starting serialization */
            SaveData.serialization((date + "do_zrobienia.xml"), products_to_do, "Products");
            SaveData.serialization((date + "zrobione.xml"), products_already_done, "Products");
            SaveData.serialization(("skladniki.xml"), my_magasin, "Skladniki");
            /* Ending serialization */
            this.Hide();                                                   // Hide form MainWindow
            RaportForm raport = new RaportForm();                          // Create new form - RaportFrom
            raport.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
