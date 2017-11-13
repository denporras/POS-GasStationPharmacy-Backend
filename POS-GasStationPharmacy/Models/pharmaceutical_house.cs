﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    [Table("pharmaceutical_house", Schema = "public")]
    public class pharmaceutical_house
    {
        [Key]
        public int id_pharmaceutical_house { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }
}