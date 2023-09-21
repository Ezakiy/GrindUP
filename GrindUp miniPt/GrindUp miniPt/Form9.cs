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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrindUp_miniPt
{
    public partial class Form9 : Form
    {
        bool presente = false;
        public Form9()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["aula"].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                }

                catch(Exception ee) {
                    MessageBox.Show("Erro " + ee);
                }

            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Presenca.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = BLL.Presenca.insertPresenca(Convert.ToInt32(textBox1.Text), presente, dateTimePicker1.Value);
            MessageBox.Show("Presença marcada");
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            presente = true;
        }
    }
}
