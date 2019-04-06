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
        }

        async void showGrid(string destination)
        {
            dt_peserta = new DataTable();
            tblog.Text = DateTime.Now.ToString() + " - " + destination;
            progressBar1.Visible = true;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(destination);
                    tblog.Text = DateTime.Now.ToString() + " - " + json;

                    JObject data = JObject.Parse(json);
                    String values = data["result"].ToString();
                    dt_peserta = (DataTable)JsonConvert.DeserializeObject(values, (typeof(DataTable)));
                }

                dataGridView2.Columns.Clear();

                if (dt_peserta.Rows.Count == 0) return;
                dataGridView2.DataSource = dt_peserta;

                DataGridViewButtonColumn btnSave = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnSave);
                btnSave.Text = "Save";
                btnSave.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnDelete);
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;

                dataGridView2.Columns[0].ReadOnly = true;
                dataGridView2.Columns[6].ReadOnly = true;

                dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.Aquamarine;
                dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.Aquamarine;

                dataGridView2.Columns[0].Width = 50; //id
                dataGridView2.Columns[7].Width = 50; //save
                dataGridView2.Columns[8].Width = 60; //delete

                dataGridView2.AllowUserToAddRows = false;

            }
            catch (HttpRequestException ex)
            {
                tblog.Text = DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString();
            }
            finally 
            {
                progressBar1.Visible = false;
            }
        }

        async void post(string destination)
        {
            tblog.Text = DateTime.Now.ToString() + " - " + destination;
            progressBar1.Visible = true;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = await httpClient.GetStringAsync(destination);
                    tblog.Text = DateTime.Now.ToString() + " - " + json;
                    showGrid("http://event-lcc.000webhostapp.com/peserta.php?action=4");
                }
                catch (HttpRequestException ex)
                {
                    tblog.Text = DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString();
                }
                finally 
                {
                    progressBar1.Visible = false;
                }
            }
        }
      
        private void FPeserta_Load(object sender, EventArgs e)
        {
            showGrid("http://event-lcc.000webhostapp.com/peserta.php?action=4");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
            {
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;

                dataGridView2.ColumnCount = 7;
                dataGridView2.Columns[0].Name = "ID";
                dataGridView2.Columns[1].Name = "NAMA";
                dataGridView2.Columns[2].Name = "KAMPUS";
                dataGridView2.Columns[3].Name = "WHATSAPP";
                dataGridView2.Columns[4].Name = "PHONE";
                dataGridView2.Columns[5].Name = "EMAIL";
                dataGridView2.Columns[6].Name = "INPUT";

                //DataGridViewTextBoxColumn tbUsername = new DataGridViewTextBoxColumn();
                //dataGridView2.Columns.Add(tbUsername);
                //tbUsername.HeaderText = "ID";

                //DataGridViewTextBoxColumn tbEmail = new DataGridViewTextBoxColumn();
                //dataGridView2.Columns.Add(tbEmail);
                //tbEmail.HeaderText = "email";

                //DataGridViewTextBoxColumn tbPhone = new DataGridViewTextBoxColumn();
                //dataGridView2.Columns.Add(tbPhone);
                //tbPhone.HeaderText = "phone";

                DataGridViewButtonColumn btnSave = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnSave);
                btnSave.Text = "Save";
                btnSave.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnDelete);
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;

                dataGridView2.AllowUserToAddRows = true;

                dataGridView2.Columns[0].ReadOnly = true;
                dataGridView2.Columns[6].ReadOnly = true;

                dataGridView2.Columns[0].Width = 50; //save
                dataGridView2.Columns[7].Width = 50; //save
                dataGridView2.Columns[8].Width = 60; //delete
            }
            else
            {
                dataGridView2.AllowUserToAddRows = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int jumlah = dataGridView2.Rows.Count;
            int i = dataGridView2.CurrentRow.Index;

            if (e.ColumnIndex == 7)  //simpan
            {
                dataGridView2.Enabled = false;

                if (e.RowIndex != dataGridView2.NewRowIndex)
                { //save
                    if (dataGridView2.NewRowIndex == -1)
                    {
                        post("http://event-lcc.000webhostapp.com/peserta.php?action=2" +
                                "&id=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[0].Value.ToString()) +
                                "&nama=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[1].Value.ToString()) +
                                "&kampus=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[2].Value.ToString()) +
                                "&wa=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[3].Value.ToString()) +
                                "&phone=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[4].Value.ToString()) +
                                "&email=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[5].Value.ToString()));
                    }
                    else
                    {
                        post("http://event-lcc.000webhostapp.com/peserta.php?action=1" +
                                "&nama=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[1].Value.ToString()) +
                                "&kampus=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[2].Value.ToString()) +
                                "&wa=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[3].Value.ToString()) +
                                "&phone=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[4].Value.ToString()) +
                                "&email=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[5].Value.ToString()));
                    }

                }

                dataGridView2.Enabled = true;

            }
            else if (e.ColumnIndex == 8)  //hapus
            {
                DialogResult res = MessageBox.Show("Hapus " + dataGridView2.Rows[i].Cells[1].Value.ToString() + "?",
                                                    "Perhatian",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    post("http://event-lcc.000webhostapp.com/peserta.php?action=3&id=" + dataGridView2.Rows[i].Cells[0].Value.ToString());                    
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Penghapusan data " + dataGridView2.Rows[i].Cells[0].Value.ToString() + " dibatalkan");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showGrid("http://event-lcc.000webhostapp.com/peserta.php?action=5&find=" + textBox3.Text);
        }
    }
}
