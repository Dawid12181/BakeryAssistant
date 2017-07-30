using BakeryAssistant.raport_dekorators;
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
    public partial class RaportForm : Form
    {
        public RaportForm()
        {
            InitializeComponent();
            ListViewItem order = new ListViewItem("29.07.2017");
            order.SubItems.Add(850.55.ToString());
            order.SubItems.Add(2137.69.ToString());
            order.SubItems.Add((2137.69-850.55).ToString());
            listView1.Items.Add(order);
            ListViewItem order1 = new ListViewItem("30.07.2017");
            order1.SubItems.Add(630.15.ToString());
            order1.SubItems.Add(1410.99.ToString());
            order1.SubItems.Add((1410.99 - 630.15).ToString());
            listView1.Items.Add(order1);
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
