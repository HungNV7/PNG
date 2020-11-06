using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNG.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string CategoryID { get; set; }
        public int StatusID { get; set; }

        public Product()
        {
        }

        public Product(string productID, string productName, int quantity, float price, string description, string image, string categoryID, int statusId)
        {
            ProductID = productID;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Description = description;
            Image = image;
            CategoryID = categoryID;
            StatusID = statusId;
        }
    }
}