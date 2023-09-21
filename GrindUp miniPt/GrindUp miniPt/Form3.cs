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
    public partial class Form3 : Form
    {
        int IdFunc = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Funcionário.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Admin")
            {
                int x = BLL.Funcionário.insertFuncionário(textBox1.Text, Convert.ToString(comboBox1.SelectedItem), textBox2.Text, true );
            }
            else
            {
  int x = BLL.Funcionário.insertFuncionário(textBox1.Text, Convert.ToString(comboBox1.SelectedItem), textBox2.Text, false );
            }
            
          
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Items.Clear();
            dataGridView1.DataSource = BLL.Funcionário.Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdFunc = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdFunc"].Value);
                textBox1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Senha"].Value);
                comboBox1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Funções"].Value);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = BLL.Funcionário.deleteFuncionário(IdFunc);
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Refresh();

            dataGridView1.DataSource = BLL.Funcionário.Load();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point((ClientSize.Width / 2) - 400, (ClientSize.Height / 2) - 250);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
