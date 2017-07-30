﻿using System;
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
using System.Xml.Serialization;

namespace BakeryAssistant
{
    public partial class Logowanie : Form
    {
        List<Login> logins = new List<Login>();//list of our existing users
           
        public Logowanie()
        {
            InitializeComponent();
            XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.Load("users.xml");
                XmlNodeList DaneNodesList = oXmlDocument.GetElementsByTagName("Login");
                foreach (XmlNode Dana in DaneNodesList)
                {
                    logins.Add(new Login(Dana.FirstChild.InnerText, Dana.LastChild.InnerText));
                   
                  }
            }
            catch
            {
            }
            textBox2.PasswordChar = '*';   //Hashing password
            textBox2.MaxLength = 14;       //Password max length = 14
            foreach (Login user in logins)
            {
                user.Username = user.Decipher(user.Username);
                user.Password = user.Decipher(user.Password);
            }
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
            /*
             ----LOGINY I HASLA DLA NASZYCH UZYTKOWNIKOW----
             logins.Add(new Login("admin", "admin1"));
            logins.Add(new Login("SzefTomek", "bulka69"));
            logins.Add(new Login("KierowcaJan", "honda8"));
            logins.Add(new Login("KasjerkaKasia", "kamil1999"));
            logins.Add(new Login("PiekarzAndrzej", "okon123"));*/

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Pole nazwa nie może pozostać puste!");
            }
            else
            {
                if(string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Pole hasło nie może pozostać puste!");
                }
                else
                {
                    string login = textBox1.Text;
                    string password = textBox2.Text;

                    var login_query =
                            from names in logins
                            where names.Username == login
                            select names.Username;

                    var pass_query = logins.Select(n => n).Where(n => n.Password == password).ToList();
                    if (login_query.Count() > 0 && pass_query.Count() > 0)
                    {
                        foreach (Login user in logins)
                        {
                            user.Username = user.Cipher(user.Username);
                            user.Password = user.Cipher(user.Password);
                        }
                        /* Początek serializacji */
                        XmlRootAttribute oRootAttr = new XmlRootAttribute();
                        oRootAttr.ElementName = "Login";
                        oRootAttr.IsNullable = true;
                        XmlSerializer oSerializer = new XmlSerializer(typeof(List<Login>), oRootAttr);
                        StreamWriter oStreamWriter = null;
                        try
                        {
                            oStreamWriter = new StreamWriter("users.xml");
                            oSerializer.Serialize(oStreamWriter, logins);
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
                        /* Koniec serializacji do pliku orders.xml*/
                        this.Hide();                                                   // Hide form languageSelect
                        MainWindow s = new MainWindow();                               // Create new form - MainWindow
                        s.Show();
                    }
                    else
                    {
                        MessageBox.Show("Błąd logowania; niepoprawny login lub hasło");
                    }
                }
            }
            

                
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}