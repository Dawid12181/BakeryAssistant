using BakeryAssistant.raport_dekorators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BakeryAssistant
{
    public partial class RaportForm : Form
    {
        List<ProductsClass> produkty_zrobione = new List<ProductsClass>();
        List<ComponentsInWarehouse> my_magasin = new List<ComponentsInWarehouse>();
        List<Skladnik> skladnik = new List<Skladnik>();
        DateTime startdate = DateTime.Now.AddMonths(-1);
        double koszt, obrot;
        public RaportForm()
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
                }
            }
            catch
            {
            }
            while ((DateTime.Now-startdate).Days!=0) // Showing last 30 raports
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"/" + startdate.ToString("dd_MM_yyyy") + "zrobione.XML"))
                {
                    XmlDocument oXm4Document = new XmlDocument();
                    try
                    {
                        oXm4Document.Load(startdate.ToString("dd_MM_yyyy") + "zrobione.xml");
                        XmlNodeList DaneNodesList4 = oXm4Document.GetElementsByTagName("ProductsClass");
                        foreach (XmlNode Dana in DaneNodesList4)
                        {
                            produkty_zrobione.Add(new ProductsClass(Int32.Parse(Dana.FirstChild.InnerText), Dana.FirstChild.NextSibling.InnerText, Int32.Parse(Dana.FirstChild.NextSibling.NextSibling.InnerText), Dana.LastChild.PreviousSibling.PreviousSibling.PreviousSibling.InnerText, Double.Parse(Dana.LastChild.PreviousSibling.PreviousSibling.InnerText.Replace('.', ',')), Dana.LastChild.PreviousSibling.InnerText, Dana.LastChild.InnerText));
                            List<int> ids = new List<int>(Array.ConvertAll(produkty_zrobione[produkty_zrobione.Count - 1].idskladnika.Split(','), int.Parse));
                            List<int> ilosci = new List<int>(Array.ConvertAll(produkty_zrobione[produkty_zrobione.Count - 1].iloscproduktu.Split(','), int.Parse));
                            skladnik.Add(new Skladnik(ids, ilosci, produkty_zrobione[produkty_zrobione.Count - 1].ID));
                        }
                    }
                    catch
                    {
                    }
    

                    foreach (ProductsClass produkt in produkty_zrobione)
                    {
                        obrot = obrot + produkt.cena*produkt.ilosc;
                    }
                    int j=0;
                    foreach (Skladnik s in skladnik)
                    {
                        int o = 0;
                        foreach (int id in s.ID)
                        {
                            //MessageBox.Show("ID skladnika: " + id.ToString() + " Ilosc skladnika: " + s.ilosc[o]);
                            int p = 0;
                            foreach (ComponentsInWarehouse k in my_magasin)
                            {
                                if (k.ID == id)
                                {
                                    //MessageBox.Show("Ilość składnika: " + s.ilosc[o] + "  Ilość produktu: " + produkty_zrobione[j].ilosc );
                                    koszt = koszt + (k.cena_zakupu * s.ilosc[o]) * produkty_zrobione[j].ilosc;
                                }
                                p++;
                            }
                            o++;
                        }
                            j++;
                    }
                    ListViewItem order = new ListViewItem(startdate.ToString("dd.MM.yyyy"));
                    order.SubItems.Add(koszt.ToString() + " zł");
                    order.SubItems.Add(obrot.ToString() + " zł");
                    order.SubItems.Add((obrot-koszt).ToString() + " zł");
                    listView1.Items.Add(order);
                }
                else
                {
                    ListViewItem order = new ListViewItem(startdate.ToString("dd.MM.yyyy"));
                    order.SubItems.Add("Brak Danych");
                    order.SubItems.Add("Brak Danych");
                    order.SubItems.Add("Brak Danych");
                    listView1.Items.Add(order);
                }
                startdate=startdate.AddDays(1);
                obrot = 0;
                koszt = 0;
                produkty_zrobione.Clear();
                skladnik.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (comboBox1.SelectedItem != null){
                List<Worker> pracownik = new List<Worker>();
                pracownik.Add(new Salesman());
                pracownik.Add(new Driver());
                pracownik.Add(new Baker());
                int g = comboBox1.SelectedIndex;
                if (checkBox1.Checked)
                    pracownik[g] = new NockiDekorator(pracownik[g]);
                if (checkBox2.Checked)
                    pracownik[g] = new NadgodzinyDekorator(pracownik[g]);
                if (checkBox3.Checked)
                    pracownik[g] = new WeekendyDekorator(pracownik[g]);
                if (checkBox4.Checked)
                    pracownik[g] = new ChoroboweDekorator(pracownik[g]);
                MessageBox.Show(pracownik[g].GetName() + " " + pracownik[g].salary().ToString() + "pln");
            }
           else
            {
                MessageBox.Show("Proszę wybrać pracownika");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();                                                   // Hide form AddNewProduct
            MainWindow s = new MainWindow();                               // Create new form - MainWindow
            s.Show();
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
