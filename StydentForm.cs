using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public partial class StydentForm : Form
    {
        DataTable table;
        List<TextBox> textBoxes;
        public StydentForm()
        {
            InitializeComponent();

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(textBox5);
            textBoxes.Add(textBox6);
            textBoxes.Add(textBox7);

            DB db = new DB();
            table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `студенты`;", db.GetConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "имя";
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
            Console.WriteLine(rowNum);
            int i = 0;
            foreach (TextBox box in textBoxes)
                if (rowNum >= 0)
                    box.Text = table.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";
        }
    }
}
