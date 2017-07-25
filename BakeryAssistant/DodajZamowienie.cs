using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryAssistant
{
    public partial class DodajZamowienie : Form
    {
        Zamowienie zam = new Zamowienie();
        public DodajZamowienie()
        {
            InitializeComponent();
        }

        private void DodajZamowienie_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
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
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            string zamowienie;
            zamowienie = listView1.SelectedItems[0].SubItems[3].Text;
            MessageBox.Show("Twoje zamowienie to:  " + zamowienie);
        }
    }
}
