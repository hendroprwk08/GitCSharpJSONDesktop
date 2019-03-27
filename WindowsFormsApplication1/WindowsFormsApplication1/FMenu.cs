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

        private void pesertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPeserta f = new FPeserta();
            f.MdiParent = this;
            f.Show();
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEvent f = new FEvent();
            f.MdiParent = this;
            f.Show();
        }

        private void pesertaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FPengguna f = new FPengguna();
            f.MdiParent = this;
            f.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
