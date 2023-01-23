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
    public partial class newLoginForm : Form
    {
        public newLoginForm()
        {
            InitializeComponent();

            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, this.textBox1.Size.Height);

            this.textBox3.AutoSize = false;
            this.textBox3.Size = new Size(this.textBox3.Size.Width, this.textBox1.Size.Height);
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
            String newlogin = textBox1.Text;
            String newpass = textBox2.Text;
            String trypass = textBox3.Text;

            if (newlogin == "" || newpass == "" || trypass == "")
            {
                MessageBox.Show("Заполните ВСЕ поля");
                return;
            }

            if (checkuser())
                return;

            if (newpass != trypass)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`) VALUES (@lU, @pU)", db.GetConnection());
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = newlogin;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = newpass;

            db.openConnection();
            if(command.ExecuteNonQuery() == 1)
                MessageBox.Show("YES");
            else
                MessageBox.Show("Неверный логин или пароль");


            db.closeConnection();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                this.textBox1.BackColor = System.Drawing.Color.Red;
            else
                this.textBox1.BackColor = System.Drawing.SystemColors.Window;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                this.textBox2.BackColor = System.Drawing.Color.Red;
            else
                this.textBox2.BackColor = System.Drawing.SystemColors.Window;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                this.textBox3.BackColor = System.Drawing.Color.Red;
            else
                this.textBox3.BackColor = System.Drawing.SystemColors.Window;
        }

        public Boolean checkuser()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @lU", db.GetConnection());
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Логин уже существует");
                return true;
            }
            else
                return false;
        }
    }
}
