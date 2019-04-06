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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            post("http://event-lcc.000webhostapp.com/log_in.php?action=1" +
                        "&us=" + HttpUtility.UrlEncode(textBox1.Text) +
                         "&pa=" + HttpUtility.UrlEncode(textBox2.Text));
        }

        async void post(string destination)
        {
            progressBar1.Visible = true;
            Console.WriteLine(DateTime.Now.ToString() + " - " + destination);

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = await httpClient.GetStringAsync(destination);
                    Console.WriteLine(DateTime.Now.ToString() + " - " + json);

                    JObject data = JObject.Parse(json);
                    String values = data["result"].ToString();

                    DataTable dt = new DataTable();
                    dt = (DataTable)JsonConvert.DeserializeObject(values, (typeof(DataTable)));

                    if (dt.Rows[0][0].ToString().Equals(""))
                    {
                        MessageBox.Show("No data found",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    else 
                    {
                        Global.ACTIVE = dt.Rows[0][2].ToString();
                        Global.TYPE = dt.Rows[0][3].ToString();

                        FMenu f = new FMenu();
                        f.Show();

                        this.Hide();
                    }
                    
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString());
                }
                finally
                {
                    progressBar1.Visible = false;
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRegist f = new FRegist();
            f.ShowDialog(); 
        }
    }
}
