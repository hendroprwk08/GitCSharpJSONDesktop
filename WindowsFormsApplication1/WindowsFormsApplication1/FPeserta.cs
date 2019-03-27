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
    public partial class FPeserta : Form
    {
        String title;
        int id;
        DataTable dt_peserta;

        public FPeserta()
        {
            InitializeComponent();
            title = this.Text;
            progressBar1.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                showGrid("http://event-lcc.000webhostapp.com/peserta.php?action=4");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_nama.Text = "";
            tb_kampus.Text = "";
            tb_wa.Text = "";
            tb_phone.Text = "";
            tb_email.Text = "";
            id = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0) //update
            {
                post("http://event-lcc.000webhostapp.com/peserta.php?action=2" +
                        "&id=" + id +
                         "&nama=" + HttpUtility.UrlEncode(tb_nama.Text) +
                         "&kampus=" + HttpUtility.UrlEncode(tb_kampus.Text) +
                         "&wa=" + HttpUtility.UrlEncode(tb_wa.Text) +
                         "&phone=" + HttpUtility.UrlEncode(tb_phone.Text) +
                         "&email=" + HttpUtility.UrlEncode(tb_email.Text) );
            }
            else
            { //save
                post("http://event-lcc.000webhostapp.com/peserta.php?action=1" +
                         "&nama=" + HttpUtility.UrlEncode(tb_nama.Text) +
                         "&kampus=" + HttpUtility.UrlEncode(tb_kampus.Text) +
                         "&wa=" + HttpUtility.UrlEncode(tb_wa.Text) +
                         "&phone=" + HttpUtility.UrlEncode(tb_phone.Text) +
                         "&email=" + HttpUtility.UrlEncode(tb_email.Text) );
            }

            button1_Click(null, null);
        }

        async void showGrid(string destination)
        {
            dt_peserta = new DataTable();
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
                    dt_peserta = (DataTable)JsonConvert.DeserializeObject(values, (typeof(DataTable)));
                }
                dataGridView1.DataSource = dt_peserta;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            try
            {
                id = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                tb_nama.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                tb_kampus.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                tb_wa.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                tb_phone.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                tb_email.Text = dataGridView1.Rows[i].Cells[5].Value.ToString(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DialogResult res = MessageBox.Show("Hapus " + tb_nama.Text + "?",
                                                    "Perhatian",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    post("http://event-lcc.000webhostapp.com/peserta.php?action=3&id=" + id);
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Penghapusan data " + tb_nama.Text + " dibatalkan");
                }
            }

            button1_Click(null, null);
        }

        private void FPeserta_Load(object sender, EventArgs e)
        {

        }
    }
}
