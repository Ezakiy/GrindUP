using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using GrindUp_miniPt;

namespace GrindUp_miniPt
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            object ob = BLL.Funcionário.queryLoginFuncionário(textBox1.Text, textBox2.Text);     
          
            if  (ob != null) 
            {          
                bool admin1 = Convert.ToBoolean(ob);
                if (admin1 == true)
                {
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }
                else
                {
                    Form5 f5 = new Form5();
                    f5.Show();
                    this.Hide();
                }
                    
               
            }
            else
                MessageBox.Show("Erro Login");

           
        }

        static string Hash(string input)

        {

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = BLL.Funcionário.queryLoginFuncionário(textBox3.Text, textBox4.Text);

            if (dt.Rows.Count > 0 )
            {
                bool admin1 = Convert.ToBoolean(dt.Rows[0][4]);
                Globais.Funcao = dt.Rows[0][2].ToString();
                if (admin1 == true)
                {
                    Form4 f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }
                else
                {
                    Form5 f5 = new Form5();
                    f5.Show();
                    this.Hide();
                }


            }
            else
                MessageBox.Show("Erro Login");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = BLL.Clientes.queryLogin(textBox1.Text, textBox2.Text);


            if (dt.Rows.Count > 0)
            {
                
                Globais.id = (int)dt.Rows[0]["id"];
                Form6 f2 = new Form6();
                f2.Show();


            }
            else
               
            MessageBox.Show("Erro Login");

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }
    }
}
