using System;
using System.IO;
using System.Windows.Forms;

namespace timer
{
    public partial class Login : Form
    {
        public Login()
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
                Menu fm2 = new Menu();
                fm2.Show();
                this.Hide();
            }

            else if (attempt++ == 2)
            {
                textBox3.Clear();
                MessageBox.Show("Falló en 3 intentos de inicio de sesión. Acceso no autorizado");
                StreamWriter A = new StreamWriter(@"bin\Debug\log.txt");
                A.WriteLine(DateTime.Now.ToString("yyyyMMdd:HHmmss") + textBox1.Text);
                Application.Exit();
            }
        }

        private void SEGON_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}