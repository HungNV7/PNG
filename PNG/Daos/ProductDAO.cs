﻿using PNG.Models;
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
                string sql = "SELECT * FROM tblProduct P, tblCategory C WHERE P.categoryId = C.categoryId AND C.statusId =3 AND P.statusId = 3 AND quantity > 0";
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

        public List<Product> Search(string search)
        {
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblProduct P, tblCategory C WHERE P.categoryId = C.categoryId AND C.statusId =3 AND P.statusId = 3 AND quantity > 0 AND productName LIKE @name";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", "%" + search + "%");
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

        public List<Product> SearchForAdmin(string search)
        {
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblProduct WHERE productName LIKE @name";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", "%" + search + "%");
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
                string sql = "SELECT * FROM tblProduct P, tblCategory C WHERE P.categoryId = C.categoryId AND C.statusId = 3 AND P.statusId = 3 AND P.categoryId = @id AND quantity > 0";
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
                string sql = "SELECT * FROM tblProduct P, tblCategory C WHERE P.categoryId = C.categoryId AND C.statusId =3 AND P.statusId = 3 AND productId = @id AND quantity > 0";
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

        public bool AddNewProduct(Product p)
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO tblProduct(productName, quantity, price, categoryId, description, image, statusId) VALUES(@name, @quantity, @price, @categoryId, @description, @image, @statusId)";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", p.ProductName);
                command.Parameters.AddWithValue("@quantity", p.Quantity);
                command.Parameters.AddWithValue("@price", p.Price);
                command.Parameters.AddWithValue("@categoryId", p.CategoryID);
                command.Parameters.AddWithValue("@description", string.IsNullOrEmpty(p.Description)?"": p.Description);
                command.Parameters.AddWithValue("@image", p.Image);
                command.Parameters.AddWithValue("@statusId", 3);
                try
                {
                    conn.Open();
                    check = command.ExecuteNonQuery() > 0;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
            return check;
        }

        public List<Product> GetAllForAdmin()
        {
            List<Product> list = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblProduct";
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

        public bool Update(Product p)
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE tblProduct SET productName = @name, quantity = @quantity, price = @price, categoryId = @categoryId, description = @description, image = @image, statusId = @statusId WHERE productId = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@image", p.Image);
                if (string.IsNullOrEmpty(p.Image))
                {
                    sql = "UPDATE tblProduct SET productName = @name, quantity = @quantity, price = @price, categoryId = @categoryId, description = @description, statusId = @statusId WHERE productId = @id";
                    command = new SqlCommand(sql, conn);
                }
                command.Parameters.AddWithValue("@name", p.ProductName);
                command.Parameters.AddWithValue("@quantity", p.Quantity);
                command.Parameters.AddWithValue("@price", p.Price);
                command.Parameters.AddWithValue("@categoryId", p.CategoryID);
                command.Parameters.AddWithValue("@description", string.IsNullOrEmpty(p.Description) ? "" : p.Description);
                command.Parameters.AddWithValue("@statusId", p.StatusID);
                command.Parameters.AddWithValue("@id", p.ProductID);
                try
                {
                    conn.Open();
                    check = command.ExecuteNonQuery() > 0;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
            return check;
        }

        public bool Delete(string id)
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE tblProduct SET statusId = 4 WHERE productId = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    check = command.ExecuteNonQuery() > 0;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
            return check;
        }

        public List<string> CheckQuantity(Cart cart)
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    foreach (Product item in cart.CartDetail.Values)
                    {
                        SqlDataReader reader = null;
                        string sql = "SELECT quantity FROM tblProduct WHERE productId = @id";
                        SqlCommand command = new SqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@id", item.ProductID);
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                int quantity = Convert.ToInt32(reader["quantity"].ToString());
                                if(quantity < item.Quantity)
                                {
                                    list.Add(item.ProductName + " has only " + quantity + " in store.");
                                }
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return list;
        }

        public bool UpdateQuanity(Cart cart)
        {
            bool check = true;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    foreach (Product item in cart.CartDetail.Values)
                    {
                        string sql = "UPDATE tblProduct SET quantity = quantity - @quantity WHERE productId = @id";
                        SqlCommand command = new SqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@quantity", item.Quantity);
                        command.Parameters.AddWithValue("@id", item.ProductID);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    check = false;
                    Console.WriteLine(e.ToString());
                }
            }
            return check;
        }
    }
}