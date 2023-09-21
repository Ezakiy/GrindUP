using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindUp_miniPt
{
    public partial class Form5 : Form
    {


        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Globais.Funcao == "Treinador")
            {
                button1.Enabled = false;

            }
            if (Globais.Funcao == "secretaria")
            {
                button2.Enabled = false;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

      

                Form9 f9 = new Form9();
                f9.Show();

            this.Close();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
