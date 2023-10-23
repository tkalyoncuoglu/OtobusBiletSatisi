using OtobusBiletSatisi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtobusBiletSatisi.Data
{
    public class YolcuRepository : IYolcuRepository
    {
        public static DataTable table_yolcu = CreateTable();
        public static DataTable CreateTable()
        {
            var table_yolcu = new DataTable("Yolcular");
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
            return table_yolcu;
        }

        public void Delete(int id)
        {
            var row = table_yolcu.AsEnumerable().Where(x => x.Field<int>("ID") == id).First();
            table_yolcu.Rows.Remove(row);
        }

        public Yolcu Get(int id)
        {
            var result = (from DataRow myRow in table_yolcu.Rows
             where (int)myRow["ID"] == id
             select new Yolcu
             {
                 Id = myRow.Field<int>("ID"),
                 KoltukNo = myRow.Field<int>("Koltuk_No"),
                 Cinsiyet = myRow.Field<string>("Cinsiyet").ToString().Substring(0, 1),
                 Durum = myRow.Field<int>("Durum"),
                 AdSoyad = myRow.Field<string>("Ad_Soyad"),
                 IslemTarihi = myRow.Field<DateTime>("Islem_Tarih"),
                 IslemYapan = myRow.Field<string>("Islem_Yapan")
             }).FirstOrDefault();

            return result;
        }

        public List<Yolcu> GetAll(string otobusPlaka)
        {
            var result = (from DataRow myRow in table_yolcu.Rows
                          where (string)myRow["Otobus_Plaka"] == otobusPlaka
                          select new Yolcu
                          {
                              Id = myRow.Field<int>("ID"),
                              KoltukNo = myRow.Field<int>("Koltuk_No"),
                              Cinsiyet = myRow.Field<string>("Cinsiyet").ToString().Substring(0, 1),
                              Durum = myRow.Field<int>("Durum"),
                              AdSoyad = myRow.Field<string>("Ad_Soyad"),
                              IslemTarihi = myRow.Field<DateTime>("Islem_Tarih"),
                              IslemYapan = myRow.Field<string>("Islem_Yapan"),
                              OtobusPlaka = myRow.Field<string>("Otobus_Plaka")
                          }).ToList();

            return result;
        }

        public Yolcu Save(Yolcu yolcu)
        {
            var row = table_yolcu.NewRow();
            row["Koltuk_No"] = yolcu.KoltukNo;
            row["Durum"] = yolcu.Durum;
            row["Ad_Soyad"] = yolcu.AdSoyad;
            row["Cinsiyet"] = yolcu.Cinsiyet;
            row["Islem_Tarih"] = yolcu.IslemTarihi;
            row["Islem_Yapan"] = yolcu.IslemYapan;
            row["Otobus_Plaka"] = yolcu.OtobusPlaka;
            table_yolcu.Rows.Add(row);
            return new Yolcu
            {
                Id = row.Field<int>("ID"),
                KoltukNo = row.Field<int>("Koltuk_No"),
                Cinsiyet = row.Field<string>("Cinsiyet").ToString().Substring(0, 1),
                Durum = row.Field<int>("Durum"),
                AdSoyad = row.Field<string>("Ad_Soyad"),
                IslemTarihi = row.Field<DateTime>("Islem_Tarih"),
                IslemYapan = row.Field<string>("Islem_Yapan"),
                OtobusPlaka = row.Field<string>("Otobus_Plaka")

            };

        }

        public void Update(Yolcu yolcu)
        {
            var row = table_yolcu.AsEnumerable().Where(x => x.Field<int>("ID") == yolcu.Id).First();
            row["Koltuk_No"] = yolcu.KoltukNo;
            row["Durum"] = yolcu.Durum;
            row["Ad_Soyad"] = yolcu.AdSoyad;
            row["Cinsiyet"] = yolcu.Cinsiyet;
            row["Islem_Tarih"] = yolcu.IslemTarihi;
            row["Islem_Yapan"] = yolcu.IslemYapan;
            row["Otobus_Plaka"] = yolcu.OtobusPlaka;
            

        }
    }
}
