using System;

namespace telefon_rehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            Metodlar metodlar = new Metodlar();
            KullaniciListesi kullanicilar = new KullaniciListesi();
            
            while (true)
            {
                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz :) ");
                Console.WriteLine(" *******************************************");
                Console.WriteLine(" (1) Yeni Numara Kaydetmek\n (2) Varolan Numarayı Silmek\n (3) Varolan Numarayı Güncelleme\n (4) Rehberi Listelemek\n (5) Rehberde Arama Yapmak\n (6) Çıkış Yap");
                int islem = int.Parse(Console.ReadLine());
                switch (islem)
                {
                    case 1:
                        metodlar.NumaraKaydet(kullanicilar.kullaniciListesi);
                        break;
                    case 2:
                        metodlar.NumaraSil(kullanicilar.kullaniciListesi);
                        break;
                    case 3:
                        metodlar.NumaraGuncelle(kullanicilar.kullaniciListesi);
                        break;
                    case 4:
                        metodlar.RehberiListele(kullanicilar.kullaniciListesi);
                        break;
                    case 5:
                        metodlar.DetayliArama(kullanicilar.kullaniciListesi);
                        break;
                    case 6:
                        return;
                    default:
                        break;
                } 
            }
        }
    }
}
