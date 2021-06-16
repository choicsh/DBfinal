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
    public partial class Form4 : Form
    { 
        public Form4()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=dbfinal;Uid=root;Pwd=tjdgus9898!;");
            connection.Open();

            string strSql = "Select * from reservation;";
            MySqlCommand cmd = new MySqlCommand(strSql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            connection.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=dbfinal;Uid=root;Pwd=tjdgus9898!;");
            connection.Open();
            string strSql = "UPDATE reservation set start='"+textBox2.Text+"', end='"+textBox3.Text+"'"+"where rs_no='"+textBox1.Text+"' ;";
            MySqlCommand cmd = new MySqlCommand(strSql, connection);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("수정이 완료되었습니다.");
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("수정에 실패하였습니다.");
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
