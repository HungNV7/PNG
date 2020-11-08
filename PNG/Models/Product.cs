using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PNG.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Display(Name = "Category")]
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