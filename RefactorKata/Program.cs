﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var Conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            var cmd = Conn.CreateCommand();
            cmd.CommandText = "select * from Products";

            var reader = cmd.ExecuteReader();
            var products = new List<Product>();

            while (reader.Read())
            {
                var prod = new Product();
                prod.Name = reader["Name"].ToString();
                products.Add(prod);
            }
            Conn.Dispose();
            Console.WriteLine("Products Loaded!");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name);
            }
        }
    }
}



