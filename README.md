Dersin URL'si: https://mustafabukulmez.com/2020/10/23/c-otobus-bilet-satis-uygulamasi-basit-duzey/

# OtobusBiletSatisi
* Basit düzeyde Otobüs Bilet Satış Uygulaması örneğidir. 
* Bu projede dinamik olarak Button nesneleri üretilerek otobüslerdeki koltuk düzeni yapıldı.
* Dinamik üretilen Button nesnelerin Click eventleri içerisinde de basit işlem ekranı açılarak satış/rezerve işlemi yapıldı.
* Yapılan işleme göre Button'un rengi değiştiriliyor ve seçilen cinsiyet Button'un Text'ine yazılıyor.
* Datalar bir DataTable içerisinde tutularak DataGridView'de gösterildi.
* *NOT: Yukarıda url'sini verdiğim derste buradan sonrası yer almamaktadır.
* Yeni > MyData.cs 'e otobüsler için bir DataTable eklendi ve örnek 4 otobüs eklendi.
* Yeni > AnaForm'a otobüs seçimi için combobox eklendi. txt_duzen nesnesini visible =true/false işlemi için contextmenustrip eklendi.
* Yeni > ComboBox'tan seçilen otobüse göre koltuklar satış/rezerve durumuna göre getiriliyor. Ayrıca DataGridView'de görüntülen veriler de seçilmiş olan otobüse göre geliyor.

NOT: Bu projenin veritabanı yoktur. Tüm veriler program içerisinde tutulur. Program kapandığında da veriler kaybolur. Bu projeyi geliştirmek isteyenler, bir veritabanına bağlayarak benim DataTable'lar ile yaptığım işlemleri veritabanı ile yapabilirler.

# Bu proje, aşağıdaki iki derste anlatılan konular kullanarak hazırlanmıştır... 
* https://mustafabukulmez.com/2020/07/15/c-datatable-example-ornek-datatable/
* https://mustafabukulmez.com/2020/07/08/c-dinamik-button-ve-dinamik-duzen/

**Umarım faydası olur.
