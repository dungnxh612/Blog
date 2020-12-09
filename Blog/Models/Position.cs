using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Position
    {
        public int ID { get; set; }
        public string Position_Name { get; set; }
        public List<Position> posList { get; set; }
    }
}