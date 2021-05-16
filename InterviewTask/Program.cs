using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace InterviewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME");
            Console.WriteLine("*******");
            ReandAndInsertToDB();
        }

        enum Condition
        {
            New =1, 
            Used =2
        }

        static void ReandAndInsertToDB()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FVN1B19\MSSQLSERVER1;Initial Catalog=Inventory;Integrated Security=True"))
                {
                    string line;
                    con.Open();
                    using (StreamReader file = new StreamReader(@"C:\Users\Administrator\OneDrive\Documents\sample.txt"))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] fields = line.Split(',');
                            
                            SqlCommand cmd = new SqlCommand("INSERT INTO InventoryDetail(Id, sku, product_name, quantity, price, condition, isbn) VALUES (@Id, @sku, @product_name, @quantity, @price, @condition, @isbn)", con);
                            cmd.Parameters.AddWithValue("@id", fields[0].ToString());
                            cmd.Parameters.AddWithValue("@sku", fields[1].ToString());
                            cmd.Parameters.AddWithValue("@product_name", fields[2].ToString());
                            cmd.Parameters.AddWithValue("@quantity", fields[3].ToString());
                            cmd.Parameters.AddWithValue("@price", fields[4].ToString());
                            cmd.Parameters.AddWithValue("@condition", Enum.Parse(typeof(Condition), fields[5].ToString()));
                            cmd.Parameters.AddWithValue("@isbn", fields[6].ToString());

                            cmd.ExecuteNonQuery();

                        }
                        Console.WriteLine("Inserted Successfully.");
                        string
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            }
    }
}
