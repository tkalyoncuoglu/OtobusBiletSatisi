using OtobusBiletSatisi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusBiletSatisi.Data
{
    public interface IOtobusRepository
    {
        List<Otobus> GetAll();
    }
}
