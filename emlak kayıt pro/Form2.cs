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

namespace emlak_kayıt_pro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=ERCANMONSTER\\ERCANSERVER;Initial Catalog=SİTELER;Integrated Security=True");
        private void SHOWDATA()
        {
            listView1.Items.Clear();
           connect.Open();
            SqlCommand command = new SqlCommand("Select * From daire", connect);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                ListViewItem ADD = new ListViewItem();
                ADD.Text = read["ıd"].ToString();
                ADD.SubItems.Add(read["sıte"].ToString());
                ADD.SubItems.Add(read["RentedForSale"].ToString());
                ADD.SubItems.Add(read["NumberOfRoom"].ToString());
                ADD.SubItems.Add(read["SquareMeters"].ToString());
                ADD.SubItems.Add(read["Price"].ToString());
                ADD.SubItems.Add(read["Block"].ToString());
                ADD.SubItems.Add(read["Number"].ToString());
                ADD.SubItems.Add(read["NameSurname"].ToString());
                ADD.SubItems.Add(read["Telephone"].ToString());
                ADD.SubItems.Add(read["Notes"].ToString());

                listView1.Items.Add(ADD);
            }
            connect.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "LILY SITE")
            {
                btnzambak.BackColor = Color.Blue;
            }
            if (comboBox1.Text == "DAISY SITE")
            {
                btnpapatya.BackColor = Color.Red;
            }
            if (comboBox1.Text == "ROSE SITE")
            {
                btngül.BackColor = Color.Blue;
            }
            if (comboBox1.Text == "VIENEKSE SITE")
            {
                btnmenekşe.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SHOWDATA();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("insert into daire (ıd,sıte,RentedForSale,NumberOfRoom,SquareMeters,Price,Block,Number,NameSurname,Telephone,Notes) values ('" + textBox6.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
            SHOWDATA();
        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("Delete from daire where ıd= (" + id + ")", connect);
            command.ExecuteNonQuery();
            connect.Close();
            SHOWDATA();
            
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox6.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = (listView1.SelectedItems[0].SubItems[1].Text);
            comboBox2.Text = (listView1.SelectedItems[0].SubItems[2].Text);
            comboBox3.Text = (listView1.SelectedItems[0].SubItems[3].Text);
            textBox1.Text = (listView1.SelectedItems[0].SubItems[4].Text);
            textBox2.Text = (listView1.SelectedItems[0].SubItems[5].Text);
            comboBox4.Text = (listView1.SelectedItems[0].SubItems[6].Text);
            comboBox5.Text = (listView1.SelectedItems[0].SubItems[7].Text);
            textBox5.Text = (listView1.SelectedItems[0].SubItems[8].Text);
            textBox3.Text = (listView1.SelectedItems[0].SubItems[9].Text);
            textBox4.Text = (listView1.SelectedItems[0].SubItems[10].Text);
          connect.Close();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand ("update daire set ıd='" + textBox6.Text.ToString() + "',sıte='" + comboBox1.Text.ToString() + "',RentedForSale='" + comboBox2.Text.ToString() + "',NumberOfRoom='" + comboBox3.Text.ToString() + "',SquareMeters='" + textBox1.Text.ToString() + "',Price='" + textBox2.Text.ToString() + "',Block='" + comboBox4.Text.ToString() + "',Number='" + comboBox5.Text.ToString() + "',NameSurname='" + textBox5.Text.ToString() + "',Telephone='" + textBox3.Text.ToString() + "',Notes='" + textBox4.Text.ToString() + "'where ıd=" + id +"",connect);
            command.ExecuteNonQuery();
            connect.Close();
            SHOWDATA();

        }
    }
}
