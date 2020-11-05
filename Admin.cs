using System;
using System.Windows.Forms;

namespace timer
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dades_equip fm4 = new Dades_equip();
            fm4.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dades_usuari fm5 = new Dades_usuari();
            fm5.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
