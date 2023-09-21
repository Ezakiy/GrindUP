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
    public partial class Form6 : Form
    {
        string id = "";
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lotacao = (int)BLL.Horario.queryLotacao(id);
            int inscricoes = (int)BLL.Horario.queryInscricoes(id);
           

            if (lotacao >= inscricoes)
            {
                int x = BLL.inscricao.insertInscrição(Globais.id, Convert.ToInt32(id));

                MessageBox.Show("Você foi registado na aula " + textBox4.Text);
            }
            else
            {
                MessageBox.Show("Não se pode registar mais nesta aula");
               
            }
          
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Horario.Load();
            dataGridView2.DataSource = BLL.Horario.LoadInscricoes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtgr = BLL.Horario.Load();
            try
            {
                 dtgr = BLL.Horario.queryHorario(Convert.ToInt32(dtgr.Rows[e.RowIndex]["id"]));
                if (dtgr.Rows.Count > 0)
                {
                    textBox1.Text = dtgr.Rows[0]["id"].ToString();
                    textBox2.Text = dtgr.Rows[0]["hora"].ToString();
                    textBox3.Text = dtgr.Rows[0]["dia_semana"].ToString();
                    textBox4.Text = dtgr.Rows[0]["aula"].ToString();
                    textBox5.Text = dtgr.Rows[0]["lotacao"].ToString();
                    id = dtgr.Rows[0]["id"].ToString();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("Erro " + ee);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point((ClientSize.Width / 2) - 400, (ClientSize.Height / 2) - 250);
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
