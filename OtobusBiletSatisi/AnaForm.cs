using OtobusBiletSatisi.Data;
using OtobusBiletSatisi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtobusBiletSatisi
{
    public partial class AnaForm : Form
    {
       
        private IYolcuRepository yolcuRepository = new YolcuRepository();

        private IOtobusRepository otobusRepository = new OtobusRepository();

        public AnaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            panel1.Width = 207;

            cmb_otobus.DataSource = otobusRepository.GetAll();
            cmb_otobus.DisplayMember = "Plaka";

        }

        void DuzenKur()
        {
           
            int say = 0;
            panel1.Controls.Clear();
            int olcu = 41;

            var results = yolcuRepository.GetAll(cmb_otobus.Text).ToDictionary(x => x.KoltukNo);

            for (int i = 0; i < txt_duzen.Lines.Count(); i++)// textbox satırları arasında
            {
                for (int j = 0; j < txt_duzen.Lines[i].Count(); j++) // bir satırdaki karakterler arasında
                {
                    string satir = txt_duzen.Lines[i]; // bir satırı aldık
                    if (satir[j] == '*') // satırdaki j index'ine denk gelen ifade * ise
                    {
                        Button nesne = new Button();
                        nesne.Width = nesne.Height = 40;
                        nesne.Left = olcu * j;// butonun nerede duracağı
                        nesne.Top = olcu * i; // butonun nerede duracağı


                        // Burada buttonları elips şeklinde yapmak istedim. 
                        // tam istediğim gibi elips olmadı ama daha hoş olduğu gibi geldi. :D Bu sebeple olduğu gibi bıraktım. 
                        GraphicsPath p = new GraphicsPath();
                        p.AddEllipse(1, 1, nesne.Width, nesne.Height);
                        nesne.Region = new Region(p);


                        int koltukNo = ++say;
                        nesne.Name = "buton_" + koltukNo;
                        string cinsiyet = "";
                        int durum = -1;

                        if(results.ContainsKey(koltukNo))
                        {
                            cinsiyet = results[koltukNo].Cinsiyet;
                            durum = results[koltukNo].Durum;
                            nesne.Tag = results[koltukNo];
                        }
                        else
                        {
                            nesne.Tag = null;
                        }
                        
                        nesne.Text = koltukNo.ToString();
                        nesne.BackColor = Color.Tomato;
                        switch (durum)
                        {
                            case 0:
                                nesne.BackColor = Color.Yellow;
                                nesne.Text = koltukNo.ToString() + " " + cinsiyet;
                                break;
                            case 1:
                                nesne.BackColor = Color.GreenYellow;
                                nesne.Text = koltukNo.ToString() + " " + cinsiyet;
                                break;
                            case 2:
                                nesne.Text = koltukNo.ToString();
                                nesne.BackColor = Color.Black;
                                nesne.ForeColor = Color.White;
                                break;
                        }

                        panel1.Controls.Add(nesne);
                        nesne.Click += ButtonClick;
                    }
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            var yolcu = btn.Tag as Yolcu;

            if (yolcu == null)
            {
                Islem_Yap fr = new Islem_Yap();
                fr.lbl_koltuk_no.Text = btn.Name.Split('_')[1];
                var r = fr.ShowDialog();
                int durum = fr.cmb_islem.SelectedIndex;
                string cinsiyet = fr.cmb_musteri_cinsiyet.SelectedItem as string;
                if (r == DialogResult.OK)
                {
                    var data = fr.Data;
                    data.OtobusPlaka = cmb_otobus.Text;
                    var y = yolcuRepository.Save(data);
                    btn.BackColor = Color.Tomato;
                    btn.Tag = y;
                    switch (durum)
                    {
                        case 0:
                            btn.BackColor = Color.Yellow;
                            if (cinsiyet == "Erkek") btn.Text += " E"; else btn.Text += " K";
                            break;
                        case 1:
                            btn.BackColor = Color.GreenYellow;
                            if (cinsiyet == "Erkek") btn.Text += " E"; else btn.Text += " K";
                            break;

                        case 2:
                            btn.BackColor = Color.Black;
                            btn.ForeColor = Color.White;
                            break;
                    }
                }
            }
            else
            {
                Islem_Yap2 fr = new Islem_Yap2();
                fr.Data = yolcu;
                var r = fr.ShowDialog();
                if (r == DialogResult.OK)
                {
                    yolcuRepository.Delete(yolcu.Id);
                }
                DuzenKur();
            }
            dgv_update();

        }
        private void dgv_update()
        {
            var results = yolcuRepository.GetAll(cmb_otobus.Text);
            dataGridView1.DataSource = results;
        }

        private void cmb_otobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_update();
            DuzenKur();
        }

        private void koltukDüzenPatternAlanıGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_duzen.Visible == false)
                txt_duzen.Visible = true;
            else
                txt_duzen.Visible = false;
        }

       
    }
}
