using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Fabrika
{
    public partial class Skupki : Form
    {
        string a;
        public Skupki()
        {
            InitializeComponent();
        }

        private void Skupki_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Fabrika; Persist Security info = True; " +
                "User ID = sa; Password = D6747960f ");
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select id_skupka as 'Номер скупки на предприятии',NumbSkupka as 'Номер скупки'" +
                ", TimeSkupka as 'Время скупки', DateSkupka as 'Дата скупки' from Skupka", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Skupka");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (maskedTextBox1.Text != "") && (textBox5.Text != ""))
            {
                SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Fabrika; " +
                    "Persist Security info = True; User ID = sa; Password = D6747960f ");
                con.Open();
                SqlCommand StrPrc1 = new SqlCommand("Skupka_update", con); // Обращение к хранимой процедуре обновления
                StrPrc1.CommandType = CommandType.StoredProcedure;
                StrPrc1.Parameters.AddWithValue("@id_Skupka", textBox1.Text);
                StrPrc1.Parameters.AddWithValue("@NumbSkupka", textBox2.Text);
                StrPrc1.Parameters.AddWithValue("@TimeSkupka", maskedTextBox1.Text);
                StrPrc1.Parameters.AddWithValue("@DateSkupka", textBox5.Text);
                StrPrc1.Parameters.AddWithValue("@NedostatokDetail_id", 1);
                StrPrc1.Parameters.AddWithValue("@InfoPredpr_id", 1);
                StrPrc1.ExecuteNonQuery();
                MessageBox.Show("Информация изменена");
                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";
                textBox5.Text = "";
                SqlDataAdapter da = new SqlDataAdapter("select id_skupka as 'Номер скупки на предприятии', NumbSkupka as 'Номер скупки', TimeSkupka as 'Время скупки', DateSkupka as 'Дата скупки' from Skupka", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Skupka");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                MessageBox.Show("Всё пусто");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Fabrika; Persist Security info = True; User ID = sa; Password = D6747960f ");
                con.Open();
                SqlCommand StrPrc = new SqlCommand("[dbo].Skupka_delete", con); // Обращение к хранимой процедуре удаления
                StrPrc.CommandType = CommandType.StoredProcedure;
                StrPrc.Parameters.AddWithValue("@id_Skupka", Convert.ToInt32(textBox1.Text));
                StrPrc.ExecuteNonQuery();
                MessageBox.Show("Скупка удалена!");
                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";
                textBox5.Text = "";
                SqlDataAdapter da = new SqlDataAdapter("select id_skupka as 'Номер скупки на предприятии', NumbSkupka as 'Номер скупки', TimeSkupka as 'Время скупки', DateSkupka as 'Дата скупки' from Skupka", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Skupka");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                MessageBox.Show("Выберите скупку");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && (maskedTextBox1.Text != "") && (textBox5.Text != ""))
            {
                SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Fabrika; Persist Security info = True; User ID = sa; Password = D6747960f ");
                con.Open();
                SqlCommand k = new SqlCommand("select COUNT([id_Skupka]) + 1 from Skupka", con);
                a = k.ExecuteScalar().ToString();
                SqlCommand StrPrc1 = new SqlCommand("Skupka_add", con); // Обращение к хранимой процедуре обновления
                StrPrc1.CommandType = CommandType.StoredProcedure;
                StrPrc1.Parameters.AddWithValue("@NumbSkupka", textBox2.Text);
                StrPrc1.Parameters.AddWithValue("@TimeSkupka", maskedTextBox1.Text);
                StrPrc1.Parameters.AddWithValue("@DateSkupka", textBox5.Text);
                StrPrc1.Parameters.AddWithValue("@NedostatokDetail_id", 1);
                StrPrc1.Parameters.AddWithValue("@InfoPredpr_id", 1);
                StrPrc1.ExecuteNonQuery();
                MessageBox.Show("Информация добавлена");
                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";
                textBox5.Text = "";
                SqlDataAdapter da = new SqlDataAdapter("select id_skupka as 'Номер скупки на предприятии', NumbSkupka as 'Номер скупки', TimeSkupka as 'Время скупки', DateSkupka as 'Дата скупки' from Skupka", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Skupka");
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                MessageBox.Show("Всё пусто");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox5.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Visible = false;
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    if (dataGridView1[c, i].Value.ToString() == textBox3.Text)
                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
