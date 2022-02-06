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
    public partial class siparişler : Form
    {
        public siparişler()
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
            Goruntule("select * from Siparis");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Siparis(SiparisAdi,SiparisAdres,SiparisAdet,SiparisFiyat,UrunNo,Tutar)values(@SiparisAdi,@SiparisAdres,@SiparisAdet,@SiparisFiyat,@UrunNo,@Tutar)", baglanti);
            cmd.Parameters.AddWithValue("@SiparisAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@SiparisAdres", textBox3.Text);
            cmd.Parameters.AddWithValue("@SiparisAdet", textBox7.Text);
             cmd.Parameters.AddWithValue("@SiparisFiyat", textBox4.Text);
            cmd.Parameters.AddWithValue("@UrunNo", textBox5.Text);
            cmd.Parameters.AddWithValue("@Tutar", textBox6.Text);
            

            cmd.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Siparis");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            SqlCommand komut = new SqlCommand("update Siparis set SiparisAdi='" + textBox2.Text.ToString()
               + "',SiparisAdres='" + textBox3.Text.ToString()
               + "',SiparisAdet='" + textBox7.Text.ToString()
                + "',SiparisFiyat='" + textBox4.Text.ToString()
               + "',UrunNo='" + textBox5.Text.ToString()
               + "',Tutar='" + textBox6.Text.ToString()
               

               + "'where SiparisNo='" + textBox2.Tag.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();
            Goruntule("select*from Siparis");
            baglanti.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Tag = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Siparis where SiparisNo=@SiparisNo", baglanti);
            komut.Parameters.AddWithValue("@SiparisNo", textBox2.Tag); //hastanoyu gizledik ve hasta adında gizliyor.
            komut.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Siparis");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Siparis where SiparisAdi like '%" + textBox2.Text + "%'", baglanti); //texbox2inn içindekilri arar.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
