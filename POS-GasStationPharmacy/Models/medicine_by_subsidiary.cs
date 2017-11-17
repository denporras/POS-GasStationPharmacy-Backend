using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace POS_GasStationPharmacy.Models
{
      [Table("medicine_by_subsidiary", Schema = "public")]
    public class medicine_by_subsidiary
    {
        [Key]
        public int medicine { get; set; }
        [Key]
        public int subsidiary { get; set; }
        public int quantity { get; set; }
        public int stock_promedio { get; set; }
        public int stock_minimo { get; set; }
    }
}