using System.Collections.Generic;

namespace telefon_rehberi
{
    public class KullaniciListesi{
        public List<Kullanici> kullaniciListesi = new List<Kullanici>();
        public KullaniciListesi(){
            this.kullaniciListesi.Add(new Kullanici("Goksel","Onal","123321123"));
            this.kullaniciListesi.Add(new Kullanici("denek2","2denek","111011"));
            this.kullaniciListesi.Add(new Kullanici("denek3","3denek", "0110"));
            this.kullaniciListesi.Add(new Kullanici("denek4","4denek","001100"));
            this.kullaniciListesi.Add(new Kullanici("denek5","5denek","111011"));
        }
    }
}
