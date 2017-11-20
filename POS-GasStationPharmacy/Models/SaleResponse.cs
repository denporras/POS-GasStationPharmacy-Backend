using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class SaleResponse
    {
        public Boolean success { get; set; }
        public int id_inserted { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}