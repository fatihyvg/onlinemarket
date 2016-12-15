using System;
using System.Data;

namespace OnlineMarket
{
   public interface IServis
    {
        void KullaniciEkle(string isim, string soyisim, string kulisim, string sifre);
        //void SepetEkle(string urisim, string urfiyat);
        //void Silme(string id);
        bool YetkiGirisi(string email, string sifre);
        DataTable UrunBilgileriAl(string barkod);
        DataTable DetaylariAl(string email);
    }
}
