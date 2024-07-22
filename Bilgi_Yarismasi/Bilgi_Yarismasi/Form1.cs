using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgi_Yarismasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int soruno = 0, dogru = 0, yanlis = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            label8.Text =  button3.Text;
            if (label7.Text == label8.Text)
            {
                dogru++;
                label5.Text = dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlis++;
                label6.Text = yanlis.ToString();
                pictureBox2.Visible = true;
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            label8.Text = button4.Text;
            if (label7.Text == label8.Text)
            {
                dogru++;
                label5.Text = dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlis++;
                label6.Text = yanlis.ToString();
                pictureBox2.Visible = true;
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            label8.Text = button5.Text;
            if (label7.Text == label8.Text)
            {
                dogru++;
                label5.Text = dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlis++;
                label6.Text = yanlis.ToString();
                pictureBox2.Visible = true;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            label8.Text =button2.Text;
            if (label7.Text == label8.Text)
            {
                dogru++;
                label5.Text = dogru.ToString(); 
                pictureBox1.Visible=true;
            }
            else
            {
                yanlis++;
                label6.Text = yanlis.ToString();
                pictureBox2.Visible=true;
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;       
            soruno++;
            label4.Text = soruno.ToString();
            if (soruno == 1) 
            {
                richTextBox1.Text = "Cumhuriyet Ne Zaman İlan Edilmiştir?";
                button2.Text = "1920";
                button3.Text = "1921";
                button4.Text = "1922";
                button5.Text = "1923";
                label7.Text = button5.Text;
            }
            if (soruno == 2)
            {
                richTextBox1.Text = "Hangi Şehir Ege Bölgesinde Bulunmaz?";
                button2.Text = "İzmir";
                button3.Text = "Mersin";
                button4.Text = "Burdur";
                button5.Text = "Çanakkale";
                label7.Text = button3.Text;
            }
            if (soruno == 3)
            {
                richTextBox1.Text = "Son Kuşlar Hangi Yazara Aittir?";
                button2.Text = "Sait Faik Abasıyanık";
                button3.Text = "Cemal Süreyya";
                button4.Text = "Atilla İlhan";
                button5.Text = "Reşat Nuri Güntekin";
                label7.Text = button2.Text;
            }
            if (soruno > 3)
            {
                richTextBox1.Text = "Sorulara Başarı İle Cevap Verdiniz!"+"\n" + "Doğru Sayınız: "+label5.Text + "\n" + "Yanlış Sayınız: " + label6.Text;
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
            }
        }
    }
}
