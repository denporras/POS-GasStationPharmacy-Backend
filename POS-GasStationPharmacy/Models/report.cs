using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class report
    {
        public int id { get; set; }
        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }
        public int subsidiary { get; set; }
        public int cashier { get; set; }
        public string rep { get; set; }
    }
}