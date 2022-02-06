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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server =localhost; Database=Pastane;Integrated Security=true ;");
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Select * From KullaniciGiris where KullaniciAd=@KullaniciAd and KullaniciSifre=@KullaniciSifre",baglanti);
            komut.Parameters.AddWithValue("@KullaniciAd",textBox4.Text);
            komut.Parameters.AddWithValue("@KullaniciSifre",textBox5.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 anasayfayagit=new Form1();
                anasayfayagit.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into KullaniciGiris(KullaniciAd,KullaniciSifre,Email,Telefon)values" +
                "(@KullaniciAd,@KullaniciSifre,@Email,@Telefon)", baglanti);
            cmd.Parameters.AddWithValue("@KullaniciAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@KullaniciSifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@Telefon",maskedTextBox1.Text);
           
            
            cmd.ExecuteNonQuery();
            baglanti.Close();
            
        }
    }
}
