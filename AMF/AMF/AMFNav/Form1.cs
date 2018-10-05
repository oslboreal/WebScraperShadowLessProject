using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMFNav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            string postData = "email=oslboreal@gmail.com&password=mamadera223&login_button=Login";
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(postData);
            string url = "http://addmefast.com/";
            webBrowser1.Navigate(url, string.Empty, bytes, "Content-Type: application/x-www-form-urlencoded");
            
        }
    }
}
