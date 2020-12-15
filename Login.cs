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
            Boolean verificacio;

            //Verificacion del usuario y contraseña de "Users"

            BaseDatosDUAL.DataBase BD = new BaseDatosDUAL.DataBase();

            username = textBox1.Text;
            password = textBox3.Text;
            query = "select * from Users where codeuser = '" + username + "' AND password = '" + password + "'";

            DataSet dades = BD.PortarPerConsulta(query);

            verificacio = Verificar_BD(dades);

            if (!verificacio)
            {
                MessageBox.Show("Error de inicio de sesión: Su usuario no se encuentra en la base de datos. Comprueve sus datos.");
                attempt++;

            }

            //Verificacion del usuario y dispositivo de "MessiUsers"

            else
            {
                Dades_usuari UserData = new Dades_usuari();

                query = "select * from MessiUsers where idDevice = (select idDevice from TrustedDevices where HostName = '" + UserData.GetHostName() + "') and idUser = (select idUser from Users where codeUser = '" + username + "');";

                dades = BD.PortarPerConsulta(query);

                verificacio = Verificar_BD(dades);

                if (!verificacio)
                {
                    MessageBox.Show("Error de inicio de sesión: Su usuario no se encuentra registrado en M.E.S.S.I Users.");
                    attempt++;
                }
            }


            //Verificación final 

            if (verificacio)
            {
                attempt = 0;
                Menu fm2 = new Menu();
                fm2.Show();
                this.Hide();
            }


            else if (attempt >= 3)
            {
                textBox3.Clear();
                MessageBox.Show("Error de inicio de sesión: Falló en " + attempt + " intentos de inicio de sesión. El programa se cerrará.");
                using (StreamWriter A = new StreamWriter(@"log.txt"))
                {
                    A.WriteLine(DateTime.Now.ToString("yyyyMMdd:HHmmss") + username);
                }
                Application.Exit();
            }
        }



        private Boolean Verificar_BD(DataSet ds)
        {
            int registro = ds.Tables[0].Rows.Count;

            Boolean Sentencia = false;

            if (registro > 0)
            {
                Sentencia = true;
            }

            return Sentencia;
        }



        private void SEGON_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}