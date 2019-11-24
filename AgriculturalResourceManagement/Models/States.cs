using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace AgriculturalResourceManagement.Models
{
   
    public class State
    {
        [Key]
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

    public class States
    {
        [Key]
        public string status { get; set; }
        public Info info { get; set; }
        public List<State> data { get; set; }
    }
}
