using System;
using System.Collections.Generic;
using System.Text;

namespace TaxServices
{
    public class TaxesRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public double amount { get; set; }
        public double shipping { get; set; }

    }

}
