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
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIKEIHG\\SA;Initial Catalog=Hastane;Integrated Security=True");

        public void VerileriGoster()
        {
            
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "HastaListele";

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;

        }

        public void Temizle()
        {
            txtHastaNo.Clear();
            txtHastaTC.Clear();
            txtHastaAdSoyad.Clear();
            txtBoy.Clear();
            txtYas.Clear();
            txtRecete.Clear();
            txtRprDrm.Clear();
            txtDoktorNo.Text = "";
            dateTimePickerDgmTrh.ResetText();
            dateTimePickerRndvTrh.ResetText();
      
            
        }
        private void btnListele_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaListele";

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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show("Ekleme İşlemi Yapmak İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {

                if (baglanti.State==ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "HastaEkle";

                    komut.Parameters.AddWithValue("HastaAdSoyad", txtHastaAdSoyad.Text);
                    komut.Parameters.AddWithValue("TcNo", txtHastaTC.Text);
                    komut.Parameters.AddWithValue("DogumTarihi", dateTimePickerDgmTrh.Value);
                    komut.Parameters.AddWithValue("Boy", txtBoy.Text);
                    komut.Parameters.AddWithValue("Yas", txtYas.Text);
                    komut.Parameters.AddWithValue("Recete", txtRecete.Text);
                    komut.Parameters.AddWithValue("RaporDurumu", txtRprDrm.Text);
                    komut.Parameters.AddWithValue("RandevuTarihi", dateTimePickerRndvTrh.Value);
                    komut.Parameters.AddWithValue("DoktorNo", txtDoktorNo.Text);

                    komut.ExecuteNonQuery();
                    VerileriGoster();
                    MessageBox.Show("Ekleme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);
                    Temizle();

                   
                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show("Silmek İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (baglanti.State==ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "HastaSil";

                    komut.Parameters.AddWithValue("HastaNo", txtHastaSil.Text);
                    komut.ExecuteNonQuery();
                    VerileriGoster();

                    MessageBox.Show("Silme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);
                    txtHastaSil.Clear();
                    
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show("Bilgileri Değiştirmek İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (baglanti.State==ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "HastaGuncelleme";

                    komut.Parameters.AddWithValue("HastaNo", txtHastaNo.Text);
                    komut.Parameters.AddWithValue("HastaAdSoyad", txtHastaAdSoyad.Text);
                    komut.Parameters.AddWithValue("TcNo", txtHastaTC.Text);
                    komut.Parameters.AddWithValue("DogumTarihi", dateTimePickerDgmTrh.Value);
                    komut.Parameters.AddWithValue("Boy", txtBoy.Text);
                    komut.Parameters.AddWithValue("Yas", txtYas.Text);
                    komut.Parameters.AddWithValue("Recete", txtRecete.Text);
                    komut.Parameters.AddWithValue("RaporDurumu", txtRprDrm.Text);
                    komut.Parameters.AddWithValue("RandevuTarih", dateTimePickerRndvTrh.Value);
                    komut.Parameters.AddWithValue("DoktorNo", txtDoktorNo.Text);

                    MessageBox.Show("Güncelleme İşlemi Başarılı ?", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    komut.ExecuteNonQuery();
                    VerileriGoster();

                   
                    Temizle();
                   
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();


        }

        private void btnArama_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaArama";

                    komut.Parameters.AddWithValue("HastaNo", txtArnckHastaNo.Text);
                    komut.Parameters.AddWithValue("HastaAdSoyad", txtArnckHstaAdSyd.Text);
                    komut.Parameters.AddWithValue("TcNo", txtArnckTcNo.Text);

                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;

                    txtArnckHastaNo.Clear();
                    txtArnckHstaAdSyd.Clear();
                    txtArnckTcNo.Clear();
                    
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();

        }

        private void btnSıralaAZ_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaSıralaAZ";

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

        private void btnSıralaZA_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaSıralaZA";

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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            Temizle();
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            Form1 frmdön = new Form1();
            frmdön.Show();
            this.Hide();
        }

        private void Hastalar_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            txtHastaNo.Enabled = false;

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DoktorNoSec";

            SqlDataReader dr;

            baglanti.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtDoktorNo.Items.Add(dr["DoktorNo"]);
            }
            baglanti.Close();
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

            string HastaNo = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            string HastaAdSoyad = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            string TcNo = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            string DogumTarihi = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            string Boy = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            string Yas = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            string Recete = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
            string RaporDurumu = dataGridView1.Rows[sectim].Cells[7].Value.ToString();
            string RandevuTarih = dataGridView1.Rows[sectim].Cells[8].Value.ToString();
            string DoktorNo = dataGridView1.Rows[sectim].Cells[9].Value.ToString();

            txtHastaNo.Text = HastaNo;
            txtHastaAdSoyad.Text = HastaAdSoyad;
            txtHastaTC.Text = TcNo;
            dateTimePickerDgmTrh.Text = DogumTarihi;
            txtBoy.Text = Boy;
            txtYas.Text = Yas;
            txtRecete.Text = Recete;
            txtRprDrm.Text = RaporDurumu;
            dateTimePickerRndvTrh.Text = RandevuTarih;
            txtDoktorNo.Text = DoktorNo;


        }
    }
}
