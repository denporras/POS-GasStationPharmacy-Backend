using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class Response
    {
        public Boolean success { get; set; }
        public string code { get; set; }
        public string message { get; set; }

    }
}