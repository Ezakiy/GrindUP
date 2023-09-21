using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.IO;

namespace GrindUp_miniPt
{
    public partial class Form2 : Form
    {
        int id = 0;
        byte[] img;
        bool Inativo = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Clientes.Load();                   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            img = imgToByteArray(pictureBox2.Image);
            int x = BLL.Clientes.insertCliente(textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, img, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), comboBox2.Text, textBox8.Text, textBox2.Text, dateTimePicker1.Value, textBox10.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox2.ResetText();
            textBox8.Clear();
            textBox10.Clear();
            dataGridView1.DataSource = BLL.Clientes.Load();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                textBox1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Telefone"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Morada"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Email"].Value);
                // pictureBox2.Image = Convert.ToByte(dataGridView1.Rows[e.RowIndex].Cells["Foto"].Value);
                byte[] bytes = (byte[])dataGridView1.Rows[e.RowIndex].Cells["Foto"].Value;
                textBox6.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Peso"].Value);
                textBox7.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Altura"].Value);
                comboBox2.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Genero"].Value);
                textBox8.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Senha"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["NIF"].Value);
                textBox10.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["mensalidade"].Value);
               // textBox11.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);


            }

        }
        public Image byteArrayToImage(byte[] byteArrayIn)

        {

            using (MemoryStream mStream = new MemoryStream(byteArrayIn))

            {

                return Image.FromStream(mStream);


            }

        }
        // imagem para array de bytes
        public byte[] imgToByteArray(Image img)

        {

            using (MemoryStream mStream = new MemoryStream())

            {

                img.Save(mStream, img.RawFormat);

                return mStream.ToArray();

               

            }


        }

      

        private void button3_Click(object sender, EventArgs e)
        {

           
            int x = BLL.Clientes.updateClienteInativo(id, Inativo);
            checkBox1.Refresh();       
            dataGridView1.DataSource = BLL.Clientes.Load();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = openFileDialog1.FileName;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Clientes.queryCliente_Like(textBox3.Text);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           bool Inativo = true; Inativo = checkBox1.Checked;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = BLL.Clientes.updateCliente(id, textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToString(comboBox2.SelectedItem), textBox8.Text, Convert.ToInt32(textBox2.Text), dateTimePicker1.Value, textBox10.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox2.ResetText();
            textBox10.Clear();
            dataGridView1.DataSource = BLL.Clientes.Load();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int y = BLL.inscricao.deleteInscricao(id);
            int x = BLL.Clientes.deleteCliente(id);
            textBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox2.ResetText();
            textBox10.Clear();
            textBox11.Clear();
            dataGridView1.DataSource = BLL.Clientes.Load();
        }
    }
}
