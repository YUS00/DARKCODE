using System;
using System.Data;
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

            string username;
            string password;
            string query;
            string device = "";
            string hostname;

            //User

            username = textBox1.Text;
            password = textBox3.Text;
            query = "select * from Users where codeuser = '" + username + "' AND password = '" + password + "'";

            BaseDatosDUAL.DataBase BD = new BaseDatosDUAL.DataBase();

            DataSet dades = BD.PortarPerConsulta(query);


            //Dispositivo y User

            //Dades_usuari User_Data = new Dades_usuari();
            //hostname = User_Data.GetHostName(device);
            //query = "select * from MessiUsers where idDevice = '" + hostname + "' AND idUser = '" + username + "'";

            //Registros 

            int registres = dades.Tables[0].Rows.Count;


            //if ((this.textBox1.Text == "Admin") && (this.textBox3.Text == "admin"))

            if (registres > 0)
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