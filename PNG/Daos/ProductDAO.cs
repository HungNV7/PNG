using PNG.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PNG.Daos
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private ProductDAO()
        {
        }

        public static ProductDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }

        private string _connectionString = ConfigurationManager.ConnectionStrings["PNG"].ConnectionString;

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblProduct WHERE statusId = 3";
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string productId = reader["productId"].ToString();
                            string productName = reader["productName"].ToString();
                            int quantity = Convert.ToInt32(reader["quantity"].ToString());
                            double price = Convert.ToDouble(reader["price"]);
                            string description = reader["description"].ToString();
                            string image = reader["image"].ToString();
                            String categoryID = reader["categoryId"].ToString();
                            int statusID = Convert.ToInt32(reader["statusId"].ToString());

                            list.Add(new Product(productId, productName, quantity, (float)price, description, image, categoryID, statusID));
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }
            return list;
        }

        public List<Product> GetProduct(string categoryId)
        {
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblProduct WHERE statusId = 3 AND categoryId = @id AND quantity > 0";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", categoryId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string productId = reader["productId"].ToString();
                            string productName = reader["productName"].ToString();
                            int quantity = Convert.ToInt32(reader["quantity"].ToString());
                            double price = Convert.ToDouble(reader["price"]);
                            string description = reader["description"].ToString();
                            string image = reader["image"].ToString();
                            String categoryID = reader["categoryId"].ToString();
                            int statusID = Convert.ToInt32(reader["statusId"].ToString());

                            list.Add(new Product(productId, productName, quantity, (float)price, description, image, categoryID, statusID));
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }
            return list;
        }

        public Product GetOneProduct(string id)
        {
            Product p = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblProduct WHERE statusId = 3 AND productId = @id AND quantity > 0";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string productId = reader["productId"].ToString();
                            string productName = reader["productName"].ToString();
                            int quantity = Convert.ToInt32(reader["quantity"].ToString());
                            double price = Convert.ToDouble(reader["price"]);
                            string description = reader["description"].ToString();
                            string image = reader["image"].ToString();
                            String categoryID = reader["categoryId"].ToString();
                            int statusID = Convert.ToInt32(reader["statusId"].ToString());

                            p = new Product(productId, productName, quantity, (float)price, description, image, categoryID, statusID);
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }
            return p;
        }
    }
}