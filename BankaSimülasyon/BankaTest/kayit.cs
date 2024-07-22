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

namespace BankaTest
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=banka_vt.accdb");
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; // Formun görünürlüğünü artırın
            }
            else
            {
                timer1.Stop(); // Form tamamen görünür hale geldiğinde zamanlayıcıyı durdurun
            }
        }

        private void kayit_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; // Formun başlangıçta tamamen saydam olmasını sağlar
            timer1.Interval = 15; // Timer'ın her 10 milisaniyede bir çalışmasını sağlar
            timer1.Start(); // Timer'ı başlat
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Insert Into Kisiler (AD,SOYAD,TC,TELEFON,HESAP_NO,SIFRE) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBox3.Text);
            komut.Parameters.AddWithValue("@p6", textBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi=rastgele.Next(100000, 1000000);
            maskedTextBox3.Text = sayi.ToString();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            maskedTextBox1.Text =string.Empty;
            maskedTextBox2.Text =string.Empty;
            maskedTextBox3.Text =string.Empty;
            textBox5.Text = string.Empty;
        }
    }
}
