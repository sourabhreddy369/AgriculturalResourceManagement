using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
namespace AgriculturalResourceManagement.Models
{
    // Model for parks data. These classes can be obtained by either using 
    // the Visual Studio editor (right-click -> Paste Special -> Paste Json as Classes)
    // or sites such as JsonToCSHarp
    public class Timing
    {
        [Key]
        public int executing { get; set; }
        public string unit { get; set; }
    }

    public class Total
    {
        [Key]
        public int record_count { get; set; }
    }

    public class Info
    {
        public Timing timing { get; set; }
        [Key]
        public string result_coverage { get; set; }
        public Total total { get; set; }
    }

    public class Report
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
    }

    public class Reports
    {
        [Key]
        public string status { get; set; }
        public Info info { get; set; }
        public List<Report> data { get; set; }
    }
}