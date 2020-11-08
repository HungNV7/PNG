using PNG.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PNG.Daos
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private CategoryDAO()
        {
        }

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        private string _connectionString = ConfigurationManager.ConnectionStrings["PNG"].ConnectionString;

        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM tblCategory WHERE statusId = 3";
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string categoryID = reader["categoryId"].ToString();
                            string categoryName = reader["categoryName"].ToString();
                            int statusID = Convert.ToInt32(reader["statusId"].ToString());

                            list.Add(new Category(categoryID, categoryName, statusID));
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

        public Category GetOneCategory(string id)
        {
            Category category = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT categoryName FROM tblCategory WHERE categoryId = @id AND statusId = 3";              
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();      
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            string categoryName = reader["categoryName"].ToString();
                            category = new Category(id, categoryName, 3);
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }             
            }
            return category;
        }

        public bool AddNewCategory(Category c)
        {
            bool check = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO tblCategory(categoryName, statusId) VALUES(@name, @id)";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", 3);
                command.Parameters.AddWithValue("@name", c.CategoryName);
                try
                {
                    conn.Open();
                    check = command.ExecuteNonQuery() > 0;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }
            return check;
        }
    }
}