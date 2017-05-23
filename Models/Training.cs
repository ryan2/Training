using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Training4.Models
{
    public class Training
    {
        public int ID { get; set; }
        public string Office { get; set; }
        public string Role { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Course { get; set; }
        public string Format { get; set; }
        public string Time { get; set; }
        [Required]
        public string Url { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> CEU { get; set; }
        public string Contractor { get; set; }
        public string Instructor { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public decimal Stars { get; set; }
        public string WReview { get; set; }
        public Boolean Recommend { get; set; }
    }
    public class Review
    {
        public int ID { get; set; }
        public string R { get; set;}
        [Required]
        public decimal Stars { get; set; }
        public int Training_ID { get; set; }
    }
}