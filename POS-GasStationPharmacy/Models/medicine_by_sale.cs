using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{

       [Table("medicine_by_sale", Schema = "public")]
    public class medicine_by_sale
    {
        [Key]
        public int medicine { get; set; }
        [Key]
        public int sale { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
    }
}