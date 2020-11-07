using PNG.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast.Selectors;

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

<<<<<<< HEAD
        public bool AddCategory(Category category)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO tblCategory(categoryName,statusId) VALUES (@categoryName,3)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
                    
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
            
        }

        
        public bool UpdateCategory(Category category)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE tblCategory SET categoryName=@categoryName,statusId=@statusId WHERE categoryId=@categoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@categoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@statusId", category.StatusID);
                    cmd.Parameters.AddWithValue("@categoryId", category.CategoryID);
                    int i = cmd.ExecuteNonQuery();
                    
                    if (i >= 1)
                    {
                        result = true;
=======
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
>>>>>>> 1560703586b6d43c69d985195d7c52ed841c823c
                    }
                }
                catch (Exception e)
                {
<<<<<<< HEAD
                    Console.WriteLine(e);
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public void DeleteCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE tblCategory WHERE categoryId=@categoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@categoryId", category.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


=======

                    Console.WriteLine(e);
                }             
            }
            return category;
        }
>>>>>>> 1560703586b6d43c69d985195d7c52ed841c823c
    }
}