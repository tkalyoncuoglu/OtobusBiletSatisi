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
    public partial class Islem_Yap2 : Form
    {
        public Yolcu Data {  get; set; }
        public Islem_Yap2()
        {
            InitializeComponent();
        }

        private void Islem_Yap_Load(object sender, EventArgs e)
        {
            lbl_koltuk_no.Text = Data.KoltukNo.ToString();
            txt_mustari.Text = Data.AdSoyad;
            txt_mustari.Enabled = false;
            cmb_musteri_cinsiyet.SelectedIndex = Data.Cinsiyet == "E" ? 0 : 1;
            cmb_musteri_cinsiyet.Enabled = false;
            lbl_tarih.Text = Data.IslemTarihi.ToString();
            cmb_islem.SelectedIndex = 0;
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btn_kadyet_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
            Close();
        }
    }
}
