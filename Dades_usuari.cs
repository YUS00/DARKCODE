using System;
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
        private string GetHostName()
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
            MessageBox.Show("SE HA GUARDADO");
        }

        private void register_bttn_Click(object sender, EventArgs e)
        {

        }
    }
}
