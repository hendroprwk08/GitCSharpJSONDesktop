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
using System.Web;

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
        }

        async void showGrid(string destination){
            dt_pengguna = new DataTable();
            progressBar2.Visible = true;

            tblog.Text = DateTime.Now.ToString() + " - " + destination;

            try
            {                
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(destination);
                    tblog.Text = DateTime.Now.ToString() + " - " + json;

                    JObject data = JObject.Parse(json);
                    String values = data["result"].ToString();
                    dt_pengguna = (DataTable)JsonConvert.DeserializeObject(values, (typeof(DataTable)));
                }

                dataGridView2.Columns.Clear();

                if (dt_pengguna.Rows.Count == 0) return;
                dataGridView2.DataSource = dt_pengguna;
                
                DataGridViewButtonColumn btnSave = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnSave);
                btnSave.Text = "Save";
                btnSave.UseColumnTextForButtonValue = true;
                
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnDelete);
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;

                dataGridView2.Columns[0].ReadOnly = true;

                dataGridView2.Columns[5].Width = 50; //save
                dataGridView2.Columns[6].Width = 60; //delete

                //remove column
                dataGridView2.Columns.RemoveAt(3); //remove active
                dataGridView2.Columns.RemoveAt(3); //remove type
                
                //set combo box
                DataGridViewComboBoxColumn cbActive = new DataGridViewComboBoxColumn();
                cbActive.Items.Add("Yes");
                cbActive.Items.Add("No");
                cbActive.Name = "ACTIVE";
                dataGridView2.Columns.Insert(3, cbActive);

                DataGridViewComboBoxColumn cbType = new DataGridViewComboBoxColumn();
                cbType.Items.Add("Admin");
                cbType.Items.Add("User");
                cbType.Name = "TYPE";
                dataGridView2.Columns.Insert(4, cbType);

                //set selected value DataGridViewComboBoxColumn
                for (int i = 0; i < dt_pengguna.Rows.Count; i++)
                {
                    Console.WriteLine(dataGridView2.Rows[i].Cells[4].Value + " - " + dt_pengguna.Rows[i][3].ToString());
                    dataGridView2.Rows[i].Cells[3].Value = dt_pengguna.Rows[i][3].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = dt_pengguna.Rows[i][4].ToString();
                }
                
            }
            catch (HttpRequestException ex)
            {
                tblog.Text = DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString();
            }
            finally 
            {
                progressBar2.Visible = false;
                dataGridView2.AllowUserToAddRows = false;
            }
        }

        async void post(string destination)
        {
            progressBar2.Visible = true;
            tblog.Text = DateTime.Now.ToString() + " - " + destination;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var json = await httpClient.GetStringAsync(destination);
                    tblog.Text = DateTime.Now.ToString() + " - " + json;
                    FPengguna_Load(null, null);
                }
                catch (HttpRequestException ex)
                {
                    tblog.Text = DateTime.Now.ToString() + " - Error: " + Environment.NewLine + ex.ToString();
                }
                finally
                {
                    progressBar2.Visible = false;
                }           
            }

        }

        private void FPengguna_Load(object sender, EventArgs e)
        {
            showGrid("http://event-lcc.000webhostapp.com/pengguna.php?action=4");   
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int jumlah = dataGridView2.Rows.Count;
            int i = dataGridView2.CurrentRow.Index;

            if (e.ColumnIndex == 5)  //simpan
            {
                dataGridView2.Enabled = false;

                if (e.RowIndex != dataGridView2.NewRowIndex)
                { //save
                    if (dataGridView2.NewRowIndex == -1)
                    {
                        String password = Microsoft.VisualBasic.Interaction.InputBox("Password: " + Environment.NewLine + "Don`t type any character if you won`t change your password", "Caution", "[private]");

                        if (password == "[private]")
                        {
                            post("http://event-lcc.000webhostapp.com/pengguna.php?action=2" +
                               "&username=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[0].Value.ToString()) +
                               "&password=" +
                               "&email=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[1].Value.ToString()) +
                               "&phone=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[2].Value.ToString()) +
                               "&active=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[3].Value.ToString()) +
                               "&type=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[4].Value.ToString()));
                        }
                        else
                        {
                            post("http://event-lcc.000webhostapp.com/pengguna.php?action=2" +
                               "&username=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[0].Value.ToString()) +
                               "&password=" + HttpUtility.UrlEncode(password) +
                               "&email=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[1].Value.ToString()) +
                               "&phone=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[2].Value.ToString()) +
                               "&active=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[3].Value.ToString()) +
                               "&type=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[4].Value.ToString()));
                        }
                    }
                    else 
                    {
                        String password = Microsoft.VisualBasic.Interaction.InputBox("Password", "Caution", "");

                        post("http://event-lcc.000webhostapp.com/pengguna.php?action=1" +
                               "&username=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[0].Value.ToString()) +
                               "&password=" + HttpUtility.UrlEncode(password) +
                               "&email=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[1].Value.ToString()) +
                               "&phone=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[2].Value.ToString()) +
                               "&active=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[3].Value.ToString()) +
                               "&type=" + HttpUtility.UrlEncode(dataGridView2.Rows[i].Cells[4].Value.ToString()));
                    }
                   
                }

                dataGridView2.Enabled = true;
            }
            else if(e.ColumnIndex == 6)  //hapus
            {
                DialogResult res = MessageBox.Show("Hapus " + dataGridView2.Rows[i].Cells[0].Value.ToString() + "?",
                                                    "Perhatian",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    post("http://event-lcc.000webhostapp.com/pengguna.php?action=3&username=" + dataGridView2.Rows[i].Cells[0].Value.ToString());
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("Penghapusan data " + dataGridView2.Rows[i].Cells[0].Value.ToString() + " dibatalkan");
                }
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount == 0)
            {
                dataGridView2.DataSource = null;
                dataGridView2.ColumnCount = 3;
                dataGridView2.Columns[0].Name = "USERNAME";
                dataGridView2.Columns[1].Name = "EMAIL";
                dataGridView2.Columns[2].Name = "PHONE";

                DataGridViewComboBoxColumn cbActive = new DataGridViewComboBoxColumn();
                cbActive.Items.Add("Yes");
                cbActive.Items.Add("No");
                cbActive.Name = "ACTIVE";
                dataGridView2.Columns.Insert(3, cbActive);

                DataGridViewComboBoxColumn cbType = new DataGridViewComboBoxColumn();
                cbType.Items.Add("Admin");
                cbType.Items.Add("User");
                cbType.Name = "TYPE";
                dataGridView2.Columns.Insert(4, cbType);

                DataGridViewButtonColumn btnSave = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnSave);
                btnSave.Text = "Save";
                btnSave.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                dataGridView2.Columns.Add(btnDelete);
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Columns[0].ReadOnly = false;

                dataGridView2.Columns[5].Width = 50; //save
                dataGridView2.Columns[6].Width = 60; //delete
            }
            else
            {
                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Columns[0].ReadOnly = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FPengguna_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showGrid("http://event-lcc.000webhostapp.com/pengguna.php?action=5&find=" + textBox3.Text);
        }             
    }
}
