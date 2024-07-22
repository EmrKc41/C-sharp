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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=banka_vt.accdb");
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            maskedTextBox1.Text = string.Empty;
        }
        

        private void giris_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; // Formun başlangıçta tamamen saydam olmasını sağlar
            timer1.Interval = 15; // Timer'ın her 10 milisaniyede bir çalışmasını sağlar
            timer1.Start(); // Timer'ı başlat


            MessageBox.Show("Hesabınız Yok İse Kayıt Olunuz!");
        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            kayit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * From Kisiler Where HESAP_NO=@p1 And SIFRE=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox1.Text);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                kisi kisi= new kisi();
                kisi.hesap = maskedTextBox1.Text;
                kisi.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
            baglanti.Close();

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor= Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }
    }
}
