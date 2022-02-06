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

namespace ProsesursuzProje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Server =localhost; Database=Pastane;Integrated Security=true ;");

        public void Goruntule(string sorgu)
        {
            SqlDataAdapter goruntule = new SqlDataAdapter(sorgu, baglanti);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Goruntule("select * from Satici");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Satici(SaticiAdSoyad,SaticiAdres,Saticiil,Saticiilce)values(@SaticiAdSoyad,@SaticiAdres,@Saticiil,@Saticiilce)", baglanti);
            cmd.Parameters.AddWithValue("@SaticiAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
            cmd.Parameters.AddWithValue("@Saticiil", textBox4.Text);
            cmd.Parameters.AddWithValue("@Saticiilce",textBox5.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Satici");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            

            SqlCommand komut = new SqlCommand("update Satici set SaticiAdSoyad='" + textBox2.Text.ToString()
               + "',SaticiAdres='" +textBox3.Text.ToString()
               + "',Saticiil='" + textBox4.Text.ToString()
               + "',Saticiilce='" + textBox5.Text.ToString()
               + "'where SaticiNo='" + textBox2.Tag.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();
            Goruntule("select*from Satici");
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Tag = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Satici where SaticiNo=@SaticiNo", baglanti);
            komut.Parameters.AddWithValue("@SaticiNo", textBox2.Tag); //hastanoyu gizledik ve hasta adında gizliyor.
            komut.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Satici");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Satici where SaticiAdSoyad like '%" + textBox2.Text + "%'", baglanti); //texbox2inn içindekilri arar.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
            this.Hide();
        }
    }
}
