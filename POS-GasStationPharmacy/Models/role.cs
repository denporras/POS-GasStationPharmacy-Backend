using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    [Table("role", Schema = "public")]
    public class role
    {
        [Key]
        public int id_role { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
    }
}