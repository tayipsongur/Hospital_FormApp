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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIKEIHG\\SA;Initial Catalog=Hastane;Integrated Security=True");

        private void btnUzmanSayi_Click(object sender, EventArgs e)
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
                    komut.CommandText = "PolUzmanSayiOrtalama";

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

        private void btnYatakSayı_Click(object sender, EventArgs e)
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
                    komut.CommandText = "PolYatakSayiAdet";

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

        private void btnDogumUzmanlıkAlan_Click(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorUzmanlıkGruplandırma";

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

        private void btnDoktorUnvan_Click(object sender, EventArgs e)
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
                    komut.CommandText = "DoktorUnvanGruplandırma ";

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

        private void btnRaporaGöreYasOrt_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaYasOrtalaması ";

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
            dataGridView1.Visible = true;


            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;

                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "HastalarYasToplam ";

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

        private void button2_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaBoyOrtalama ";

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

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            Form1 geridön = new Form1();
            geridön.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnJoin1_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaneJoin1";

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

        private void Rapor_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaneLeftJoin";

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

        private void button5_Click(object sender, EventArgs e)
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
                    komut.CommandText = "HastaneJoinRight1";

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

        private void button6_Click(object sender, EventArgs e)
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
                    komut.CommandText = "PoliklinikNoDoktorBilgi";

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
    }
    }
    

