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

namespace BankaTest
{
    public partial class kisi : Form
    {
        public kisi()
        {
            InitializeComponent();
        }
        public string hesap;
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

        private void kisi_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; // Formun başlangıçta tamamen saydam olmasını sağlar
            timer1.Interval = 15; // Timer'ın her 10 milisaniyede bir çalışmasını sağlar
            timer1.Start(); // Timer'ı başlat

            label6.Text = hesap;

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * From Kisiler Where HESAP_NO=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1",hesap);
            OleDbDataReader dr= komut.ExecuteReader();
            while(dr.Read())
            {
                label5.Text = dr[1]+ " " + dr[2];
                label7.Text = dr[3].ToString();
                label8.Text = dr[4].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Gönderilen Hesabın Para ARTIŞI
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("UPDATE  Hesap SET BAKIYE=BAKIYE+@p1 Where HESAP_NO=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1",decimal.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            

            //Gönderen Hesabın Para AZALIŞI
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("UPDATE  Hesap SET BAKIYE=BAKIYE-@k1 Where HESAP_NO=@k2", baglanti);
            komut2.Parameters.AddWithValue("@k1", decimal.Parse(textBox1.Text));
            komut2.Parameters.AddWithValue("@k2", hesap);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarıyla Gerçekleşti!");

            //Hareket 
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("Select * From Kisiler Where HESAP_NO=@c1", baglanti);
            OleDbCommand komut4 = new OleDbCommand("Select * From Hesap Where HESAP_NO=@h1", baglanti);
            OleDbCommand komut5 = new OleDbCommand("Select * From Kisiler Where HESAP_NO=@d1", baglanti);
            OleDbCommand komut6 = new OleDbCommand("Select * From Hesap Where HESAP_NO=@e1", baglanti);



            komut3.Parameters.AddWithValue("@c1", maskedTextBox1.Text);
            komut4.Parameters.AddWithValue("@h1", maskedTextBox1.Text);
            komut5.Parameters.AddWithValue("@d1", maskedTextBox1.Text);
            komut6.Parameters.AddWithValue("@e1", maskedTextBox1.Text);

            OleDbDataReader dt = komut3.ExecuteReader();
            OleDbDataReader dd = komut4.ExecuteReader();
            OleDbDataReader dc = komut5.ExecuteReader();
            OleDbDataReader de = komut6.ExecuteReader();
            dekont dekont = new dekont();
            //Gönderen
            if (dt.Read())
            {
                
                dekont.hesapno = label6.Text;
                dekont.adsoyad = label5.Text;
                dekont.tutar = textBox1.Text;
                
            }
            if (dd.Read())
            {
                
                dekont.bakiye = dd[1].ToString();
                
                
            }
            //Alıcı
            if (dc.Read())
            {

                dekont.alicihesapno = maskedTextBox1.Text;
                dekont.alicitutar = textBox1.Text;

            }
            if (de.Read())
            {
                 
                dekont.alicibakiye = textBox1.Text + de[1].ToString();


            }
            dekont.Show();
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
            button1.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }
    }
}
