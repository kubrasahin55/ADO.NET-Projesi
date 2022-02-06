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
    public partial class musteriler : Form
    {
        public musteriler()
        {
            InitializeComponent();
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
            Goruntule("select * from Musteriler");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Musteriler(MusteriAdSoyad,MusteriTelefon,SiparisNo)values(@MusteriAdSoyad,@MusteriTelefon,@SiparisNo)", baglanti);
            cmd.Parameters.AddWithValue("@MusteriAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@MusteriTelefon", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@SiparisNo", textBox3.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Musteriler");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Tag = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            //SqlCommand komut = new SqlCommand("Update Musteriler set MusteriAdSoyad='" + textBox2.Text.ToString()
            //    + "',MusteriTelefon='" + maskedTextBox1.Text.ToString()
            //    + "',SiparisNo='" + textBox3.Text.ToString() + "'", baglanti); 


            SqlCommand komut = new SqlCommand("update Musteriler set MusteriAdSoyad='" + textBox2.Text.ToString()
               + "',MusteriTelefon='" + maskedTextBox1.Text.ToString() 
                + "',SiparisNo='" + textBox3.Text.ToString()
                + "'where MusteriNo='" + textBox2.Tag.ToString() + "'", baglanti);
           
                komut.ExecuteNonQuery();
               Goruntule("select*from Musteriler");
                baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Musteriler where MusteriNo=@MusteriNo", baglanti);
            komut.Parameters.AddWithValue("@MusteriNo", textBox2.Tag); //hastanoyu gizledik ve hasta adında gizliyor.
            komut.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Musteriler");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rapor rapor=new Rapor();
            rapor.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteriler where MusteriAdSoyad like '%" + textBox2.Text + "%'", baglanti); //texbox2inn içindekilri arar.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            baglanti.Close();
         }
    }
}
