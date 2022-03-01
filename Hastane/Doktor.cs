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
    public partial class Doktor : Form
    {
        public Doktor()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIKEIHG\\SA;Initial Catalog=Hastane;Integrated Security=True");
        public void VerileriGoster()
        {
            dataGridView1.Visible = true;

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DoktorListele";

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

  
        public void Temizle()
        {
            txtDoktorNo.Clear();
            txtDoktorTc.Clear();
            txtDoktorAdSoyad.Clear();
            txtUnvan.Clear();
            txtUzmanlık.Clear();
            richTextBox1.Clear();
            mskdTelefon.Clear();
            txtPolNo.Text = "";
            dateTimePicker1.ResetText();

        }
    
    

        private void btnListele_Click_1(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorListele";

                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !",Hata.Message);
            }
            baglanti.Close();

        }

        private void BtnEkle_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            DialogResult secenek = MessageBox.Show(" Ekleme Yapmak İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {

                if (baglanti.State==ConnectionState.Closed && secenek==DialogResult.Yes)
                {

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "DoktorEkle";

                    komut.Parameters.AddWithValue("DoktorAdSoyad", txtDoktorAdSoyad.Text);
                    komut.Parameters.AddWithValue("Tc", txtDoktorTc.Text);
                    komut.Parameters.AddWithValue("UzmanlikAlani", txtUzmanlık.Text);
                    komut.Parameters.AddWithValue("Unvani", txtUnvan.Text);
                    komut.Parameters.AddWithValue("Telefon", mskdTelefon.Text);
                    komut.Parameters.AddWithValue("Adres", richTextBox1.Text);
                    komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("PolNo", txtPolNo.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ekleme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);
                    Temizle();
                    VerileriGoster();
                 
                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();



        }

        private void BtnSil_Click_1(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorSil";

                    komut.Parameters.AddWithValue("DoktorNo", txtDktrSil.Text);
                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;
                    MessageBox.Show("Silme İşlemi Başarılı", "BAŞARILI", MessageBoxButtons.OK);

                    txtDktrSil.Clear();
                    VerileriGoster();
                    
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BU DOKTOR NO'YA BAĞLI BİR HASTA MEVCUT... ", Hata.Message);
            }
            baglanti.Close();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış Yapmak İstiyor Musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
         
        }

        private void btnGeriDön_Click_1(object sender, EventArgs e)
        {
            Form1 frmgeridön = new Form1();
            frmgeridön.Show();
            this.Hide();
        }

        private void btnGizle_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            Temizle();
        }

        private void BtnSırala1_Click_1(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorSıralaAZ";

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

        private void BtnSırala2_Click_1(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorSıralaZA";

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

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;


          
            try
            {
                DialogResult secenek = MessageBox.Show("Bilgileri Değiştirmek İstiyor Musunuz ?", "UYARI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (baglanti.State==ConnectionState.Closed && secenek==DialogResult.Yes)
                {
                   

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "DoktorGuncelle";

                    komut.Parameters.AddWithValue("DoktorNo", txtDoktorNo.Text);
                    komut.Parameters.AddWithValue("DoktorAdSoyad", txtDoktorAdSoyad.Text);
                    komut.Parameters.AddWithValue("Tc", txtDoktorTc.Text);
                    komut.Parameters.AddWithValue("UzmanlikAlani", txtUzmanlık.Text);
                    komut.Parameters.AddWithValue("Unvani", txtUnvan.Text);
                    komut.Parameters.AddWithValue("Telefon", mskdTelefon.Text);
                    komut.Parameters.AddWithValue("Adres", richTextBox1.Text);
                    komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("PolNo", txtPolNo.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Güncelleme İşlemi Başarılı ?", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Temizle();
                    VerileriGoster();

                   
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();

        }

        private void BtnArama_Click_1(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorArama";
                    komut.Parameters.AddWithValue("DoktorNo", txtArnckdktrNo.Text);
                    komut.Parameters.AddWithValue("DoktorAdSoyad", txtArnckDktrAdSyd.Text);
                    komut.Parameters.AddWithValue("Tc", txtArnckDktrTC.Text);


                    SqlDataAdapter dr = new SqlDataAdapter(komut);
                    DataTable doldur = new DataTable();
                    dr.Fill(doldur);
                    dataGridView1.DataSource = doldur;

                    txtArnckDktrAdSyd.Clear();
                    txtArnckdktrNo.Clear();
                    txtArnckDktrTC.Clear();
                   
                }

            }
            catch (Exception Hata)
            {

                MessageBox.Show("BİR HATA OLUŞTU !", Hata.Message);
            }
            baglanti.Close();

        }
        private void Doktor_Load(object sender, EventArgs e)
        {

            txtDoktorNo.Enabled = false;
            dataGridView1.Visible = false;

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Getir";

            SqlDataReader dr;

            baglanti.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtPolNo.Items.Add(dr["PolNo"]);
            }
            baglanti.Close();





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;

            string DoktorNo = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            string DoktorAdSoyad = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            string Tc = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            string UzmanlikAlani = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            string Unvan = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            string Telefon = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            string Adres = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
            string DogumTarihi = dataGridView1.Rows[sectim].Cells[7].Value.ToString();
            string PolNo = dataGridView1.Rows[sectim].Cells[8].Value.ToString();



            txtDoktorNo.Text = DoktorNo;
            txtDoktorAdSoyad.Text = DoktorAdSoyad;
            txtDoktorTc.Text = Tc;
            txtUzmanlık.Text = UzmanlikAlani;

            txtUnvan.Text = Unvan;
            mskdTelefon.Text = Telefon;
            richTextBox1.Text = Adres;                           
            dateTimePicker1.Text = DogumTarihi;
            txtPolNo.Text = PolNo;

           
        }
    }
}
