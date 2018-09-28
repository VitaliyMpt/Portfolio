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
    public partial class Avtoriz : Form
    {
        public Avtoriz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KYKYSKLAN\\FILEBD; initial catalog=Trawma; Persist Security info = True; User ID = sa; Password = D6747960f ");
            con.Open();

            SqlCommand sc = new SqlCommand("Select * from ProfileSotr where [LoginSotr] = '" + textBox1.Text + "' and [PassSotr] = '" + textBox2.Text + "'", con);
            SqlDataReader dr;
            dr = sc.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            dr.Close();

            if (count == 1)
            {
                Skupki skupki = new Skupki();
                skupki.Show();
                this.Close();
            }
                    else
                    {
                        MessageBox.Show("Неправильно введены данные");
                    }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Close();
        }
    }
}
