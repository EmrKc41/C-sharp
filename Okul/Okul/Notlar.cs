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

namespace Okul
{
    public partial class Notlar : Form
    {
        public Notlar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Casper\OneDrive\Masaüstü\C#\Uyguamalar\Okul\Okul\Okul.accdb");
        public string numara;
        private void Notlar_Load(object sender, EventArgs e)
        {
            //DATA GRID VIEWE VERİ YAZDIRMA
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select  *  From Notlar", baglanti);
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
