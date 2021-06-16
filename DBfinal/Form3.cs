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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=dbfinal;Uid=root;Pwd=tjdgus9898!;");
            connection.Open();

            string strSql = "Select r_no, r_name, r_address, r_charge, r_available, person from rooms;";
            MySqlCommand cmd = new MySqlCommand(strSql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=dbfinal;Uid=root;pwd=tjdgus9898!;");
            connection.Open();
            string strSql = "INSERT INTO reservation(rs_no, start, end, person, r_no, c_id)"+"VALUES('"+textBox1.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox2.Text+"','"+textBox1.Text+ "','" + textBox3.Text + "');";
            MySqlCommand command = new MySqlCommand(strSql, connection);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("예약이 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show("예약에 실패하였습니다.");
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
