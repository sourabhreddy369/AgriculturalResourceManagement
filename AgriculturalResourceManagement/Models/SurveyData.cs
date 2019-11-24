using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalResourceManagement.Models
{
    public class SurveyData
    {
        public int year { get; set; }
        public string state { get; set; }
        public string report { get; set; }
        public string farmtype { get; set; }
        public string category { get; set; }
        public string category_value { get; set; }
        public string category2 { get; set; }
        public string category2_value { get; set; }
        public string variable_id { get; set; }
        public string variable_name { get; set; }
        public int variable_sequence { get; set; }
        public object variable_level { get; set; }
        public object variable_group { get; set; }
        public object variable_group_id { get; set; }
        public string variable_unit { get; set; }
        public string variable_description { get; set; }
        public bool variable_is_invalid { get; set; }
        public double estimate { get; set; }
        public object median { get; set; }
        public string statistic { get; set; }
        public double? rse { get; set; }
        public int unreliable_estimate { get; set; }
        public int decimal_display { get; set; }
    }

    public class SurveyDatas
    {
        public string status { get; set; }
        public Info info { get; set; }
        public List<SurveyData> data { get; set; }
    }
}
