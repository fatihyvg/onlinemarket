using System;
using System.Data;
using System.Data.SqlClient;

namespace OnlineMarket
{
    public class Servis:IServis
    {
          SqlConnection baglantılar;
          public Servis()
        {
            baglantılar = VeritabanıAyarları.BaglantıAl();
        }
 
        public void KullaniciEkle(string isim, string soyisim, string kulisim, string sifre)
        {
            if (baglantılar.State.ToString() == "Closed")
            {
                baglantılar.Open();
            }

            string sorgula = "INSERT INTO Kullanıcılar VALUES ('" + isim + "','" + soyisim + "','" + kulisim + "','" + sifre + "');";
 
            SqlCommand cmd = new SqlCommand(sorgula, baglantılar);
            cmd.ExecuteNonQuery();
 
            baglantılar.Close();
        }
        //public void SepetEkle(string urisim, string urfiyat)
        //{
        //    if (baglantılar.State.ToString() == "Closed")
        //    {
        //        baglantılar.Open();
        //    }
        //    string sorgula = "INSERT INTO Yonetim VALUES ('" + urisim + "','" + urfiyat + "');";
        //    SqlCommand cmd = new SqlCommand(sorgula, baglantılar);
        //    cmd.ExecuteNonQuery();
        //    baglantılar.Close();
        //}
        //public void Silme(string id)
        //{
        //    if(baglantılar.State.ToString()=="Closed")
        //    {
        //        baglantılar.Open();
        //    }
        //    string sorgula = "DELETE FROM Yonetim WHERE id='" + id + "';";

        //    SqlCommand cmd=new SqlCommand (sorgula,baglantılar);
        //    cmd.ExecuteNonQuery();
        //    baglantılar.Close();
        //}
        public DataTable DetaylariAl(string email)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("isim", typeof(String)));
            dt.Columns.Add(new DataColumn("soyisim", typeof(String)));
            dt.Columns.Add(new DataColumn("email", typeof(String)));

            if (baglantılar.State.ToString() == "Closed")
            {
                baglantılar.Open();
            }

            string query = "SELECT isim,soyisim,email FROM Kullanıcılar WHERE email='" + email + "';";

            SqlCommand cmd = new SqlCommand(query, baglantılar);
            SqlDataReader oku = cmd.ExecuteReader();

            if (oku.HasRows)
            {
                while (oku.Read())
                {
                    dt.Rows.Add(oku["isim"], oku["soyisim"],oku["email"]);
                }
            }

            oku.Close();
            baglantılar.Close();
            return dt;

        }
        public DataTable UrunBilgileriAl(string barkod)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("urismi",typeof(String));
            dt.Columns.Add("urfiyati", typeof(String));

            if(baglantılar.State.ToString()=="Closed")
            {
                baglantılar.Open();
            }
            string sorgula = "SELECT urismi,urfiyati FROM Yonetim WHERE urkodu='" + barkod + "';";
            SqlCommand cmd = new SqlCommand(sorgula,baglantılar);
            SqlDataReader oku = cmd.ExecuteReader();
            if(oku.HasRows)
            {
                while(oku.Read())
                {
                    dt.Rows.Add(oku["urismi"], oku["urfiyati"]);
                }
            }
            oku.Close();
            baglantılar.Close();
            return dt;
        }
 
        public bool YetkiGirisi(string email, string sifre)
        {
            bool yetki= false;
 
            if (baglantılar.State.ToString() == "Closed")
            {
                baglantılar.Open();
            }

            string sorgula = "SELECT id FROM Kullanıcılar  WHERE email='" + email + "' AND sifre='" + sifre + "';";
 
            SqlCommand cmd = new SqlCommand(sorgula, baglantılar);
            SqlDataReader oku = cmd.ExecuteReader();
 
            if (oku.HasRows)
            {
                yetki = true;
            }
 
            oku.Close();
            baglantılar.Close();
 
            return yetki;
 
        }
    }
  }