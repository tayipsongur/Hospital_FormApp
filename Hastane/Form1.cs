using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doktor doktorgecis = new Doktor();
            doktorgecis.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Poliklinikler poliklinikgecis = new Poliklinikler();
            poliklinikgecis.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hastalar hastagecis = new Hastalar();
            hastagecis.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış Yapmak İstiyor Musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (secenek == DialogResult.No)
            {
               
           
            }


        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            Rapor raporagit = new Rapor();
            raporagit.Show();
            this.Hide();
        }
    }
}
