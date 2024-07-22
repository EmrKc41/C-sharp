using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doviz
{
    public partial class kursecimi : Form
    {
        public kursecimi()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; 
            }
            else
            {
                timer1.Stop(); 
            }
        }

        private void kursecimi_Load(object sender, EventArgs e)
        {
            this.Opacity = 0; 
            timer1.Interval = 15; 
            timer1.Start(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                usd usd = new usd();
                usd.Show();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                aud aud= new aud();
                aud.Show();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                dkk dkk = new dkk();
                dkk.Show();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                eur eur = new eur();
                eur.Show();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                gbp gbp = new gbp();
                gbp.Show();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                chf chf = new chf();
                chf.Show();
            }
            if (comboBox1.SelectedIndex == 6)
            {
                sek sek = new sek();
                sek.Show();
            }
            if (comboBox1.SelectedIndex == 7)
            {
                cad cad = new cad();
                cad.Show();
            }
            if (comboBox1.SelectedIndex == 8)
            {
                kwd kwd = new kwd();
                kwd.Show();
            }
            if (comboBox1.SelectedIndex == 9)
            {
                nok nok = new nok();
               nok.Show();
            }
            if (comboBox1.SelectedIndex == 10)
            {
                sar sar = new sar();
                sar.Show();
            }
        }
    }
}
