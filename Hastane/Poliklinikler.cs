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
    public partial class Poliklinikler : Form
    {
        public Poliklinikler()
        {
            InitializeComponent();
        }

        public void VerileriGoster()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PoliklinikListele";

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        public void Temizle()
        {
            txtNo.Clear();
            txtPolAdi.Clear();
            txtUzmanSayi.Clear();
            txtPolBaskan.Clear();
            txtYatakSayi.Clear();
            txtPolBasHemsire.Clear();

        }
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIKEIHG\\SA;Initial Catalog=Hastane;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {


            dataGridView1.Visible = true;

            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikListele";

                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;
                    

                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();



        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show("Ekleme Yapmak İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (baglanti.State==ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikEkle";

                    komut.Parameters.AddWithValue("PolAdi", txtPolAdi.Text);
                    komut.Parameters.AddWithValue("PolUzmanSayisi", txtUzmanSayi.Text);
                    komut.Parameters.AddWithValue("PolBaskan", txtPolBaskan.Text);
                    komut.Parameters.AddWithValue("PolBasHemsire", txtPolBasHemsire.Text);
                    komut.Parameters.AddWithValue("YatakSayisi", txtYatakSayi.Text);
                    komut.ExecuteNonQuery();
                    VerileriGoster();

                    MessageBox.Show("Ekleme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);
                    Temizle();

                   

                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU", Hata.Message);
            }
            baglanti.Close();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show("Silmek İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (baglanti.State == ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikSil";

                    komut.Parameters.AddWithValue("PolNo", txtNoSil.Text);
                    komut.ExecuteNonQuery();
                    VerileriGoster();

                    MessageBox.Show("Silme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);
                    txtNoSil.Clear();
                   
                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show("Bilgileri Değiştirmek İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (baglanti.State == ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikGuncelle";

                    komut.Parameters.AddWithValue("PolNo", txtNo.Text);
                    komut.Parameters.AddWithValue("PolAdi", txtPolAdi.Text);
                    komut.Parameters.AddWithValue("PolUzmanSayisi", txtUzmanSayi.Text);
                    komut.Parameters.AddWithValue("PolBaskan", txtPolBaskan.Text);
                    komut.Parameters.AddWithValue("PolBasHemsire", txtPolBasHemsire.Text);
                    komut.Parameters.AddWithValue("YatakSayisi", txtYatakSayi.Text);
                    komut.ExecuteNonQuery();
                    VerileriGoster();

                    MessageBox.Show("Güncelleme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);
                    Temizle();
                   
                }
               
            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();

        }

        private void BtnArama_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikArama";

                    komut.Parameters.AddWithValue("PolNo", txtAraNo.Text);
                    komut.Parameters.AddWithValue("PolAdi", txtAraPolAd.Text);

                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;

                    txtAraNo.Clear();
                    txtAraPolAd.Clear();
                    
                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();


        }

        private void BtnSırala1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikSıralaAZ";
                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;

                    
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();



        }

        private void BtnSırala2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PoliklinikSıralaZA";
                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;

                   
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();


        }

        private void btnGizle_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            Temizle();
         
        }

        private void Poliklinikler_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;

            txtNo.Enabled = false;
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            Form1 geridön = new Form1();
            geridön.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış Yapmak İstiyor Musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;

            string PolNo = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            string PolAdi = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            string PolUzman = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            string PolBaskan = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            string PolBasHemsire = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            string YatakSayisi = dataGridView1.Rows[sectim].Cells[5].Value.ToString();


            txtNo.Text = PolNo;
            txtPolAdi.Text = PolAdi;
            txtUzmanSayi.Text = PolUzman;
            txtPolBaskan.Text = PolBaskan;
            txtPolBasHemsire.Text = PolBasHemsire;
            txtYatakSayi.Text = YatakSayisi;

        }
    }
}
