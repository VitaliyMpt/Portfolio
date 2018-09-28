using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabrika
{
    public partial class Zastavka : Form
    {
        int a;
        public Zastavka()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a = a + 1;
            if (a == 6)
            {
                Avtoriz avtoriz = new Avtoriz();
                avtoriz.Show();
                this.Hide();
            }
        }
    }
}
