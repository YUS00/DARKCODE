using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace timer
{
    public partial class Coordenadas : Form
    {
        public Coordenadas()
        {
            InitializeComponent();
        }

        Dictionary<String, String> Diccionario1;
        String[] id_codigo = new string[20];

        string query;
        int registres;
        DataSet dades;
        BaseDatosDUAL.DataBase BD;

        public string Obtener_numero()
        {
            int numero;
            String numero_cadena;
            Random r = new Random();

            numero = r.Next(0, 9999);
            numero_cadena = numero.ToString();

            if (numero_cadena.Length == 1)
            {
                numero_cadena = "000" + numero_cadena;
            }

            else if (numero_cadena.Length == 2)
            {
                numero_cadena = "00" + numero_cadena;
            }

            else if (numero_cadena.Length == 3)
            {
                numero_cadena = "0" + numero_cadena;
            }

            return numero_cadena;
        }
        private void Coordenadas_Load_1(object sender, EventArgs e)
        {
            Diccionario1 = new Dictionary<String, String>();
            String letra;
            String codigo;

            char[] char_codigo_letra = "ABCD".ToCharArray();
            char[] char_codigo_numero = "12345".ToCharArray();

            int acumulador_letra = 0;
            int acumulador_codigo = 0;

            BD = new BaseDatosDUAL.DataBase();
            query = "Delete From AdminCoordinates;";
            dades = BD.PortarPerConsulta(query);

            for (int i = 0; i < 4; i++)
            {
                for (int o = 0; o < 5; o++)
                {
                    id_codigo[acumulador_codigo] = char_codigo_letra[acumulador_letra].ToString() + char_codigo_numero[o].ToString();
                    acumulador_codigo++;
                }
                acumulador_letra++;
            }

            for (int i = 0; i < 20; i++)
            {
                String dc_valor;
                dc_valor = Obtener_numero();


                while (Diccionario1.ContainsValue(dc_valor) == true)
                {
                    dc_valor = Obtener_numero();
                }

                Diccionario1.Add(id_codigo[i], dc_valor);


                query = "INSERT INTO AdminCoordinates values('" + id_codigo[i] + "', '" + dc_valor + "'); ";

                dades = BD.PortarPerConsulta(query);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (KeyValuePair<string, string> entry in Diccionario1)
            {
                Label label_panel = new Label();
                label_panel.Font = new Font("Arial", 10);
                label_panel.Width = 110;
                label_panel.Height = 110;
                label_panel.TextAlign = ContentAlignment.MiddleCenter;
                label_panel.BackColor = Color.White;
                label_panel.Text = entry.Value;
                tableLayout.Controls.Add(label_panel);
            }
        }
    }
}


