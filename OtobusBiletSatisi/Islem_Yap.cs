using OtobusBiletSatisi.Models;
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
    public partial class Islem_Yap : Form
    {
        public Yolcu Data { get; set; }
        public Islem_Yap()
        {
            InitializeComponent();
        }

        private void Islem_Yap_Load(object sender, EventArgs e)
        {
            lbl_tarih.Text = DateTime.Now.ToString();
            cmb_musteri_cinsiyet.SelectedIndex = 0;
            cmb_islem.SelectedIndex = 0;
          
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btn_kadyet_Click(object sender, EventArgs e)
        {
            
            if (txt_mustari.Text.Length > 0 && cmb_musteri_cinsiyet.SelectedIndex >= 0 && cmb_islem.SelectedIndex >= 0)
            {
                Data = new Yolcu();
                Data.AdSoyad = txt_mustari.Text;
                Data.Cinsiyet = (string)cmb_musteri_cinsiyet.SelectedItem;
                Data.Durum = (int)cmb_islem.SelectedIndex;
                Data.KoltukNo = Convert.ToInt32(lbl_koltuk_no.Text);
                Data.IslemTarihi = Convert.ToDateTime(lbl_tarih.Text);
                Data.IslemYapan = lbl_gorevli.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("*'lı alanları boş bırakamazsınız.", "Zorunlu Alan", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
    }
}
