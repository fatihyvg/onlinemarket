using System;
using System.Configuration;
using System.Data.SqlClient;

namespace OnlineMarket
{
    public class VeritabanıAyarları
    {
        private static SqlConnection baglantı;
        private static string baglantıayar = ConfigurationManager.ConnectionStrings["market"].ConnectionString;
 
        public static SqlConnection BaglantıAl()
        {
            baglantı = new SqlConnection(baglantıayar);
            return baglantı;
 
        }
          public VeritabanıAyarları()
          {
 
          }
    }
}