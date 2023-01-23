using MySql.Data.MySqlClient;
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
    public partial class DeleteForm : Form
    {
        DataTable table1;
        List<TextBox> textBoxesSt;

        DataTable table2;
        List<TextBox> textBoxesKm;

        DataTable table3;
        List<TextBox> textBoxesIn;

        DataTable table4;
        List<TextBox> textBoxesNar;
        public DeleteForm()
        {
            InitializeComponent();

            textBoxesSt = new List<TextBox>();
            textBoxesSt.Add(textBox1);
            textBoxesSt.Add(textBox2);
            textBoxesSt.Add(textBox3);
            textBoxesSt.Add(textBox4);

            textBoxesKm = new List<TextBox>();
            textBoxesKm.Add(textBox5);
            textBoxesKm.Add(textBox6);
            textBoxesKm.Add(textBox7);

            textBoxesIn = new List<TextBox>();
            textBoxesIn.Add(textBox8);
            textBoxesIn.Add(textBox9);
            textBoxesIn.Add(textBox10);

            textBoxesNar = new List<TextBox>();
            textBoxesNar.Add(textBox11);
            textBoxesNar.Add(textBox12);
            textBoxesNar.Add(textBox13);

            DB db = new DB();
            table1 = new DataTable();
            table2 = new DataTable();
            table3 = new DataTable();
            table4 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter();
            MySqlDataAdapter adapter4 = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `студенты`;", db.GetConnection());
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `комнаты`;", db.GetConnection());
            MySqlCommand command3 = new MySqlCommand("SELECT * FROM `инвентарь`;", db.GetConnection());
            MySqlCommand command4 = new MySqlCommand("SELECT * FROM `нарушения`;", db.GetConnection());

            db.openConnection();

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "фамилия";
            comboBox1.SelectedIndex = -1;

            //

            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            comboBox2.DataSource = table2;
            comboBox2.DisplayMember = "idкомнаты";
            comboBox2.SelectedIndex = -1;

            //

            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);

            comboBox3.DataSource = table3;
            comboBox3.DisplayMember = "наименование";
            comboBox3.SelectedIndex = -1;

            //

            adapter4.SelectCommand = command4;
            adapter4.Fill(table4);

            comboBox4.DataSource = table4;
            comboBox4.DisplayMember = "наименование";
            comboBox4.SelectedIndex = -1;

            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForAdmin forAdmin = new ForAdmin();
            forAdmin.Show();
            this.Hide();
            forAdmin.Location = this.Location;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowNum = comboBox1.SelectedIndex;
            int i = 0;
            foreach (TextBox box in textBoxesSt)
                if (rowNum >= 0)
                    box.Text = table1.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowNum = comboBox2.SelectedIndex;
            int i = 0;
            foreach (TextBox box in textBoxesKm)
                if (rowNum >= 0)
                    box.Text = table2.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowNum = comboBox3.SelectedIndex;
            int i = 0;
            foreach (TextBox box in textBoxesIn)
                if (rowNum >= 0)
                    box.Text = table3.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowNum = comboBox4.SelectedIndex;
            int i = 0;
            foreach (TextBox box in textBoxesNar)
                if (rowNum >= 0)
                    box.Text = table4.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";
        }
    }
}
