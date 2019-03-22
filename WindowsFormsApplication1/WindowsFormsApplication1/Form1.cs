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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //add references pada solution explorer: System.Net.Http
        //add Newtonsoft.json dari nuget package
         
        public Form1()
        {
            InitializeComponent();
        }

        async void Form1_Load(object sender, EventArgs e)
        {
            string url = "http://event-lcc.000webhostapp.com/event.php?action=4";
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                
                //json to datatable
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            }
        }
    }
}
