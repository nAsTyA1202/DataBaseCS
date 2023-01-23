using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
            Form1.Location = this.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StydentForm StydentForm = new StydentForm();
            StydentForm.Show();
            this.Hide();
            StydentForm.Location = this.Location;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Komnata komnata = new Komnata();
            komnata.Show();
            this.Hide();
            komnata.Location = this.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TrablForm trablForm = new TrablForm();
            trablForm.Show();
            this.Hide();
            trablForm.Location = this.Location;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InventarForm inventarForm = new InventarForm();
            inventarForm.Show();
            this.Hide();
            inventarForm.Location = this.Location;
        }
    }
}
