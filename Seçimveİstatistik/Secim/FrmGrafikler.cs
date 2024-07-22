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

namespace Secim
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //İLÇE ADLARINI COMBOBOX'A ÇEKME
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("Select Ilce_Ad From ilce", baglanti);
            OleDbDataReader dr = komut1.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //Grafiğe Toplam Sonuçları Getirme
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("Select Sum(AParti), Sum(BParti), Sum(CParti), Sum(DParti),Sum(EParti) From ilce", baglanti);
            OleDbDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr2[4]);
               
            }
            baglanti.Close();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * From ilce where Ilce_Ad=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = Convert.ToInt32(dr[2].ToString());
                progressBar2.Value = Convert.ToInt32(dr[3].ToString());
                progressBar3.Value = Convert.ToInt32(dr[4].ToString());
                progressBar4.Value = Convert.ToInt32(dr[5].ToString());
                progressBar5.Value = Convert.ToInt32(dr[6].ToString());

                label7.Text = dr[2].ToString();
                label8.Text = dr[3].ToString();
                label9.Text = dr[4].ToString();
                label10.Text = dr[5].ToString();
                label11.Text = dr[6].ToString();

            }
            baglanti.Close();
        }
    }
}
