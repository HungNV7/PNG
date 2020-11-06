using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNG.Models
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int StatusID { get; set; }

        public Category()
        {

        }

        public Category(string id, string name, int statusID)
        {
            CategoryID = id;
            CategoryName = name;
            StatusID = statusID;
        }
    }
}