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
    public partial class Komnata : Form
    {
        DataTable table;
        List<TextBox> textBoxes;

        public Komnata()
        {
            InitializeComponent();

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);

            DB db = new DB();
            table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `комнаты`;", db.GetConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "idкомнаты";
            comboBox1.SelectedIndex = -1;
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.Show();
            this.Hide();
            MainForm.Location = this.Location;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowNum = comboBox1.SelectedIndex;
            int i = 0;
            foreach (TextBox box in textBoxes)
                if (rowNum >= 0)
                    box.Text = table.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";

            DB db = new DB();
            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            string query =
                "SELECT `студенты`.`имя`, `студенты`.`фамилия` " +
                    "FROM `студенты` " +
                    "WHERE `студенты`.`idкомнаты` = '{0}';";

            MySqlCommand command = new MySqlCommand(String.Format(query, textBox1.Text), db.GetConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table1);

            List<string> students = new List<string>();
            foreach (DataRow row in table1.Rows)
                students.Add(row[0].ToString() + " " + row[1].ToString());

            textBox4.Text = String.Join(", ", students);

            db.closeConnection();
        }
    }
}
