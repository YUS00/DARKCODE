using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace timer
{
    public partial class SEGON : Form
    {
        public SEGON()
        {
            InitializeComponent();
        }
            static int attempt = 0;

            private void button1_Click(object sender, EventArgs e)
            {
                string username = textBox1.Text;
                string password = textBox3.Text;

            if ((this.textBox1.Text == "Admin") && (this.textBox3.Text == "admin"))
            {
                attempt = 0;
                MessageBox.Show("ACCESO GARANTIZADO");
            }
            
            else if (attempt++ == 2)
            {
                textBox3.Clear();
                MessageBox.Show("Falló en 3 intentos de inicio de sesión. Acceso no autorizado");
                StreamWriter A = new StreamWriter(@"bin\Debug\log.txt");
                A.WriteLine(DateTime.Now.ToString("yyyyMMdd:HHmmss")+textBox1.Text);
                Application.Exit();
            }
        }

        private void SEGON_Load(object sender, EventArgs e)
        {

        }
    }
}