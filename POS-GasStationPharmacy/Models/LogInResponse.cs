using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class LogInResponse
    {
        public Boolean success { get; set; }
        public string message { get; set; }
        public employee information { get; set; }
    }
}