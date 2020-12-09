using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net.Configuration;

namespace timer
{
    public partial class Dades_usuari : Form
    {
        public Dades_usuari()
        {
            InitializeComponent();
            string macAdd;
            macAdd = GetMacAddress();
            textBox1.Text = macAdd;
            string hostName;
            hostName = GetHostName();
            textBox2.Text = hostName;
        }

        string query;
        int registres;
        DataSet dades;
        BaseDatosDUAL.DataBase BD = new BaseDatosDUAL.DataBase();
        string cb_username;



        private void Dades_usuari_Load(object sender, EventArgs e)
        {
            GetMacAddress();
            ComprobarTrustedDevice();

            if (ComprobarTrustedDevice())
            {
                this.Show();

                query = "Select * from Users";

                //BD = new BaseDatosDUAL.DataBase();

                dades = BD.PortarPerConsulta(query);

                foreach (DataRow dr in dades.Tables[0].Rows)
                {
                    ComboBox_UserName.Items.Add(dr["codeuser"]);
                    //MessageBox.Show(dr["codeuser"] + " - " + dr[0]);
                }

            }
            else
            {
                MessageBox.Show("Su dispositivo no és de confianza. Esta pantalla se cerrará.");
                this.Close();
            }
        }


        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }

        public string GetHostName()
        {
            string HostName = Dns.GetHostName();
            return HostName;
        }


        public Boolean ComprobarTrustedDevice()
        {
            Boolean TrustedDevice = false;

            query = "select * from TrustedDevices where MAC = '" + GetMacAddress() + "' AND HostName = '" + GetHostName() + "';";

            //BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            registres = dades.Tables[0].Rows.Count;

            if (registres > 0)
            {
                TrustedDevice = true;
            }

            return TrustedDevice;
        }


        private void check_bttn_Click(object sender, EventArgs e)
        {
            cb_username = ComboBox_UserName.Text;

            query = "select * from MessiUsers where idDevice = (select idDevice from TrustedDevices where HostName = '" + GetHostName() + "') and idUser = (select idUser from Users where codeUser = '" + cb_username + "');";

            //BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            registres = dades.Tables[0].Rows.Count;



            if (registres > 0)
            {
                MessageBox.Show("Ya se encuntra vinculado con MESSI. Pulse 'Delete' para eliminar su vínculo");
                habilitar_bttn(delete_bttn);
            }
            else
            {
                MessageBox.Show("No se encuentra vinculado en nuestro sistema. Seleccione 'Register' para autentificarse dentro de MESSI");
                habilitar_bttn(register_bttn);
            }

        }


        private void register_bttn_Click(object sender, EventArgs e)
        {
            string key = "TrustedUser";
            cb_username = ComboBox_UserName.Text;
            string value = cb_username;

            // Add an Application Setting.
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var settings = config.AppSettings.Settings;

            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }

            //config.AppSettings.Settings.Add(key, value);

            // Save the changes in App.config file.

            config.Save(ConfigurationSaveMode.Modified);



            query = "insert into MessiUsers select idDevice, idUser from TrustedDevices, Users where Users.codeUser = '" + cb_username + "' and TrustedDevices.HostName = '" + GetHostName() + "';";

            dades = BD.PortarPerConsulta(query);






            //Correo

            EnviarCorreo();




            //






            MessageBox.Show("Se acaba de vincular en MESSI.");
            deshabilitar_bttn(register_bttn);

            //MessageBox.Show("ERROR: Se ha producido un error a la hora de registrarse en Messi. Porfavor, revise bien su información.");

        }




        private void delete_bttn_Click(object sender, EventArgs e)
        {
            query = "delete from MessiUsers select TrustedDevices.idDevice, Users.idUser from TrustedDevices, Users, MessiUsers where(Users.codeUser = '" + cb_username + "' and TrustedDevices.HostName = '" + GetHostName() + "') and(MessiUsers.idDevice = Users.idUser and MessiUsers.idDevice = TrustedDevices.HostName);";

            dades = BD.PortarPerConsulta(query);

            registres = dades.Tables[0].Rows.Count;

            MessageBox.Show("Se acaba de desvincular de MESSI.");
            deshabilitar_bttn(delete_bttn);

            //MessageBox.Show("ERROR: Se ha producido un error a la hora de borrar su registro en Messi. Porfavor, revise bien su información.");

        }






        //Correo
        //https://aspnetcoremaster.com/.net/smtp/smptclient/2019/03/11/enviar-un-correo-con-csharp-gmail-winforms.html
        //https://stackoverflow.com/questions/32260/sending-email-in-net-through-gmail

        private void EnviarCorreo()
        {

            query = "select * from Users where codeUser = '" + cb_username + "';";
            dades = BD.PortarPerConsulta(query);

            string cuenta_correo = dades.Tables[0].Rows[0]["descUser"].ToString();

            //Para comprobar de que la variable recibe el correo correctamente:
                //MessageBox.Show(cuenta_correo);


            string contraseña_correo = dades.Tables[0].Rows[0]["password"].ToString();


            var fromAddress = new MailAddress("messi.system.dc@gmail.com", "MESSI_DarkCore");
            var toAddress = new MailAddress("messi.system.dc@gmail.com", "messi.system.dc@gmail.com");
            string fromPassword = contraseña_correo;
            const string subject = "M.E.S.S.I System";
            const string body = "Esto es un correo de prueba.";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }




        //private void EmailSender()
        //{
        //    SmtpSection smpt = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
        //    SmtpClient smtpclient = new SmtpClient();
        //    string origen_correo = smpt.From;
        //    string destinatario_correo = "";
        //    EnviarEmail(origen_correo, smtpclient, destinatario_correo);
        //}

        //private Task EnviarEmail(string origen_correo, SmtpClient smtpclient, string destinatario_correo)
        //{
        //    string subjectEmail = "M.E.S.S.I DARK CORE - Registro al sistema";
        //    string bodyEmail = "Bienvenido a Dark Core! Te agradecemos que hayas decidido apoyar al lado oscuro. Tu usuario '" + cb_username + "' se ha registrado correctamente en nuestro sistema.";

        //    var correo = new MailMessage(from: origen_correo, to: destinatario_correo, subject: subjectEmail, body: bodyEmail);
        //    correo.IsBodyHtml = true;

        //    return smtpclient.SendMailAsync(correo);
        //}

        //


        private void habilitar_bttn(Button boton)
        {
            boton.BackColor = Color.White;
            boton.ForeColor = Color.Red;
            boton.Enabled = true;
        }

        private void deshabilitar_bttn(Button boton)
        {
            boton.BackColor = Color.LightGray;
            boton.ForeColor = Color.DimGray;
            boton.Enabled = false;
        }
    }
}
