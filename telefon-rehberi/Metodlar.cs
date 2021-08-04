using System;
using System.Collections.Generic;
using System.Threading;

namespace telefon_rehberi
{
    public class Metodlar{
        public void KisiEkle(List<Kullanici> kullanicilar, Kullanici kisi){
            kullanicilar.Add(kisi);
            Console.WriteLine("\nKullanıcı başarıyla eklendi.");
        }

        public void KisiSil(List<Kullanici> kullanicilar, Kullanici kisi){
            kullanicilar.Remove(kisi);
        }

        public bool KisiGuncelle(List<Kullanici> kullanicilar, Kullanici kisi){
            Console.WriteLine("\nLütfen yapmak istediğiniz güncelleme işlemini seçiniz :) ");
            Console.WriteLine(" (1) Kullanıcının Ismini Güncellemek\n (2) Kullanıcının Soyismini Güncellemek\n (3) Kullanıcının Telefonunu Güncellemek\n (4) Ana Menüye Dön");
            
            int islem = int.Parse(Console.ReadLine());
            switch (islem)
            {
                case 1:
                    Console.Write("Yeni ismi giriniz: ");
                    string yeniIsim = Console.ReadLine();
                    kisi.Isim = yeniIsim;
                    break;
                case 2:
                    Console.Write("Yeni Soyismi giriniz: ");
                    string yeniSoyIsim = Console.ReadLine();
                    kisi.SoyIsim = yeniSoyIsim;
                    break;
                case 3:
                    Console.Write("Yeni Telefonu giriniz: ");
                    string yeniTelefon = Console.ReadLine();
                    kisi.Telefon = yeniTelefon;
                    break;
                case 4:
                    return false;
                default:
                    break;
            }
            return true;
        }

        public bool Arama(List<Kullanici> kullanicilar, string isim){
           bool bulundu = false;
           foreach (var item in kullanicilar)
           {
                if(String.Equals(item.Isim, isim) || String.Equals(item.SoyIsim, isim))
                    bulundu = true;
           }
           return bulundu;
        }

        public bool AramaTelefon(List<Kullanici> kullanicilar, string telefon){
           bool bulundu = false;
           foreach (var item in kullanicilar)
           {
                if(String.Equals(item.Telefon, telefon))
                    bulundu = true;
           }
           return bulundu;
        }

        public void NumaraKaydet(List<Kullanici> kullanicilar){
            Console.Write("Lütfen isim giriniz            : ");
            string isim = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz         : ");
            string soyIsim = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz: ");
            string telefon = Console.ReadLine();
            
            Console.WriteLine("Kullanıcı ekleniyor..");
            Thread.Sleep(3000);
            Kullanici yeniKullanıcı = new Kullanici(isim, soyIsim, telefon);
            KisiEkle(kullanicilar, yeniKullanıcı);
        }        

