using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication1
{
    public partial class FPengguna : Form
    {
        //add references pada solution explorer: "System.Net.Http"
        //newtonsoft.json dari nuget console

        DataTable dt_pengguna;
        String title;

        public FPengguna()
        {
            InitializeComponent();
            title = this.Text;
            progressBar1.Visible = false;
        }

        async void showGrid(string destination){
            dt_pengguna = new DataTable();
            progressBar1.Visible = true;
            tb_log.Text = DateTime.Now.ToString() + " - " + destination;

            try
            {                
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(destination);
                    tb_log.Text = DateTime.Now.ToString() + " - " + json;

                    JObject data = JObject.Parse(json);
                    String values = data["result"].ToString();
                    dt_pengguna = (DataTable)JsonConvert.DeserializeObject(values, (typeof(DataTable)));
                }
                dataGridView1.DataSource = dt_pengguna;
            }
            catch (HttpRequestException ex)
            {
                tb_log.Text = DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString();
            }
            finally 
            {
                progressBar1.Visible = false;
            }
        }

        async void post(string destination)
        {
            progressBar1.Visible = true;
            tb_log.Text = DateTime.Now.ToString() + " - " + destination;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = await httpClient.GetStringAsync(destination);
                    tb_log.Text = DateTime.Now.ToString() + " - " + json;
                }
                catch (HttpRequestException ex)
                {
                    tb_log.Text = DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString();
                }
                finally
                {
                    progressBar1.Visible = false;
                }           
            }

        }

        void button4_Click(object sender, EventArgs e)
        {
            showGrid("http://event-lcc.000webhostapp.com/pengguna.php?action=5&find="+ tb_cari.Text);
        }

        void button3_Click(object sender, EventArgs e)
        {
            if (tb_password.Text != tb_retype.Text) {
                MessageBox.Show("Password is not match");
                return;
            }

            if (tb_username.TextLength == 0 && tb_password.TextLength == 0 && tb_retype.TextLength == 0) {
                MessageBox.Show("Data is not complete");
                return;
            }

            this.Text = "Saving: " + tb_username.Text;

            if (tb_username.ReadOnly == true) //update
            {
                if (tb_password.Text == "[private]")
                {
                    post("http://event-lcc.000webhostapp.com/pengguna.php?action=2&username=" + tb_username.Text +
                            "&password=&email=" + tb_email.Text +
                            "&phone=" + tb_phone.Text);
                }
                else    
                {
                    post("http://event-lcc.000webhostapp.com/pengguna.php?action=2&username=" + tb_username.Text +
                            "&password=" + tb_password.Text +
                            "&email=" + tb_email.Text +
                            "&phone=" + tb_phone.Text);
                }
            }else if(tb_username.ReadOnly == false){ //save
                post("http://event-lcc.000webhostapp.com/pengguna.php?action=1&username=" + tb_username.Text + 
                        "&password=" + tb_password.Text  + 
                        "&email=" + tb_email.Text +
                        "&phone=" + tb_phone.Text);                          
            }

            button1_Click(null, null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            try
            {
                tb_username.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                tb_username.ReadOnly = true;
                tb_password.Text = "[private]"; tb_password.ReadOnly = true;
                tb_retype.Text = "[private]"; tb_retype.ReadOnly = true;
                tb_email.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                tb_phone.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                bt_change.Visible = true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            tabControl1.SelectedIndex = 0;
        }

        async void button2_Click(object sender, EventArgs e)
        {
            if (tb_username.ReadOnly == true)
            {
                DialogResult res = MessageBox.Show("Hapus " + tb_username.Text + "?", 
                                                    "Perhatian", 
                                                    MessageBoxButtons.OKCancel, 
                                                    MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    post("http://event-lcc.000webhostapp.com/pengguna.php?action=3&username=" + tb_username.Text);
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Penghapusan data " + tb_username.Text + " dibatalkan");
                }
            }

            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_username.Text = null; tb_username.ReadOnly = false;
            tb_password.Text = null; tb_password.ReadOnly = false;
            tb_retype.Text = null; tb_retype.ReadOnly = false;
            tb_email.Text = null;
            tb_phone.Text = null;
            bt_change.Text = "Change"; bt_change.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) {
                showGrid("http://event-lcc.000webhostapp.com/pengguna.php?action=4");       
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bt_change.Text == "Cancel")
            {
                tb_password.Text = "[private]"; tb_password.ReadOnly = true;
                tb_retype.Text = "[private]"; tb_retype.ReadOnly = true;
                bt_change.Text = "Change";
            }
            else {
                tb_password.Text = null; tb_password.ReadOnly = false;
                tb_retype.Text = null; tb_retype.ReadOnly = false;
                bt_change.Text = "Cancel";
            }
        }                       
    }
}
