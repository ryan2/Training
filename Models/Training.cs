using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training4.Models
{
    public class Training
    {
        public int ID { get; set; }
        public string Office { get; set; }
        public string Role { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Topic { get; set; }
        public string Course { get; set; }
        public string Format { get; set; }
        public string Time { get; set; }
        public string Url { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> CEU { get; set; }
        public string Contractor { get; set; }
        public string Instructor { get; set; }
        public string Location { get; set; }
        public decimal Stars { get; set; }
        public string Review { get; set; }
        public Boolean Recommend { get; set; }
    }
}