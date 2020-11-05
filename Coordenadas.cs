using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace timer
{
    public partial class Coordenadas : Form
    {
        public Coordenadas()
        {
            InitializeComponent();
        }

        private void Coordenadas_Load_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                int random;
                var rand = new Random();
                IDictionary<int, string> numberNames = new Dictionary<int, string>();
                numberNames.Add(random = rand.Next(00, 99), "");

                foreach (KeyValuePair<int, string> kvp in numberNames)
                    Console.WriteLine("{0}{1}", kvp.Key, kvp.Value);

            }
        }
    }
}


