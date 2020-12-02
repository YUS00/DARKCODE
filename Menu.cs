using System;
using System.Windows.Forms;

namespace timer
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BOTON4");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dades_usuari fm3 = new Dades_usuari();
            fm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Coordenadas fm2 = new Coordenadas();
            fm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dades_equip fm1 = new Dades_equip();
            fm1.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }
    }
}
