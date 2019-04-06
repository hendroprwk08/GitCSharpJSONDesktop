using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FPeserta f = new FPeserta();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Global.TYPE != "Admin")
            {
                MessageBox.Show("Not allowed");
            }
            else 
            {
                FPengguna f = new FPengguna();
                f.MdiParent = this;
                f.Show();
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FEvent f = new FEvent();
            f.MdiParent = this;
            f.Show();
        }

        private void FMenu_Load(object sender, EventArgs e)
        {

        }

        private void FMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
