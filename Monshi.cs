using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayView
{
    public partial class Monshi : Form
    {
        public Monshi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Appointment f = new Appointment();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            this.Close();
        }
    }
}
