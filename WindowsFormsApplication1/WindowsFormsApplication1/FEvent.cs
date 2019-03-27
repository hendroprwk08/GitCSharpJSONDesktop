using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FEvent : Form
    {
        int id;
        String title, log;
        private DataTable dt_event;

        public FEvent()
        {
            InitializeComponent();
            title = this.Text;
            progressBar1.Visible = false;
            log = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = 0;
            tb_event.Text = "";
            tb_deskripsi.Text = "";
            dtp_tanggal.Value = DateTime.Now;
            dtp_jam.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String tgl = dtp_tanggal.Value.ToString("yyyy-MM-dd");
            String jam = dtp_jam.Value.ToString("HH:mm");

            if (id > 0) //update
            {               
                post("http://event-lcc.000webhostapp.com/event.php?action=2" +
                        "&id=" + id +
                        "&event=" + HttpUtility.UrlEncode(tb_event.Text) +
                        "&deskripsi=" + HttpUtility.UrlEncode(tb_deskripsi.Text) +
                        "&tgl=" + tgl +
                        "&jam=" + jam );
            }
            else
            { //save
                post("http://event-lcc.000webhostapp.com/event.php?action=1" +
                         "&event=" + HttpUtility.UrlEncode(tb_event.Text) +
                         "&deskripsi=" + HttpUtility.UrlEncode(tb_deskripsi.Text) +
                         "&tgl=" + tgl +
                         "&jam=" + jam);
            }

            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DialogResult res = MessageBox.Show("Hapus " + tb_event.Text + "?",
                                                    "Perhatian",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    post("http://event-lcc.000webhostapp.com/event.php?action=3&id=" + id);
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Penghapusan data " + tb_event.Text + " dibatalkan");
                }
            }

            button1_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showGrid("http://event-lcc.000webhostapp.com/event.php?action=5&find=" + tb_cari.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            try
            {
                id = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                tb_event.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                tb_deskripsi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                dtp_tanggal.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                dtp_jam.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            tabControl1.SelectedIndex = 0;
        }

        async void showGrid(string destination)
        {
            dt_event = new DataTable();
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
                    dt_event = (DataTable)JsonConvert.DeserializeObject(values, (typeof(DataTable)));
                }
                dataGridView1.DataSource = dt_event;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                showGrid("http://event-lcc.000webhostapp.com/event.php?action=4");
            }
        }

    }
}
