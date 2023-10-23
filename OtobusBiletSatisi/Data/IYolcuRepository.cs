using OtobusBiletSatisi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusBiletSatisi.Data
{
    public interface IYolcuRepository
    {
        Yolcu Get(int id);
        List<Yolcu> GetAll(string otobusPlaka);
        void Update(Yolcu yolcu);
        Yolcu Save(Yolcu yolcu);
        void Delete(int id);

    }
}
