using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Okul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Casper\OneDrive\Masaüstü\C#\Uyguamalar\Okul\Okul\Okul.accdb");
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * From Ogrenci Where Ogrenci_Id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            var ogrenciler=komut.ExecuteScalar();
            
            if (ogrenciler==null)
            {
                MessageBox.Show("Ogrenci Bulunamadı");
            }
            else
            {
                FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
                fr.numara = textBox1.Text;
                fr.Show();
            }
            
            baglanti.Close();
        }
        public string numara;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select Ogrt_AdSoyad From Ogretmenler Where Ogrt_Id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            var ogrt = komut.ExecuteScalar();

            if (ogrt == null)
            {
                MessageBox.Show("Öğretmen Bulunamadı");
            }
            else
            {
                FrmOgretmen fs = new FrmOgretmen();
                fs.ogrt = ogrt.ToString();
                fs.Show();
            }

            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
