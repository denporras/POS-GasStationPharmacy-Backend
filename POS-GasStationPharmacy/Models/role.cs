using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class role
    {
        public int id_role { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}