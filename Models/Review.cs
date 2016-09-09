using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training4.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int Training { get; set; }
        public int R1 { get; set; }
        public int R2 { get; set; }
        public int R3 { get; set; }
        public int R4 { get; set; }
        public int R5 { get; set; }
        public int R6 { get; set; }
        public int R7 { get; set; }
        public int R8 { get; set; }
        public int R9 { get; set; }
        public int Rtotal { get; set; }
        public string positive { get; set; }
        public string negative { get; set; }
    }
}