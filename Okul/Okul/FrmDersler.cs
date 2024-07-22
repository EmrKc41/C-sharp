using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Okul
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Casper\OneDrive\Masaüstü\C#\Uyguamalar\Okul\Okul\Okul.accdb");
        public void listele()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From Dersler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmDersler_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listeleme
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ekleme
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Insert into  Dersler (Ders_Ad) VALUES (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteReader();
            baglanti.Close();
            MessageBox.Show("Başarıyla Eklendi", "Bilgi");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //silme
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Delete From Dersler Where Ders_Id =@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Silindi", "Bilgi");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //güncelleme
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Update Dersler Set Ders_Ad=@p1 Where Ders_Id=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme Gerçekleşti", "Bilgi");
            listele();
        }
    }
}