        public void NumaraSil(List<Kullanici> kullanicilar){
            Console.Write("\nLütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string silinecekKisi = Console.ReadLine();
            foreach (var item in kullanicilar)
            {
                if(String.Equals(item.Isim,silinecekKisi) || String.Equals(item.SoyIsim,silinecekKisi)){
                    Console.WriteLine("{0} {1} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", item.Isim, item.SoyIsim);
                    string onay = Console.ReadLine();
                    if(String.Equals(onay,"y")){
                        Console.WriteLine("Kullanıcı siliniyor..");
                        Thread.Sleep(3000);
                        KisiSil(kullanicilar, item);
                        Console.WriteLine("\nKullanıcı başarıyla silindi.");
                        return;
                    }else if(String.Equals(onay,"n")){
                        Console.WriteLine("İşlem onaylanmadı.");
                        Console.WriteLine("\nAna menüye dönülüyor..");
                        Thread.Sleep(3000);
                        return;
                    }else{
                        Console.WriteLine("Hatalı işlem, y veya n karakteri giriniz.");
                        NumaraSil(kullanicilar);
                    }                
                }
            }       
            if(!Arama(kullanicilar,silinecekKisi)){
                Console.WriteLine("\nAradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1) ");
                Console.WriteLine("* Yeniden denemek için      : (2) ");
                int siradakiİslem = int.Parse(Console.ReadLine());
                if(siradakiİslem == 1){
                    return;
                }else if(siradakiİslem == 2){
                    NumaraSil(kullanicilar);
                }else{
                    Console.WriteLine("\nHatalı işlem, 1 veya 2 karakteri giriniz.");
                    NumaraSil(kullanicilar);
                }
            }
        }

        public void NumaraGuncelle(List<Kullanici> kullanicilar){
            Console.Write("\nLütfen bilgilerini güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string guncellenecekKisi = Console.ReadLine();
            foreach (var item in kullanicilar)
            {
                if(String.Equals(item.Isim, guncellenecekKisi) || String.Equals(item.SoyIsim, guncellenecekKisi)){
                    string eskiIsim = item.Isim;
                    string eskiSoyIsim = item.SoyIsim;
                    if(KisiGuncelle(kullanicilar, item)){
                        Console.WriteLine("{0} {1} isimli kişi rehberden güncellenmek üzere, onaylıyor musunuz ?(y/n)", eskiIsim, eskiSoyIsim);
                        string onay = Console.ReadLine();
                        if(String.Equals(onay,"y")){
                            Console.WriteLine("Kullanıcı güncelleniyor..");
                            Thread.Sleep(3000);
                            Console.WriteLine("\nKullanıcı başarıyla güncellendi");
                            return;
                        }else if(String.Equals(onay,"n")){
                            Console.WriteLine("İşlem onaylanmadı.");    
                            Console.WriteLine("\nAna menüye dönülüyor..");
                            Thread.Sleep(3000);
                            return;
                        }else{
                            Console.WriteLine("\nHatalı işlem, y veya n karakteri giriniz.");
                            NumaraGuncelle(kullanicilar);
                        }               
                    }else{
                        return;
                    }
                }
            }
            if(!Arama(kullanicilar,guncellenecekKisi)){
                Console.WriteLine("\nAradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için : (1) ");
                Console.WriteLine("* Yeniden denemek için           : (2) ");
                int siradakiİslem = int.Parse(Console.ReadLine());
                if(siradakiİslem == 1){
                    return;
                }else if(siradakiİslem == 2){
                    NumaraGuncelle(kullanicilar);
                }else{
                    Console.WriteLine("\nHatalı işlem, 1 veya 2 karakteri giriniz.");
                    NumaraGuncelle(kullanicilar);
                }
            }
        }

        public void RehberiListele(List<Kullanici> kullanicilar){
            Console.WriteLine("Rehber taranıyor..");
            Thread.Sleep(3000);
            Console.WriteLine("\nTelefon Rehberi\n**********************************************\n");
            foreach (var item in kullanicilar)
            {
                Console.WriteLine("İsim    :{0}",item.Isim);
                Console.WriteLine("Soyisim :{0}",item.SoyIsim);
                Console.WriteLine("Telefon :{0}",item.Telefon);
                Console.WriteLine("-");
            }
        }

        public void DetayliArama(List<Kullanici> kullanicilar){
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n**********************************************");
            Console.WriteLine(" (1) İsim veya soyisime göre arama yapmak\n (2) Telefon numarasına göre arama yapmak\n (3) Ana Menüye Dön");
            int tip = int.Parse(Console.ReadLine());
            if(tip == 1){
                Console.Write("Aramak istediğiniz ismi veya soyismi girin: ");
                string adSoyad = Console.ReadLine();
                Console.WriteLine("Kullanıcı aranıyor..");
                Thread.Sleep(3000);
                foreach (var item in kullanicilar)
                {
                    if(String.Equals(item.Isim, adSoyad) || String.Equals(item.SoyIsim, adSoyad)){
                        Console.WriteLine("\nİsim    :{0}",item.Isim);
                        Console.WriteLine("Soyisim :{0}",item.SoyIsim);
                        Console.WriteLine("Telefon :{0}",item.Telefon);
                    }
                }
                if(!Arama(kullanicilar,adSoyad)){
                    Console.WriteLine("\nAradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen tekrar deneyiniz.\n");
                    DetayliArama(kullanicilar);
                }  
            }else if(tip == 2){
                Console.Write("Aramak istediğiniz telefon numarasını girin: ");
                string telefon = Console.ReadLine();
                Console.WriteLine("Kullanıcı aranıyor..");
                Thread.Sleep(3000);
                foreach (var item in kullanicilar)
                {
                    if(String.Equals(item.Telefon, telefon)){
                        Console.WriteLine("\nİsim    :{0}",item.Isim);
                        Console.WriteLine("Soyisim :{0}",item.SoyIsim);
                        Console.WriteLine("Telefon :{0}",item.Telefon);
                    }
                }
                if(!AramaTelefon(kullanicilar,telefon)){
                    Console.WriteLine("\nAradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen tekrar deneyiniz.\n");
                    DetayliArama(kullanicilar);
                }
            }
            else if(tip == 3){
                return;
            }else{
                Console.WriteLine("\nHatalı işlem, 1 veya 2 karakteri giriniz.");
                DetayliArama(kullanicilar);
            }
        }
    }
}