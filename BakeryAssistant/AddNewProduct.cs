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
    public partial class AddNewProduct : Form
    {
        List<Produkty> nowy_produkt = new List<Produkty>();
        List<ProduktyMagazyn> my_magasin = new List<ProduktyMagazyn>();
        string idskladnika, iloscskladnika;
        public AddNewProduct()
        {
            InitializeComponent();
            XmlDocument oXm2Document = new XmlDocument();
            try
            {
                oXm2Document.Load("skladniki.xml");
                XmlNodeList DaneNodesList2 = oXm2Document.GetElementsByTagName("ProduktyMagazyn");
                foreach (XmlNode Dana in DaneNodesList2)
                {
                    my_magasin.Add(new ProduktyMagazyn(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Dana.FirstChild.NextSibling.NextSibling.InnerText, Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText), Int32.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.PreviousSibling.InnerText), Double.Parse(Dana.LastChild.InnerText)));
                    checkedListBox1.Items.Insert(my_magasin[my_magasin.Count - 1].ID-1, my_magasin[my_magasin.Count - 1].nazwa);
                    /* Adding components from list my_magasin to checkedlistbox, IMPORTANT ID-1! */
                }
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
                    nowy_produkt.Add(new Produkty(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                    checkedListBox2.Items.Insert(nowy_produkt[nowy_produkt.Count - 1].ID - 1, nowy_produkt[nowy_produkt.Count - 1].nazwa);
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();                                                   // Hide form AddNewProduct
            MainWindow s = new MainWindow();                               // Create new form - MainWindow
            s.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 1) //checking if there are no more checked products than one 
                MessageBox.Show("Proszę wybrać tylko jeden produkt na raz!");
            else
            {
                if (checkedListBox1.CheckedItems.Count == 0) //checking if there are any checked products
                    MessageBox.Show("Nie wybrano żadnego produktu!");
                else
                {
                    int quantity; //quantity of component measured in gram/piece
                    if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox1.Text, out quantity))//checking if is not empty quantity
                        MessageBox.Show("Nie podano ilości lub źle wprowadzono ilość!");
                    else
                    {
                        if (comboBox1.SelectedItem == null)//unit not choosed
                            MessageBox.Show("    Nie wybrano jednostki!   ");
                        else
                        {
                            int.TryParse(textBox1.Text,out quantity);//just parsing to int; need to objects count raports etc.
                            string unit = comboBox1.SelectedItem.ToString(); //unit of component gram/piecie
                            string name="";//name of component send from checkedListBox to ListBox
                            foreach (string s in checkedListBox1.CheckedItems)//getting the name of all checked items(our case it can be only 1 checked item)
                            {
                                name = s; //writing this name to our
                            }
                            foreach( int id in checkedListBox1.CheckedIndices)
                            {
                                int index = id+1;
                                idskladnika = idskladnika + " " + index.ToString();
                                iloscskladnika = iloscskladnika + " " + quantity.ToString();
                            }
                            string ComponentString = name + ' ' + quantity.ToString()+ ' ' + unit; //final message to listBox
                            listBox1.Items.Add(ComponentString);//sending to listBox
                            foreach (int indx in checkedListBox1.CheckedIndices) //uncheck checkBoxList after adding new component to our product
                                checkedListBox1.SetItemCheckState(indx, CheckState.Unchecked);
                        }
                    }
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)//Przycisk usun
        {
            if (listBox1.SelectedIndices.Count>0)
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
        }

        private void button2_Click(object sender, EventArgs e)//Dodanie produktu do listy produktów. XML
        {
            string jednostka = "j";
            if (radioButton1.Checked)
                jednostka = "szt";
            else if (radioButton2.Checked)
                jednostka = "gram";
            else
                MessageBox.Show("Prosze wybrać jednostkę");
            nowy_produkt.Add(new Produkty(nowy_produkt.Count + 1,textBox3.Text, Int32.Parse(textBox4.Text), jednostka, Double.Parse(textBox5.Text), idskladnika, iloscskladnika));
            /* Początek serializacji */
            XmlRootAttribute oRootAttr = new XmlRootAttribute();
            oRootAttr.ElementName = "Products";
            oRootAttr.IsNullable = true;
            XmlSerializer oSerializer = new XmlSerializer(typeof(List<Produkty>), oRootAttr);
            StreamWriter oStreamWriter = null;
            try
            {
                oStreamWriter = new StreamWriter("produkty.xml");
                oSerializer.Serialize(oStreamWriter, nowy_produkt);
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
    }
}
