using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;


namespace timer
{
    public partial class Dades_equip : Form
    {
        public Dades_equip()
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

        private void button1_Click(object sender, EventArgs e)
        {

            query = "select * from TrustedDevices where MAC = '" + GetMacAddress() + "'";

            BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            registres = dades.Tables[0].Rows.Count;

            if (registres > 0)
            {
                MessageBox.Show("Ese dispositivo ya existe. Pulse 'Delete' para borrar el registro.");
                habilitar_bttn(delete_bttn);
            }
            else
            {
                MessageBox.Show("Ese dispositivo no se encuentra dentro de la base de datos. Haga clic en 'Save' para agregarlo.");
                habilitar_bttn(save_bttn);

            }
        }

        private void Dades_Load(object sender, EventArgs e)
        {
            //GetMacAddress();
            //GetHostName();
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

        private void delete_Click(object sender, EventArgs e)
        {
            //textBox1.Clear();
            //textBox2.Clear();

            query = "DELETE FROM TrustedDevices where MAC = ('" + GetMacAddress() + "') AND HostName = ('" + GetHostName() + "'); ";

            BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            MessageBox.Show("Su dispositivo '" + GetHostName() + "' se ha eliminado del registro correctamente.");

            deshabilitar_bttn(delete_bttn);

        }

        private void save_bttn_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO TrustedDevices values ('" + GetMacAddress() + "', '" + GetHostName() + "'); ";

            BD = new BaseDatosDUAL.DataBase();

            dades = BD.PortarPerConsulta(query);

            MessageBox.Show("Su dispositivo '" + GetHostName() + "' se ha registrado correctamente.");

            deshabilitar_bttn(save_bttn);

        }

        private void Dades_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

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
