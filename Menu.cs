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
            MessageBox.Show("BOTON3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BOTON2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BOTON1");
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }
    }
}
