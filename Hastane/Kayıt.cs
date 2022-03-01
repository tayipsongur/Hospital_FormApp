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

namespace Hastane
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIKEIHG\\SA;Initial Catalog=Hastane;Integrated Security=True");

        private void btnGirisEkrani_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;

            komut.CommandText = "Giris";
            komut.Parameters.AddWithValue("kad", textBox1.Text);
            komut.Parameters.AddWithValue("sifre", textBox2.Text);

            baglanti.Open();

            SqlDataReader dr;

            dr = komut.ExecuteReader();

            if (dr.Read())
            {

                MessageBox.Show("Tebrikler ! Başarılı Bir Şekilde Giriş Yaptınız.");
                Form1 git = new Form1();

                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız veya Şifreniz Hatalı. Kontrol Ediniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            baglanti.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            groupBox1.Visible = true;
      
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "UyeOl";

            komut.Parameters.AddWithValue("Kullaniciad", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("Sifre", txtSifre.Text);

            komut.Parameters.AddWithValue("Email",txtMail.Text);
            komut.Parameters.AddWithValue("TelefonNo", txtTelefon.Text);
            

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("BAŞARILI BİR ŞEKİLDE ÜYE OLDUNUZ.) ");

            txtKullaniciAd.Clear();
            txtMail.Clear();
            txtSifre.Clear();
            txtTelefon.Clear();
        }


        private void Kayıt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnGirisEkrani.PerformClick();
               
            }
                  
        }
        private void Kayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
