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

namespace Sql_Derleyicisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-3A37CLQH\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu;
            sorgu = richTextBox1.Text;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorgunuzu Kontorl Edin!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = richTextBox1.Text;
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Ders", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorgunuzu Kontrol Ediniz!!!!");
            }
        }
    }
}
