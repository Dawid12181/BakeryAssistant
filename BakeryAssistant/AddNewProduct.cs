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
                                name = s; //writing this name to our
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count>0)
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
        }
    }
}
