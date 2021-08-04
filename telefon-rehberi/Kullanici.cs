namespace telefon_rehberi
{
    public class Kullanici{
        private string isim;
        private string soyIsim;
        private string telefon;

        public Kullanici(string isim, string soyIsim, string telefon){
            this.isim = isim;
            this.soyIsim = soyIsim;
            this.telefon = telefon;
        }

        public string Isim {get => isim; set => isim = value;}
        public string SoyIsim {get => soyIsim; set => soyIsim = value;}
        public string Telefon {get => telefon; set => telefon = value;}
    }
}
