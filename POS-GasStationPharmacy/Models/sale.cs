using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace POS_GasStationPharmacy.Models
{
       [Table("sale", Schema = "public")]
    public class sale
    {
        [Key]
        public int id_sale { get; set; }
        public float total { get; set; }
        public DateTime sale_date { get; set; }
        public int client { get; set; }
        public int payment_type { get; set; }
        public int employee { get; set; }
        public int subsidiary { get; set; }
        public int cash { get; set; }
    }
}