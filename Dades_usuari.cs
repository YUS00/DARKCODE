using System;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

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
        BaseDatosDUAL.DataBase BD;

        private void Dades_usuari_Load(object sender, EventArgs e)
        {
            GetMacAddress();
            ComprobarTrustedDevice();

            if (ComprobarTrustedDevice())
            {
                this.Show();

                query = "Select * from Users";

                BD = new BaseDatosDUAL.DataBase();

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

            BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            registres = dades.Tables[0].Rows.Count;

            if (registres > 0)
            {
                TrustedDevice = true; 
            }

            return TrustedDevice;
        }



        private void delete_bttn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void check_bttn_Click(object sender, EventArgs e)
        {

            query = "select * from MessiUsers, TrustedDevices, Users where MessiUsers.idDevice = TrustedDevices.idDevice and MessiUsers.idUser = Users.idUser; ";

            BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            //Falta hacer el if por "registre", y añadir las condiciones

        }

        private void register_bttn_Click(object sender, EventArgs e)
        {
            string cb_username = ComboBox_UserName.Text;
            string key = "TrustedUser";
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

        }


   }
}
