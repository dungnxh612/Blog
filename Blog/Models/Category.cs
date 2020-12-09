using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Category_Name { get; set; }
        public List<Category> cateList { get; set; }
    }
}