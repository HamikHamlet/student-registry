using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\Documents\baza.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand com = new SqlCommand();
        SqlDataReader read;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                
                MessageBox.Show("Խնդրում ենք լրացնել դաշտերը");
            }
            else
            {


                com.Connection = con;
                con.Open();

                com.CommandText = ("Select * from Table1 where id='" + textBox1.Text + "' ");
                read = com.ExecuteReader();

                if (read.Read())
                {
                    MessageBox.Show("Կա նման ID");
                    con.Close();
                }
                
                

                else
                {
                    con.Close();
                    con.Open();
                com.Connection = con;
              
               
                    
                    com.CommandText = ("insert into Table1 (id,anun,azg,ser,tiv) values ('" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + comboBox1.SelectedItem + "','" + dateTimePicker1.Value.ToShortDateString() + "')");
                    com.ExecuteNonQuery();
                    con.Close();
                    
                    MessageBox.Show("Բազան հաջողւթյամբ լցվեց");

                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
          
           
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = ("Select * from Table1 where id='"+textBox1.Text+"' ");
            read = com.ExecuteReader();

            if (read.Read())
            {
                textBox1.Text = read["id"].ToString().Trim();
                textBox2.Text = read["anun"].ToString().Trim();
                textBox3.Text = read["azg"].ToString().Trim();
                comboBox1.Text = read["ser"].ToString().Trim();
                dateTimePicker1.Text = read["tiv"].ToString().Trim();

            }
            else
            {
                MessageBox.Show("Չկա նման ID");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {

                MessageBox.Show("Խնդրում ենք լրացնել դաշտերը");
            }
            else
            {
                com.Connection = con;
                con.Open();
                com.CommandText = ("Update Table1 Set anun=N'" + textBox2.Text + "', azg=N'" + textBox3.Text + "',ser=N'" + comboBox1.SelectedItem + "',tiv='" + dateTimePicker1.Value.ToShortDateString() + "' where id='" + textBox1.Text + "'");
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ձեր տվյալները հաջողությամբ թարմացվեցին");
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Խնդրում ենք լրացնել ID դաշտը");
            }
            else
            {
                com.Connection = con;
                con.Open();
                com.CommandText = ("delete from Table1 where id='" + textBox1.Text + "'");
                com.ExecuteNonQuery();
                con.Close();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
