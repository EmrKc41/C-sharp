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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;

namespace BankaTest
{
    public partial class dekont : Form
    {
        public dekont()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=banka_vt.accdb");
        public string hesapno, adsoyad,tutar,bakiye, alicihesapno, aliciadsoyad,alicitutar,alicibakiye;

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

        private void dekont_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; // Formun başlangıçta tamamen saydam olmasını sağlar
            timer1.Interval = 15; // Timer'ın her 10 milisaniyede bir çalışmasını sağlar
            timer1.Start(); // Timer'ı başlat

            label6.Text = alicihesapno;
            label5.Text = aliciadsoyad;
            label4.Text = alicitutar;
            label3.Text = alicibakiye;

            label13.Text = adsoyad;
            label14.Text = hesapno;
            label17.Text = tutar;
            label18.Text = bakiye;
            
            
            
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
      
    }
}
