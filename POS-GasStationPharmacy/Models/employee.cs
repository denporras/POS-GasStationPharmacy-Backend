using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class employee
    {
        public int id_employee { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string first_last_name { get; set; }
        public string second_last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string residence { get; set; }
        public int role { get; set; }
        public int subsidiary { get; set; }
        public int company { get; set; }
    }
}