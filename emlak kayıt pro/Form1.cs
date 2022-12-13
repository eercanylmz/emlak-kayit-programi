using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace emlak_kayıt_pro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1 .Text=="ercnylmz" && textBox2.Text == "kullanıcı")
            {
                Form2 RealEstateRegistration = new Form2();
                RealEstateRegistration.Show();
                this.Hide();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 FRM2 = new Form2();
            FRM2.Show();
            this.Hide();
        }
    }
}
