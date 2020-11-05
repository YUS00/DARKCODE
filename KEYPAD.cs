using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace timer
{
    public partial class Keypad : Form
    {
        public Keypad()
        {
            InitializeComponent();
        }

        private void KEYPAD_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int numero = r.Next(1, 5);
            Random r2 = new Random();
            char[] chars = "ABCD".ToCharArray();
            int i = r2.Next(chars.Length);
            string cod_seguridad = (chars[i].ToString()) + (numero.ToString());
            label2.Text = cod_seguridad;
            AnadirBotones();
        }
        public void AnadirBotones()
        {

            var arraylist = new ArrayList();
            var cola = new Queue();
            var rand = new Random();
            int random;
            for (int i = 0; i < 10; i++)
            {
                arraylist.Add(i);
            }
            for (int j = 0; j < 10; j++)
            {
                random = rand.Next(arraylist.Count - 1);
                cola.Enqueue(arraylist[random]);
                arraylist.RemoveAt(random);
            }
            for (int i = 0; i < 10; i++)
            {
                Button boton_panel = new Button();
                boton_panel.Width = 80;
                boton_panel.Height = 80;
                boton_panel.BackColor = Color.White;
                boton_panel.Text = cola.Dequeue().ToString();
                tableLayoutPanel_botones.Controls.Add(boton_panel);
                boton_panel.Click += new EventHandler(tableLayoutPanel_botones_Click);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void tableLayoutPanel_botones_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4) textBox1.Text += ((Button)sender).Text;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("1234"))
            {
                Admin fm3 = new Admin();
                fm3.Show();
                this.Hide();
            }
            else if (!(textBox1.Text.Equals("1234")))
            {
                MessageBox.Show("ERROR");
                Application.Exit();
            }
        }
    }
}


