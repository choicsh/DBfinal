using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace DBfinal
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=dbfinal;Uid=root;Pwd=tjdgus9898!;");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("빈 정보가 있습니다.");
            }
            else
            {
                string insertQuery = "INSERT INTO customers (c_id,c_password,c_name,c_phone,c_address)" + "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("회원가입이 완료되었습니다.");
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("회원가입에 실패하였습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                connection.Close();
            }
       
        }
    }
}
