﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
      [Table("medicine", Schema = "public")]
    public class medicine
    {
        [Key]
        public int id_medicine { get; set; }
        public String name { get; set; }
        public float price { get; set; }
        public int pharmaceutical_house { get; set; }
    }
}