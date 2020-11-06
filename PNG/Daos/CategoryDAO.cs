﻿using PNG.Models;
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
    }
}