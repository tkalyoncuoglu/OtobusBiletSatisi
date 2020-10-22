using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtobusBiletSatisi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyData.DataTable_Yolcular();
            DuzenKur();
        }

        void DuzenKur()
        {
            int say = 0;
            panel1.Controls.Clear();
            int olcu = 38;
            for (int i = 0; i < txt_duzen.Lines.Count(); i++)// textbox satırları arasında
            {
                for (int j = 0; j < txt_duzen.Lines[i].Count(); j++) // bir satırdaki karakterler arasında
                {
                    string satir = txt_duzen.Lines[i]; // bir satırı aldık
                    if (satir[j] == '*') // satırdaki j index'ine denk gelen ifade * ise
                    {
                        Button nesne = new Button();
                        nesne.Text = (++say).ToString();
                        nesne.Name = "buton_" + nesne.Text;
                        nesne.BackColor = Color.Red;
                        nesne.Width = nesne.Height = 40;
                        nesne.Left = olcu * j;// butonun nerede duracağı
                        nesne.Top = olcu * i; // butonun nerede duracağı
                        panel1.Controls.Add(nesne);
                        nesne.Click += ButtonClick;
                    }
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Islem_Yap fr = new Islem_Yap();
            fr.lbl_koltuk_no.Text = btn.Name.Split('_')[1];
            fr.ShowDialog();
            int durum = fr.cmb_islem.SelectedIndex + 1;
            string cinsiyet = fr.cmb_musteri_cinsiyet.Text;
            if (fr.tamam == 1)
            {
                MyData.DataTable_Yolcular_Insert(Convert.ToInt32(fr.lbl_koltuk_no.Text), durum, fr.txt_mustari.Text, cinsiyet, Convert.ToDateTime(fr.lbl_tarih.Text), fr.lbl_gorevli.Text);

                switch (durum)
                {
                    case 1:
                        btn.BackColor = Color.YellowGreen;
                        break;
                    case 2:
                        btn.BackColor = Color.Yellow;
                        break;
                }
                if (cinsiyet == "Erkek")
                    btn.Text += " E";
                else
                    btn.Text += " K";
                dgv_update();
            }


        }
        private void dgv_update()
        {
            dataGridView1.DataSource = MyData.table;
        }
    }
}
