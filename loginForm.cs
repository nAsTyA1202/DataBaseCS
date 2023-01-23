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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();

            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, this.textBox1.Size.Height);

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
            String loginUser = textBox1.Text;
            String passUser = textBox2.Text;
            

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @lU AND `password` = @pU;", db.GetConnection());
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = passUser;
                 
            adapter.SelectCommand = command;
            adapter.Fill(table);

            object check = table.Rows[0][3];


            Console.WriteLine();
            if (check.Equals((SByte)1))
            {
                ForAdmin forAdmin = new ForAdmin();
                forAdmin.Show();
                this.Hide();
                forAdmin.Location = this.Location;
            }
            else
            {
                if (table.Rows.Count > 0)
                {
                    MainForm MainForm = new MainForm();
                    MainForm.Show();
                    this.Hide();
                    MainForm.Location = this.Location;
                }
                else
                    MessageBox.Show("Неверный логин или пароль");
            }

            
        }  
    }
}
