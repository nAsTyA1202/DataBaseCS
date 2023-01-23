using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        //СТУДЕНТЫ

        private void button2_Click(object sender, EventArgs e)
        {
            String pattName = @"^([А-ЯЁ]{1}[а-яё]+)$";
            String pattNum = @"^([1-9]{1}[0-9]{0,2})$";
            String pattData = @"^[0-9]{4}-(0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])$";
            Regex regName = new Regex(pattName);
            Regex regNum = new Regex(pattNum);
            Regex regData = new Regex(pattData);

            String newName = textBox2.Text;
            String newSname = textBox3.Text;
            String komnata = textBox4.Text;
            String pol = textBox5.Text;
            String group = textBox6.Text;
            String data = textBox7.Text;

            if (newName == "" || newSname == "" || komnata == "" || pol == "" || group == "" || data == "")
            {
                MessageBox.Show("Заполните ВСЕ поля");
                return;
            }


            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `студенты` (`имя`, `фамилия`, `idкомнаты`, `пол`, `группа`, `дата заселения`) VALUES (@n, @f, @k, @p, @g, @d)", db.GetConnection());
            command.Parameters.Add("@n", MySqlDbType.VarChar).Value = newName;
            command.Parameters.Add("@f", MySqlDbType.VarChar).Value = newSname;
            command.Parameters.Add("@k", MySqlDbType.VarChar).Value = komnata;
            command.Parameters.Add("@p", MySqlDbType.VarChar).Value = pol;
            command.Parameters.Add("@g", MySqlDbType.VarChar).Value = group;
            command.Parameters.Add("@d", MySqlDbType.VarChar).Value = data;

            db.openConnection();

            try
            {
                if (regName.IsMatch(textBox2.Text) && regName.IsMatch(textBox3.Text) && regNum.IsMatch(textBox4.Text) && regData.IsMatch(textBox7.Text))
                {
                    command.ExecuteScalar();
                    MessageBox.Show("Студент успешно добавлен");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                else
                    MessageBox.Show("Неверно заполнены поля");
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                if (err.Code == 0)
                {
                    Console.WriteLine("Incorrect Date");
                };
            }           

            db.closeConnection();
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
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                this.textBox4.BackColor = System.Drawing.Color.Red;
            else
                this.textBox4.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                this.textBox5.BackColor = System.Drawing.Color.Red;
            else
                this.textBox5.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                this.textBox6.BackColor = System.Drawing.Color.Red;
            else
                this.textBox6.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
                this.textBox7.BackColor = System.Drawing.Color.Red;
            else
                this.textBox7.BackColor = System.Drawing.SystemColors.Window;
        }

        //КОМНАТЫ

        private void button3_Click(object sender, EventArgs e)
        {
            String pattName = @"^([А-ЯЁ]{1}[а-яё]+)$";
            String pattNum = @"^([1-9]{1}[0-9]{0,2})$";
            String pattData = @"^[0-9]{4}-(0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])$";
            Regex regName = new Regex(pattName);
            Regex regNum = new Regex(pattNum);
            Regex regData = new Regex(pattData);

            String komnata = textBox9.Text;
            String colMest = textBox8.Text;
            String ploshad = textBox1.Text;

            if (komnata == "" || colMest == "" || ploshad == "")
            {
                MessageBox.Show("Заполните ВСЕ поля");
                return;
            }

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `комнаты` (`idкомнаты`, `кол-во мест`, `жилая площадь`) VALUES (@id, @col, @pl)", db.GetConnection());
            command.Parameters.Add("@pl", MySqlDbType.VarChar).Value = ploshad;
            command.Parameters.Add("@col", MySqlDbType.VarChar).Value = colMest;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = komnata;

            db.openConnection();
            try
            {
                if (regNum.IsMatch(textBox9.Text) && regNum.IsMatch(textBox8.Text))
                {
                    command.ExecuteScalar();
                    MessageBox.Show("Комната успешно добавлена");
                    textBox1.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                }
                else
                    MessageBox.Show("Неверно заполнены поля");
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                if (err.Code == 0)
                {
                    Console.WriteLine("Incorrect Date");
                }
            }
                          

            db.closeConnection();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                this.textBox1.BackColor = System.Drawing.Color.Red;
            else
                this.textBox1.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
                this.textBox9.BackColor = System.Drawing.Color.Red;
            else
                this.textBox9.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
                this.textBox8.BackColor = System.Drawing.Color.Red;
            else
                this.textBox8.BackColor = System.Drawing.SystemColors.Window;
        }

        //ИНВЕНТАРЬ

        private void button4_Click(object sender, EventArgs e)
        {
            String pattname = @"^([а-яё]+)$";
            String pattNum = @"^([1-9]{1}[0-9]{0,2})$";
            String pattData = @"^[0-9]{4}-(0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])$";
            Regex regName = new Regex(pattname);
            Regex regNum = new Regex(pattNum);
            Regex regData = new Regex(pattData);

            String name = textBox13.Text;
            String komnata = textBox12.Text;
            String colvo = textBox11.Text;
            String data = textBox10.Text;

            if (komnata == "" || name == "" || colvo == "" || data=="")
            {
                MessageBox.Show("Заполните ВСЕ поля");
                return;
            }

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `инвентарь` (`наименование`, `idкомнаты`, `кол-во на комнату`, `дата установки/выдачи`) VALUES (@n, @kom, @Col, @dt)", db.GetConnection());
            command.Parameters.Add("@n", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@kom", MySqlDbType.VarChar).Value = komnata;
            command.Parameters.Add("@Col", MySqlDbType.VarChar).Value = colvo;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = data;

            db.openConnection();

            try
            {
                if (regNum.IsMatch(textBox12.Text) && regName.IsMatch(textBox13.Text) && regNum.IsMatch(textBox11.Text) && regData.IsMatch(textBox10.Text))
                {
                    command.ExecuteScalar();
                    MessageBox.Show("Инвентарь успешно добавлен");
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                }
                else
                    MessageBox.Show("Неверно заполнены поля");
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                if (err.Code == 0)
                {
                    Console.WriteLine("Incorrect Date");
                }
            }            

            db.closeConnection();
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
                this.textBox11.BackColor = System.Drawing.Color.Red;
            else
                this.textBox11.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
                this.textBox10.BackColor = System.Drawing.Color.Red;
            else
                this.textBox10.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
                this.textBox12.BackColor = System.Drawing.Color.Red;
            else
                this.textBox12.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
                this.textBox13.BackColor = System.Drawing.Color.Red;
            else
                this.textBox13.BackColor = System.Drawing.SystemColors.Window;
        }

        //НАРУШЕНИЯ

        private void button5_Click(object sender, EventArgs e)
        {
            String pattname = @"^([а-яё]+)$";
            String pattNum = @"^([1-9]{1}[0-9]{0,2})$";
            String pattData = @"^[0-9]{4}-(0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])(\s)(([01][0-9]|2[0-3]):([012345][0-9]):([012345][0-9]))$";
            Regex regName = new Regex(pattname);
            Regex regNum = new Regex(pattNum);
            Regex regData = new Regex(pattData);

            String trabl = textBox17.Text;
            String datatr = textBox16.Text;
            String kom = textBox15.Text;
            String student = textBox14.Text;

            if (trabl == "" || datatr == "" || kom == "" || student == "")
            {
                MessageBox.Show("Заполните ВСЕ поля");
                return;
            }

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `нарушения` (`нарушение`, `дата происшествия`, `idкомнаты`, `idстудента`) VALUES (@nar, @dta, @km, @stud)", db.GetConnection());
            command.Parameters.Add("@nar", MySqlDbType.VarChar).Value = trabl;
            command.Parameters.Add("@dta", MySqlDbType.VarChar).Value = datatr;
            command.Parameters.Add("@km", MySqlDbType.VarChar).Value = kom;
            command.Parameters.Add("@stud", MySqlDbType.VarChar).Value = student;

            db.openConnection();

            try
            {
                if (regNum.IsMatch(textBox15.Text) && regNum.IsMatch(textBox14.Text) && regData.IsMatch(textBox16.Text))
                {
                    command.ExecuteScalar();
                    MessageBox.Show("Нарушение успешно добавлено");
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";
                }
                else
                    MessageBox.Show("Неверно заполнены поля");
            }
            catch (MySql.Data.MySqlClient.MySqlException err)
            {
                if (err.Code == 0)
                {
                    Console.WriteLine("Incorrect Date");
                }
            }     

            db.closeConnection();
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
                this.textBox14.BackColor = System.Drawing.Color.Red;
            else
                this.textBox14.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
                this.textBox15.BackColor = System.Drawing.Color.Red;
            else
                this.textBox15.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
                this.textBox16.BackColor = System.Drawing.Color.Red;
            else
                this.textBox16.BackColor = System.Drawing.SystemColors.Window;
        }
        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
                this.textBox17.BackColor = System.Drawing.Color.Red;
            else
                this.textBox17.BackColor = System.Drawing.SystemColors.Window;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ForAdmin forAdmin = new ForAdmin();
            forAdmin.Show();
            this.Hide();
            forAdmin.Location = this.Location;
        }
    }
}
