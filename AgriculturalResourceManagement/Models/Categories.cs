using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalResourceManagement.Models
{
    public class Category
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int sequence { get; set; }
    }

    public class Categories
    {
        [Key]
        public string status { get; set; }
        public Info info { get; set; }
        public List<Category> data { get; set; }
    }
}
