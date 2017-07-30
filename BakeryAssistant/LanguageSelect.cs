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
    public partial class LanguageSelect : Form
    {
        public LanguageSelect()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)   // Choosing polish
        {
            this.Hide();                                         // Hide form languageSelect
            Logowanie s = new Logowanie();                               // Create new form - Login
            s.Show();                                            // Show window
        }

        private void button1_Click_1(object sender, EventArgs e) // Choosing english
        {
            this.Hide();                                         // Hide form languageSelect
            Logowanie s = new Logowanie();                               // Create new form - Login
            s.Show();                                            // Show window
        }
    }
}
