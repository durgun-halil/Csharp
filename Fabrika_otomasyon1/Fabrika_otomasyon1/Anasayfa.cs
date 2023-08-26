using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabrika_otomasyon1
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Depo depoo = new Depo();
            depoo.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uretim uretimm = new Uretim();
            uretimm.Show();
            this.Hide();
        }
    }
}
