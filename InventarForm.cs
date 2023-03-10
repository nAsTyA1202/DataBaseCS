using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Mydatabase
{
    public partial class InventarForm : Form
    {
        DataTable table;
        List<TextBox> textBoxes;

        public InventarForm()
        {
            InitializeComponent();

            textBoxes = new List<TextBox>();
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);

            DB db = new DB();
            table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `инвентарь`;", db.GetConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "наименование";
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
            int i = 1;
            foreach (TextBox box in textBoxes)
                if (rowNum >= 0)
                    box.Text = table.Rows[rowNum][i++].ToString();
                else
                    box.Text = "";
        }
    }
}
