using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNG.Models
{
    public class Cart
    {
        public string CartID { get; set; }
        public Account Account { get; set; }
        public float TotalPrice { get; set; }
        public string PaymenType { get; set; }
        public int StatusID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public Dictionary<string, Product> CartDetail { get; set; }


        public Cart()
        {

        }

        public void Add(Product p)
        {
            if(CartDetail == null)
            {
                CartDetail = new Dictionary<string, Product>();
            }
            int quantity = 1;
            if (CartDetail.ContainsKey(p.ProductID))
            {
                quantity += CartDetail[p.ProductID].Quantity;
            }
            p.Quantity = quantity;
            CartDetail[p.ProductID] = p;
        }
    }
}