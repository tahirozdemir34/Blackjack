/*  Tahir ÖZDEMİR
    152120141047
    Aralık 2015 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace blackjack2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
            label5.Text = "";
            label7.Text = "0";
            label9.Text = "0";
            label11.Text = "0";
            label21.Text = "Toplam";
            label20.Text = "Toplam";
            kartkar();
            label23.Text = "52";
            checkBox1.Enabled = false;
            label12.Text = "";
            button3_Click(null, null);
        }

        int sayac = 0; //Kart çekme butonu için oluşturduğum değişken. Sayacı arttırarak farklı pictureboxlara kart çekebiliyorum.
       
        int oyuncupuan = 0, pcpuan = 0, oyuncu_toplam = 0, berabere = 0, pc_toplam= 0;

        int ck = -1; // çekilen kart. -1den başlatıyorum çünkü kartçek butonuna basıldığında arttırıyorum

        int[] degerler = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
        string[] kartlar = { "Karo_A", "Karo_2", "Karo_3", "Karo_4", "Karo_5", "Karo_6", "Karo_7", "Karo_8", "Karo_9", "Karo_10", "Karo_Q", "Karo_J", "Karo_K", "Kupa_A", "Kupa_2", "Kupa_3", "Kupa_4", "Kupa_5", "Kupa_6", "Kupa_7", "Kupa_8", "Kupa_9", "Kupa_10", "Kupa_Q", "Kupa_J", "Kupa_K", "Maça_A", "Maça_2", "Maça_3", "Maça_4", "Maça_5", "Maça_6", "Maça_7", "Maça_8", "Maça_9", "Maça_10", "Maça_Q", "Maça_J", "Maça_K", "Sinek_A", "Sinek_2", "Sinek_3", "Sinek_4", "Sinek_5", "Sinek_6", "Sinek_7", "Sinek_8", "Sinek_9", "Sinek_10", "Sinek_Q", "Sinek_J", "Sinek_K" };

        int checkKontrol = 1; //CheckBox fonksiyonu içinde kullanılıyor. Oyna butonuna basana kadar değeri değiştirebiliyorsunuz.
        int kartsayisi = 52;
        string pcilk; // Oyun başında pc nin kapalı kartını tutan değişken. Bu sayede sonradan kartı gösterebiliyorum.

        Form2 frm2 = new Form2();

        int kapatmaKontrol = 0; //Kart bitip kapanması ile kullanıcı tarafından kapatma arasındaki farkı kontrol etmek için
        private void button2_Click(object sender, EventArgs e) //Kart Çek
        {
            ck++;
            kartsayisi--;
            if (sayac == 0 & kartsayisi >= 1) {
                oyuncu_toplam += degerler[ck];
                label5.Text = oyuncu_toplam.ToString();
                label21.Visible = true;
                pictureBox3.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox3.Visible = true;
                askontrol();
            }

            else if (sayac == 1 & kartsayisi >= 1) {
                oyuncu_toplam += degerler[ck];
                label5.Text = oyuncu_toplam.ToString();
                pictureBox4.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox4.Visible = true;
                askontrol();
            }

            else if (sayac == 2 & kartsayisi >= 1) {
                oyuncu_toplam += degerler[ck];
                label5.Text = oyuncu_toplam.ToString();
                pictureBox10.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox10.Visible = true;
                askontrol();
            }

            else if (sayac == 3 & kartsayisi >= 1) {
                oyuncu_toplam += degerler[ck];
                label5.Text = oyuncu_toplam.ToString();
                pictureBox11.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox11.Visible = true;
                askontrol();
            }

            else if (sayac == 4 & kartsayisi >= 1) {
                oyuncu_toplam += degerler[ck];
                label5.Text = oyuncu_toplam.ToString();
                pictureBox12.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox12.Visible = true;
                askontrol();
            }

            kartbittimi();

            sayac++;
            label23.Text = kartsayisi.ToString();

            kontrol21();

            if (oyuncu_toplam > 21) {
                MessageBox.Show("Eliniz 21'i geçti", "Kaybettiniz");
                pcpuan++;
                label11.Text = pcpuan.ToString();
                button3_Click(null,null); 
            }
        }
        
        private void button4_Click(object sender, EventArgs e) //Oyna 
        {
            pictureBox8.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(pcilk) as Image;
            
            if (pc_toplam < 17  & kartsayisi >=1) {
                ck++;
                kartsayisi--;
                pictureBox6.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox6.Visible = true;
                pc_toplam += degerler[ck];
            }

            if (pc_toplam < 17  & kartsayisi >= 1) {
                ck++;
                kartsayisi--;
                pictureBox5.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox5.Visible = true;
                pc_toplam += degerler[ck];
            }

            if (pc_toplam < 17  & kartsayisi >= 1) {
                ck++;
                kartsayisi--;
                pictureBox15.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox15.Visible = true;
                pc_toplam += degerler[ck];
            }

            if (pc_toplam < 17  & kartsayisi >= 1) {
                ck++;
                kartsayisi--;
                pictureBox14.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox14.Visible = true;
                pc_toplam += degerler[ck];
            }

            if (pc_toplam < 17  & kartsayisi >= 1) {
                ck++;
                kartsayisi--;
                pictureBox13.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pictureBox13.Visible = true;
                pc_toplam += degerler[ck];
            }

            kartbittimi();

            label23.Text = kartsayisi.ToString();
            label12.Text = pc_toplam.ToString();

            if (oyuncu_toplam > pc_toplam) {
                oyuncupuan = oyuncupuan + 1;
                label7.Text = oyuncupuan.ToString();
                label2.Text = "        Eli\nKAZANDINIZ!";
            }

            if (oyuncu_toplam < pc_toplam & pc_toplam < 22) {
                pcpuan++;
                label11.Text = pcpuan.ToString();
                label2.Text = "      Eli\nKaybettiniz";
            }
 
            if (oyuncu_toplam == pc_toplam) {
                berabere++;
                label9.Text = berabere.ToString();
                label2.Text = "      El\n Berabere";
            }

            if (pc_toplam > 21) { 
                label2.Text = "        Eli\nKAZANDINIZ!";
                oyuncupuan++;
                label7.Text = oyuncupuan.ToString();
                MessageBox.Show("Rakibinizin eli 21'i geçti","Kazandınız");
                button3_Click(null, null);
            }

            else { 
            button3.Enabled = true;
            button4.Enabled = false;
            button2.Enabled = false;
            }
                 
        }


        private void button3_Click(object sender, EventArgs e) //Tekrar
        {
            sıfırla(); //Her el başında masayı temizlemek için

            if (kartsayisi < 4) {
                MessageBox.Show("Oyunu oynamak için yeterli kart kalmadı. Ana menüye yönlendirileceksiniz.", "Oyun Bitti", MessageBoxButtons.OK);
                kapatmaKontrol++;
                frm2.Show();
                this.Close();
            }

            else{
                ck++;
                kartsayisi--;
                button2.Enabled = true;
                pictureBox1.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                oyuncu_toplam += degerler[ck];
                askontrol();

                ck++;
                kartsayisi--;
                pictureBox2.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                oyuncu_toplam += degerler[ck];
                askontrol();

                label5.Text = oyuncu_toplam.ToString();
                label21.Visible = true;
                
                ck++;
                kartsayisi--;
                pcilk = kartlar[ck];
                pictureBox8.Image = blackjack2.Properties.Resources.ResourceManager.GetObject("arka") as Image;
                pc_toplam += degerler[ck];

                ck++;
                kartsayisi--;
                pictureBox7.Image = blackjack2.Properties.Resources.ResourceManager.GetObject(kartlar[ck]) as Image;
                pc_toplam += degerler[ck];

                label23.Text = kartsayisi.ToString();
                label20.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox8.Visible = true;
                pictureBox7.Visible = true;
                button2.Enabled = true;
                button4.Enabled = true;

                kartbittimi();

                if (oyuncu_toplam == 11 & (degerler[ck-2] == 1 || degerler[ck-3] == 1))  //Oyuncunun As ve 10 değerinde bir kart çekmesi durumu
                    checkBox1.Checked = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(kapatmaKontrol == 0){
                DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinize emin misiniz ? Bütün puanlarınız kaybolacak!", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.No){
                    e.Cancel = true;
                }

                if (dialogResult == DialogResult.Yes){ 
                    frm2.Show();
                }
            }
        } 

        void kartkar()
        {
            Random rng = new Random(); 
            int n = kartlar.Length; //n=52 dizinin uzunluğuna eşit index sayısına değil
            while (n > 1)
            {
                int k = rng.Next(n);

                n--; // karma işlemini n değerini azaltarak yapıyorum ki aynı kartları tekrar seçmeyeyim

                //Kartlar dizisini karıştırmak
                string a = kartlar[n]; //son kartı a adında herhangi bir değikene eşitliyorum

                kartlar[n] = kartlar[k]; //rastgele seçtiğim kartı n. karta eşitliyorum (şuan dizide rastgele seçilen karttan iki tane var ve normalde ki n. kartım yok(a içinde tutuluyor))

                kartlar[k] = a;  // rastgele seçtiğim kartın yerine dizinin n. kartını eşitliyorum ki n. kartım kayıp olmasın ve dizide her karttan bir tane olsun

                int b = degerler[n];    //Değerler dizisini karıştırmak
                degerler[n] = degerler[k];
                degerler[k] = b;
            }
        }
        void askontrol()
        {
            if (oyuncu_toplam > 21 & checkBox1.Checked == true) {
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
            }

            else if (oyuncu_toplam > 11 & checkBox1.Checked == false)
                checkBox1.Enabled = false;

            else if (oyuncu_toplam > 11 & checkBox1.Checked == true)
                checkBox1.Enabled = true;

            else if (degerler[ck] == 1)
                checkBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) //Nasıl Oynanır
        {
            MessageBox.Show("Elini en yüksek değere çıkaran oyuncu o eli kazanır.\nElinin toplamı 21 geçen oyuncu hükmen kaybeder.\nAs kartları hem 1 hem 11 puan olarak oynana bilir.\nBunun için yapmanız gereken As kart çektiğinizde aktif olan kutucuğu işaretlemektir.", "Böyle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void checkBox1_CheckedChanged(object sender, EventArgs e) // As değeri 
                {
                    if(checkKontrol == 1) {
                        oyuncu_toplam += 10;
                        label5.Text = oyuncu_toplam.ToString();
                        checkKontrol *= -1;
                        kontrol21();
                    }

                    else {
                        oyuncu_toplam -= 10;
                        label5.Text = oyuncu_toplam.ToString();
                        checkKontrol *= -1;
                    }
                }

        void kontrol21()
        {
            if(oyuncu_toplam == 21) {
                MessageBox.Show("Blackjack", "Blackjack");
                checkBox1.Enabled = false;
                button4_Click(null,null);
            }
        }

        void sıfırla() {
            oyuncu_toplam = 0;
            pc_toplam = 0;
            sayac = 0;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            label2.Text = "";
            label12.Text = "";
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            oyuncu_toplam = 0; //CheckBox'ın sebep olduğu durumdan dolayı
            label5.Text = "";
        }

        void kartbittimi()
        {
            if (kartsayisi == 0){
                button2.Enabled = false;
                pictureBox9.Visible = false;
                label23.Visible = false;
                label3.Visible = true;
            }
        }
    }
}