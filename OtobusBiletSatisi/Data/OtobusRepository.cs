using OtobusBiletSatisi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusBiletSatisi.Data
{
    public class OtobusRepository : IOtobusRepository
    {
        public static DataTable table_otobus = CreateTable();
        public static DataTable CreateTable()
        {
            table_otobus = new DataTable("Otobüsler");
            var idColumn = new DataColumn("ID", typeof(int));
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;
            idColumn.Unique = true;
            table_otobus.Columns.Add(idColumn);
            table_otobus.Columns.Add(new DataColumn("Plaka", typeof(string)));
            table_otobus.Columns.Add(new DataColumn("Koltuk_Adet", typeof(int))); // 0 boş, 1 satış, 2 rezerve

            var row = table_otobus.NewRow();
            row["Plaka"] = "46 OTO 46";
            row["Koltuk_Adet"] = 47;
            table_otobus.Rows.Add(row);
            row = table_otobus.NewRow();
            row["Plaka"] = "46 OTO 47";
            row["Koltuk_Adet"] = 47;
            table_otobus.Rows.Add(row);
            row = table_otobus.NewRow();
            row["Plaka"] = "46 OTO 48";
            row["Koltuk_Adet"] = 47;
            table_otobus.Rows.Add(row);
            row = table_otobus.NewRow();
            row["Plaka"] = "46 OTO 49";
            row["Koltuk_Adet"] = 47;
            table_otobus.Rows.Add(row);

            return table_otobus;
        }
        public List<Otobus> GetAll()
        {
            return table_otobus.AsEnumerable().Select(x => 
            new Otobus{ 
                Id = x.Field<int>("ID"),
                Plaka = x.Field<string>("Plaka"),
                YolcuAdet = x.Field<int>("Koltuk_Adet")
            }).ToList();
        }
    }
}
