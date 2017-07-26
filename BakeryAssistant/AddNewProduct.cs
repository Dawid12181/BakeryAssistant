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
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
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
            if (checkedListBox1.CheckedItems.Count == 0) //checking if there are any checked products
                MessageBox.Show("Nie wybrano żadnego produktu!");
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("      Nie podano ilości!      ");
            if (comboBox1.SelectedItem == null)
                MessageBox.Show("    Nie wybrano jednostki!   ");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
