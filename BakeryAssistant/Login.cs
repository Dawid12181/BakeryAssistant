using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryAssistant
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Login()
        {

        }
        public Login(string sUsername, string sPassword)
        {
            Username = sUsername;
            Password = sPassword;
        }

        public string Cipher(string name)
        {   
            string ciphered_name = "";
            string alph = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            Dictionary<int, char> alphabet = new Dictionary<int, char>();
            for (int i = 0; i < alph.Length; i++)
            {
                alphabet.Add(i, alph[i]);
            }

            for (int i = 0; i < name.Length; i++)
            {
                var char_query = alphabet.Select(n => n).Where(n => n.Value == name[i]).ToList();
                int indx = char_query[0].Key + 7;      
                if (indx >= alphabet.Count())
                {
                    indx = indx - alphabet.Count();
                }
                var newChar_query = alphabet.Select(n => n).Where(n => n.Key == indx).ToList();
                
                ciphered_name = ciphered_name + newChar_query[0].Value;
                 //MessageBox.Show(ciphered_name);
            }
            return ciphered_name;

        }

        public string Decipher(string name)
        {
            string deciphered_name = "";
            string alph = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            Dictionary<int, char> alphabet = new Dictionary<int, char>();
            for (int i = 0; i < alph.Length; i++)
            {
                alphabet.Add(i, alph[i]);
            }
            for (int i = 0; i < name.Length; i++)
            {
                var char_query = alphabet.Select(n => n).Where(n => n.Value == name[i]).ToList();
                int indx = char_query[0].Key - 7;
                if(indx<0)
                {
                    indx = alphabet.Count + indx;
                }
                var newChar_query = alphabet.Select(n => n).Where(n => n.Key == indx).ToList();
                deciphered_name = deciphered_name + newChar_query[0].Value;
            }
            return deciphered_name;
        }
    }
}
