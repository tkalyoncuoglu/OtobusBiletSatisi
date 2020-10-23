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
            MyData.DataTable_Otobus();



            cmb_otobus.DataSource = MyData.table_otobus;
            cmb_otobus.DisplayMember = "Plaka";

        }

        void DuzenKur()
        {
            DataTable dt = MyData.table_yolcu;
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
                        int id = ++say;
                        nesne.Name = "buton_" + id;
                        string cinsiyet = "";
                        int durum = 0;

                        var results = from DataRow myRow in dt.Rows
                                      where (int)myRow["Koltuk_No"] == id & (string)myRow["Otobus_Plaka"] == cmb_otobus.Text
                                      select new
                                      {
                                          cinsiyet = myRow.Field<string>("Cinsiyet").ToString().Substring(0, 1),
                                          durum = myRow.Field<int>("Durum"),
                                      };
                        try
                        {
                            var resultsList = results.ToList();
                            cinsiyet = resultsList[0].cinsiyet;
                            durum = resultsList[0].durum;
                        }
                        catch (InvalidOperationException)
                        {

                        }
                        catch (ArgumentOutOfRangeException)
                        {

                        }

                        nesne.Text = id.ToString() + " " + cinsiyet;
                        nesne.BackColor = Color.LightGray;
                        switch (durum)
                        {
                            case 1:
                                nesne.BackColor = Color.GreenYellow;
                                break;
                            case 2:
                                nesne.BackColor = Color.Yellow;
                                break;
                        }

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
                MyData.DataTable_Yolcular_Insert(
                    Convert.ToInt32(fr.lbl_koltuk_no.Text)
                    , durum
                    , fr.txt_mustari.Text
                    , cinsiyet
                    , Convert.ToDateTime(fr.lbl_tarih.Text)
                    , fr.lbl_gorevli.Text
                    , cmb_otobus.Text);
                btn.BackColor = Color.LightGray;
                switch (durum)
                {
                    case 1:
                        btn.BackColor = Color.GreenYellow;
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
            var results = MyData.table_yolcu.AsEnumerable().Where(myRow => myRow.Field<string>("Otobus_Plaka") == cmb_otobus.Text);
            DataView view = results.AsDataView();
            dataGridView1.DataSource = view;


            //MyData.table_yolcu;
            //var results = from DataRow myRow in MyData.table_yolcu.Rows
            //              where (string)myRow["yol_Otobus_Plaka"] == cmb_otobus.Text
            //              select myRow;
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
