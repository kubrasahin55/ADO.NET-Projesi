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
    public partial class Urunler : Form
    {
        public Urunler()
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

        private void Urunler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goruntule("select * from Urunler");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Tag = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Urunler(UrunAdi,UrunFiyat,KullanımTarihi,UretimTarihi,SaticiNo)values(@UrunAdi,@UrunFiyat,@KullanımTarihi,@UretimTarihi,@SaticiNo)", baglanti);
            cmd.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@UrunFiyat", textBox3.Text);
            cmd.Parameters.AddWithValue("@KullanımTarihi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@UretimTarihi", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@SaticiNo", textBox4.Text);
            
            cmd.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Urunler");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            SqlCommand komut = new SqlCommand("update Urunler set UrunAdi='" + textBox2.Text.ToString()
               + "',UrunFiyat='" + textBox3.Text.ToString()
               + "',KullanımTarihi='" +dateTimePicker1.Text.ToString()
                + "',UretimTarihi='" + dateTimePicker2.Text.ToString()
               + "',SaticiNo='" + textBox4.Text.ToString()
               + "'where UrunNo='" + textBox2.Tag.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();
            Goruntule("select*from Urunler");
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            


            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Urunler where UrunNo=@UrunNo", baglanti);
            komut.Parameters.AddWithValue("@UrunNo", textBox2.Tag); //hastanoyu gizledik ve hasta adında gizliyor.
            komut.ExecuteNonQuery();
            baglanti.Close();
            Goruntule("select * from Urunler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Urunler where UrunAdi like '%" + textBox2.Text + "%'", baglanti); //texbox2inn içindekilri arar.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            baglanti.Close();
        }
    }
}
