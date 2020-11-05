using System;
using System.Windows.Forms;

namespace timer
{
    public partial class Splash : Form
    {
        public Splash()

        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            circularProgressBar1.Value += 1;

            if (circularProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                timer1.Stop();
                Login fm2 = new Login();
                fm2.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            circularProgressBar1.Minimum = 1;
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.Value = 1;
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F2)
            {
                timer1.Stop();
                Keypad fm3 = new Keypad();
                fm3.Show();
                this.Hide();
            }
        }
    }
}
