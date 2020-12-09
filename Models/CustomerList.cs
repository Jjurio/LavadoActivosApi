using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class CustomerList
    {
        public int customerID { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public string reportNumber { get; set; }
        public string rosNumber { get; set; }
        public string reportDate { get; set; }
        public string status { get; set; }
        public int ncaso { get; set; }
    }
}
