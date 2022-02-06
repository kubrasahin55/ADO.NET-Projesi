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
    public partial class Rapor : Form
    {
        public Rapor()
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
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Saticiil,SaticiAdSoyad from Satici order by Saticiil asc",baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable ds=new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource=ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Saticiil,SaticiAdSoyad from Satici where Saticiil='istanbul'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Saticiilce,SaticiAdSoyad from Satici where Saticiilce='ümraniye' or Saticiilce='üsküdar'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select MusteriAdSoyad from Musteriler order by MusteriAdSoyad desc", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select top (2)* from Urunler order by UrunNo desc", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select UrunAdi,UrunFiyat from Urunler where UrunAdi=('makaron') and UrunFiyat>50 order by UrunFiyat", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        private void button5_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select* from Urunler where KullanımTarihi between '13.01.2021'and '4.08.2020'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KullanımTarihi, max(UrunFiyat) as yüksekFiyat from Urunler where KullanımTarihi = '20.11.2021' group by KullanımTarihi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select MusteriAdSoyad, sum(SiparisFiyat) as 'Sipariş Toplamı' from Musteriler m inner join Siparis s on m.SiparisNo = s.SiparisNo group by MusteriAdSoyad", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select SiparisAdi, sum(SiparisAdet) as 'Sipariş Toplamı' from Musteriler m inner join Siparis s on m.SiparisNo = s.SiparisNo group by SiparisAdi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select SiparisAdi, sum(SiparisFiyat) as 'Sipariş Toplamı' from Musteriler m inner join Siparis s on m.SiparisNo = s.SiparisNo group by SiparisAdi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;

        }
    }
}
