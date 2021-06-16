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
namespace DBfinal
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text =="") 
            { 
                MessageBox.Show("아이디를 입력해주세요."); 
            }
            else if (textBox2.Text=="")
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
            }
            else if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                MessageBox.Show("관리자 로그인");
                Form4 showform4 = new Form4();
                showform4.ShowDialog();
            }
            else
            {
               
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Database=dbfinal;Uid=root;Pwd=tjdgus9898!;");
                    MySqlCommand command = new MySqlCommand("SELECT * FROM customers " + "where c_id= '" + textBox1.Text + "'and c_password='" + textBox2.Text + "';", connection);
                    MySqlDataReader myreader;
                    connection.Open();
                    myreader = command.ExecuteReader();
                    int count = 0;

                    while (myreader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("로그인 성공");
                        this.Visible = false;
                        Form3 showform3 = new Form3();
                        showform3.ShowDialog();
                      
                    }
                    else if (count < 1)
                    {
                        MessageBox.Show("아이디와 패스워드 불일치");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 showform2 = new Form2();
            showform2.ShowDialog();
        }
    }
}
