using System;
using System.Windows.Forms;

namespace blackjack2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e) //başla
        {
            Form1 oyun = new Form1();
            if (textBox1.Text != "")
                oyun.label6.Text = textBox1.Text;

            if(textBox2.Text != "")
                oyun.label10.Text = textBox2.Text;
            this.Hide();
            oyun.Show();
        }

        private void button2_Click(object sender, EventArgs e) // nasıl
        {
            MessageBox.Show("Elini en yüksek değere çıkaran oyuncu o eli kazanır.\nElinin toplamı 21 geçen oyuncu hükmen kaybeder.\nAs kartları hem 1 hem 11 puan olarak oynana bilir.\nBunun için yapmanız gereken As kart çektiğinizde aktif olan kutucuğu işaretlemektir.","Böyle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e) // çık
        {
            Application.Exit();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                button1.PerformClick();
        }
    }
}
