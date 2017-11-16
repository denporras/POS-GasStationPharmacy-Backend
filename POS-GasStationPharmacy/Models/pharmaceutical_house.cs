using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class pharmaceutical_house
    {
        public int id_pharmaceutical_house { get; set; }
        public string name { get; set; }
    }
}