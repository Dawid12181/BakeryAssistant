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
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
