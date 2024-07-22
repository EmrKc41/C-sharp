using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Data.OleDb;

namespace Doviz
{
    public partial class chf : Form
    {
        public chf()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;doviz_vt.accdb");
        private void chf_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; // Formun başlangıçta tamamen saydam olmasını sağlar
            timer1.Interval = 15; // Timer'ın her 10 milisaniyede bir çalışmasını sağlar
            timer1.Start(); // Timer'ı başlat


            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string chfalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteBuying").InnerXml;
            label3.Text = chfalis;
            string chfsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteSelling").InnerXml;
            label4.Text = chfsatis;

            maskedTextBox1.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            maskedTextBox2.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
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
            textBox8.Text = label3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = label4.Text;
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(textBox1.Text);
            int miktar = Convert.ToInt32(textBox2.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            textBox3.Text = tutar.ToString();

            double kalan;
            kalan = miktar % kur;
            textBox4.Text = kalan.ToString();
            MessageBox.Show("Müşterinin Tam Olarak İstediği Kadar Alabilmesi için " + kalan + " ₺ daha ödemesi gerekli!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(".", ",");
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(textBox8.Text);
            int miktar = Convert.ToInt32(textBox7.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            textBox6.Text = tutar.ToString();

            double kalan;
            kalan = miktar % kur;
            textBox5.Text = kalan.ToString();
            MessageBox.Show("Müşterinin Tam Olarak İstediği Kadar Alabilmesi için " + kalan + " ₺ daha ödemesi gerekli!");
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text.Replace(".", ",");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //HTML TASARIMI ALDIK
            string htmlTemplate = File.ReadAllText("SaticiPDF_Template.html");
            //TASARIMDA NERELERİ DEĞİŞMEK İSTERSEK ONA KARAR VERDİK
            htmlTemplate = htmlTemplate.Replace("{{SaticiAdSoyad}}", textBox9.Text);
            htmlTemplate = htmlTemplate.Replace("{{SatisTarihi}}", maskedTextBox1.Text);
            htmlTemplate = htmlTemplate.Replace("{{TarihSaat}}", maskedTextBox1.Text);
            htmlTemplate = htmlTemplate.Replace("{{Döviz}}", this.Text);
            htmlTemplate = htmlTemplate.Replace("{{Kur}}", textBox1.Text);
            htmlTemplate = htmlTemplate.Replace("{{Miktar}}", textBox2.Text);
            htmlTemplate = htmlTemplate.Replace("{{Tutar}}", textBox3.Text);

            //Ayarlar
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            converter.Options.MarginTop = 0;
            converter.Options.MarginBottom = 0;
            converter.Options.WebPageHeight = 1366;
            converter.Options.WebPageWidth = 1096;
            converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
            converter.Options.InternalLinksEnabled = true;

            //Dosya kaydetme penceresini açmak için
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Makbuz";
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
            //İşlem Olumlu Olduğunda Kullanıcıya aktarılan kısım
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlTemplate);

                string savePath = saveFileDialog.FileName;
                doc.Save(savePath);
                doc.Close();
                System.Diagnostics.Process.Start(savePath);
                MessageBox.Show("PDF dosyası oluşturuldu ve Masaüstüne kaydedildi.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //HTML TASARIMI ALDIK
            string htmlTemplate = File.ReadAllText("AliciPDF_Template.html");
            //TASARIMDA NERELERİ DEĞİŞMEK İSTERSEK ONA KARAR VERDİK
            htmlTemplate = htmlTemplate.Replace("{{AliciAdSoyad}}", textBox11.Text);
            htmlTemplate = htmlTemplate.Replace("{{AlisTarihi}}", maskedTextBox2.Text);
            htmlTemplate = htmlTemplate.Replace("{{TarihSaat}}", maskedTextBox2.Text);
            htmlTemplate = htmlTemplate.Replace("{{Döviz}}", this.Text);
            htmlTemplate = htmlTemplate.Replace("{{Kur}}", textBox8.Text);
            htmlTemplate = htmlTemplate.Replace("{{Miktar}}", textBox7.Text);
            htmlTemplate = htmlTemplate.Replace("{{Tutar}}", textBox6.Text);

            //Ayarlar
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            converter.Options.MarginTop = 0;
            converter.Options.MarginBottom = 0;
            converter.Options.WebPageHeight = 1366;
            converter.Options.WebPageWidth = 1096;
            converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
            converter.Options.InternalLinksEnabled = true;

            //Dosya kaydetme penceresini açmak için
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Makbuz";
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
            //İşlem Olumlu Olduğunda Kullanıcıya aktarılan kısım
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlTemplate);
                string savePath = saveFileDialog.FileName;
                doc.Save(savePath);
                doc.Close();
                System.Diagnostics.Process.Start(savePath);
                MessageBox.Show("PDF dosyası oluşturuldu ve Masaüstüne kaydedildi.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(textBox1.Text);
            miktar = Convert.ToDouble(textBox2.Text);
            tutar = kur * miktar;
            textBox3.Text = tutar.ToString();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Insert into  Satan (Satan_AdSoyad, Satis_Turu, Satis_Tarihi, Satis_Miktari) VALUES (@p1, @p2, @p3, @p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox9.Text);
            komut.Parameters.AddWithValue("@p2", this.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4", miktar.ToString());
            komut.ExecuteNonQuery();
            MessageBox.Show("Satış Başarılı!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(textBox8.Text);
            miktar = Convert.ToDouble(textBox7.Text);
            tutar = kur * miktar;
            textBox6.Text = tutar.ToString();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Insert into  Alan (Alan_AdSoyad, Alim_Turu, Alim_Tarihi, Alim_Miktari) VALUES (@p1, @p2, @p3, @p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox11.Text);
            komut.Parameters.AddWithValue("@p2", this.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p4", miktar);
            komut.ExecuteNonQuery();
            MessageBox.Show("Alım Başarılı!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Replace(".", ",");
        }
    }
}
