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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';   //Hashing password
            textBox2.MaxLength = 14;       //Password max length = 14
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Checking if user is logged
            string u1 = textBox1.Text;
            string p1 = textBox2.Text;
            string username = "Stasiek";
            string password = "1234";
            if (u1 == username)
                if (p1 == password)
                {
                    this.Hide();                                                   // Hide form languageSelect
                    MainWindow s = new MainWindow();                               // Create new form - MainWindow
                    s.Show();
                }
            else
                {
                    textBox1.BackColor = Color.White;                              // Changing the color of textbox
                    MessageBox.Show("Błędne hasło");
                    textBox2.BackColor = Color.Red;
                }
            else
            {
                MessageBox.Show("Błędny login");
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
        } 
        
    }
}
