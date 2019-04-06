using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FRegist : Form
    {
        public FRegist()
        {
            InitializeComponent();
        }

        async void button1_Click(object sender, EventArgs e)
        {           
            progressBar1.Visible = true;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    string destination= "http://event-lcc.000webhostapp.com/pengguna.php?action=1" +
                                "&username=" + HttpUtility.UrlEncode(textBox1.Text) +
                                "&password=" + HttpUtility.UrlEncode(textBox2.Text) +
                                "&phone=" + HttpUtility.UrlEncode(textBox3.Text) +
                                "&email=" + HttpUtility.UrlEncode(textBox4.Text) +
                                "&active=Yes&type=User";

                    var json = await httpClient.GetStringAsync(destination);
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show(DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString());
                }
                finally 
                {
                    progressBar1.Visible = false;
                    this.Hide();
                }
            }
        }          
    }
}

