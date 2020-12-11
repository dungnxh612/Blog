using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string News { get; set; }
        public int Category_ID { get; set; }
        public Boolean Status { get; set; }
        public int Position_ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Img { get; set; }
        public List<Blogs> AllBlog { get; set; }
    }

    public class Blg
    {
        public int Id { get; set; }
        public string News { get; set; }
        public int Category_ID { get; set; }
        public Boolean Status { get; set; }
        public string Position { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Img { get; set; }
        public List<Blg> AllBlog { get; set; }
    }
}