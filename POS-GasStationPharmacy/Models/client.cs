using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class client
    {
        public int id_client { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string first_last_name { get; set; }
        public string second_last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string phone { get; set; }
        public string residence { get; set; }
    }
}