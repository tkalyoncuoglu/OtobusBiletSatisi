using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusBiletSatisi.Models
{
    public class Otobus
    {
        public int Id { get; set; }
        public string Plaka {  get; set; }
        public int YolcuAdet { get; set; }
    }
}
