using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusBiletSatisi.Models
{
    public class Yolcu
    {
        public int Id { get; set; }
        public int KoltukNo { get; set; }
        public int Durum { get; set; }
        public string AdSoyad { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime IslemTarihi { get; set; }
        public string IslemYapan { get; set; }
        public string OtobusPlaka { get; set; }
    }
}