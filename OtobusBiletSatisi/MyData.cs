using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OtobusBiletSatisi
{
    public static class MyData
    {
        public static DataTable table;
        public static DataTable DataTable_Yolcular()
        {
            table = new DataTable("Yolcular");
            table.Columns.Add(new DataColumn("yol_RECno", typeof(int)));
            table.Columns.Add(new DataColumn("yol_Koltuk_No", typeof(int)));
            table.Columns.Add(new DataColumn("yol_Koltuk_Durum", typeof(int))); // 0 boş, 1 satış, 2 rezerve
            table.Columns.Add(new DataColumn("yol_Koltuk_Ad_Soyad", typeof(string)));
            table.Columns.Add(new DataColumn("yol_Koltuk_Cinsiyet", typeof(string)));
            table.Columns.Add(new DataColumn("yol_Koltuk_Islem_Tarih", typeof(DateTime)));
            table.Columns.Add(new DataColumn("yol_Koltuk_Islem_Yapan", typeof(string)));
            return table;
        }


        public static void DataTable_Yolcular_Insert(int koltuk_no, int durum, string ad_soyad, string cinsiyet, DateTime tarih, string gorevli)
        {
            int recno = 0;
            try
            {
                recno = table.Rows.Count + 1;
            }
            catch (NullReferenceException)
            {
                recno = 1;
            }
            table.Rows.Add(recno, koltuk_no, durum, ad_soyad, cinsiyet, tarih, gorevli);
        }
    }
}
