using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OtobusBiletSatisi
{
    public static class MyData
    {
        public static DataTable table_yolcu;
        public static void DataTable_Yolcular()
        {
            table_yolcu = new DataTable("Yolcular");
            var idColumn = new DataColumn("ID", typeof(int));
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;
            idColumn.Unique = true;
            table_yolcu.Columns.Add(idColumn);
            table_yolcu.Columns.Add(new DataColumn("Koltuk_No", typeof(int)));
            table_yolcu.Columns.Add(new DataColumn("Durum", typeof(int))); // 0 boş, 1 satış, 2 rezerve, 3 kullanılamaz
            table_yolcu.Columns.Add(new DataColumn("Ad_Soyad", typeof(string)));
            table_yolcu.Columns.Add(new DataColumn("Cinsiyet", typeof(string)));
            table_yolcu.Columns.Add(new DataColumn("Islem_Tarih", typeof(DateTime)));
            table_yolcu.Columns.Add(new DataColumn("Islem_Yapan", typeof(string)));
            table_yolcu.Columns.Add(new DataColumn("Otobus_Plaka", typeof(string)));

        }

        public static void DataTable_Yolcular_Insert(int koltuk_no, int durum, string ad_soyad, string cinsiyet, DateTime tarih, string gorevli, string plaka)
        {
            var row = table_yolcu.NewRow();
            row["Koltuk_No"] = koltuk_no;
            row["Durum"] = durum;
            row["Ad_Soyad"] = ad_soyad;
            row["Cinsiyet"] = cinsiyet;
            row["Islem_Tarih"] = tarih;
            row["Islem_Yapan"] = gorevli;
            row["Otobus_Plaka"] = plaka;
            table_yolcu.Rows.Add(row);
        }


        public static DataTable table_otobus;
        public static void DataTable_Otobus()
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
        }
    }
}
