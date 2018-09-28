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
    public partial class Registr : Form
    {
        int id;
        public Registr()
        {
            InitializeComponent();
        }

        private void Registr_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Trawma; Persist Security info = True; User ID = sa; Password = D6747960f ");
            con.Open();
            SqlCommand k = new SqlCommand("select COUNT([id_Sotr]) + 1 from Sotr", con);
            textBox8.Text = k.ExecuteScalar().ToString();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Avtoriz avtoriz = new Avtoriz();
            avtoriz.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            id = Convert.ToInt32(textBox8.Text);
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox8.Text != "") && (textBox7.Text != "") && (comboBox1.Text != ""))
            {
                if (textBox5.Text == textBox7.Text)
                {
                    SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Fabrika; Persist Security info = True; User ID = sa; Password = D6747960f ");
                    con.Open();
                    SqlCommand StrPrc1 = new SqlCommand("Sotr_add", con);
                    StrPrc1.CommandType = CommandType.StoredProcedure;
                    StrPrc1.Parameters.AddWithValue("@F_Sotr", textBox1.Text);
                    StrPrc1.Parameters.AddWithValue("@I_Sotr", textBox2.Text);
                    StrPrc1.Parameters.AddWithValue("@O_Sotr", textBox3.Text);
                    StrPrc1.Parameters.AddWithValue("@DoljSotr", comboBox1.Text);
                    StrPrc1.ExecuteNonQuery();
                    SqlCommand StrPrc = new SqlCommand("ProfileSotr_add", con);
                    StrPrc.CommandType = CommandType.StoredProcedure;
                    StrPrc.Parameters.AddWithValue("@LoginSotr", textBox4.Text);
                    StrPrc.Parameters.AddWithValue("@PassKSotr", textBox5.Text);
                    StrPrc.Parameters.AddWithValue("@Sotr_id", id);
                    StrPrc.Parameters.AddWithValue("@PravaPolz_id", 1);
                    StrPrc.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Вы успешно зарегистрировали сотрудника");
                    Avtoriz avtoriz = new Avtoriz();
                    avtoriz.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
