using System;
using System.Configuration;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;

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


        private void Dades_Load(object sender, EventArgs e)
        {
            GetMacAddress();
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
        private void delete_bttn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void check_bttn_Click(object sender, EventArgs e)
        {
            string query = "select * from TrustedDevices where Hostname = '" + GetHostName() + "' and MAC = '" + GetMacAddress() + "'";

            BaseDatosDUAL.DataBase BD = new BaseDatosDUAL.DataBase();

            DataSet dades = BD.PortarPerConsulta(query);

            int registres = dades.Tables[0].Rows.Count;

            if (registres >0)
            {
                MessageBox.Show("Ese dispositivo ya existe.");
            }
            else
            {
                MessageBox.Show("Ese dispositivo no se encuentra dentro de la base de datos. Haga clic en 'Register' para agregarlo.");
                register_bttn.BackColor = Color.White;
                register_bttn.ForeColor = Color.Red;
                register_bttn.Enabled = true;
            }

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
