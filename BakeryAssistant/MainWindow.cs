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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;

            while (obj != null && obj != myListView)
            {
                if (obj.GetType() == typeof(ListViewItem))
                {
                    // Do something here
                    MessageBox.Show("A ListViewItem was double clicked!");

                    break;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //just checking \/ listView; check for urself, dont think it will work because too much text for "Zamówienie" 
            ListViewItem order = new ListViewItem("Pani Zosia G.");
            order.SubItems.Add("Topolowa 24");
            order.SubItems.Add("codziennie od 5:00-5:30 oprócz sobót");
            order.SubItems.Add("3x bulka paryska, 5x chleb razowy, 10x bulka pszenna, 6x drozdzowka z makiem + paczki jak bedą robione");
            listView1.Items.Add(order);
        }
    }
}
