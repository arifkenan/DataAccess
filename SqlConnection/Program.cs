using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlConnectionTest
{
    internal class Program
    {

         static string baglanticumlesi = @"Server=.;
                                Database=Northwind;
                                Trusted_Connection=True;";

        static void Main(string[] args)
        {
            //KayitSayisi();
             //SqlBaglanti();
            GetShippers();
            //SqlKayitEkle();
        }

        private static void GetShippers()
        {
            List<Shipper> kargocular = new List<Shipper>();

            string sqlKomut = @"Select * from Shippers";
            SqlConnection sqlConnection = new SqlConnection(baglanticumlesi);
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sqlKomut, sqlConnection);
                sqlConnection.Open();

                // ExecuteScaler geriye sabit bir deger dondugunde kullanilir
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr["CompanyName"] + " " + rdr["Phone"]);
                    Shipper kargocu = new Shipper();
                    kargocu.ShipperID = (int)rdr["ShipperId"];
                    kargocu.CompanyName = (string)rdr["CompanyName"];
                    kargocu.Phone = (string)rdr["Phone"];

                    kargocular.Add(kargocu);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {

                sqlConnection.Close();
            }
        }

        //public static void SqlKayitEkle()
        //{
        //    string sqlkomut = @"Insert into shippers (CompanyName, Phone)
        //                        Values('Mng Kargo','2124440999')";
        //}

        private static void SqlBaglanti() 
        {
            string sqlkomut = "Select * from Customers";
            string constr = @"Server=.;
                                Database=Northwind;
                                Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sqlkomut, sqlConnection);
            
            sqlConnection.Open();
            
            
            Console.WriteLine("Baglanti Durumu: "+ sqlConnection.State);
            SqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["CustomerId"]+" "+rdr["CompanyName"]+" " + rdr["ContactName"]);
            }


            //SqlCommand cmd = new SqlCommand(sqlkomut, db);

            Console.WriteLine("Hello World!");

            sqlConnection.Close();
            Console.WriteLine("Baglanti Durumu: " + sqlConnection.State);
        }

        public static void KayitSayisi()
        {
            string sqlkomut = "Select count(*) from Customers";
            string constr = @"Server=.;
                                Database=Northwind;
                                Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sqlkomut, sqlConnection);

            sqlConnection.Open();
            int sonuc = (int)sqlCommand.ExecuteScalar();
            if (sonuc>0)
            {
                Console.WriteLine("toplam sipariş sayisi"+sonuc);
            }
            else
            {
                Console.WriteLine("başarısız işlem");
            }
            sqlConnection.Close();
        }

    }
}
