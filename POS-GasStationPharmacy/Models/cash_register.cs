using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
     [Table("cash_register", Schema = "public")]
    public class cash_register
    {
        [Key]
        public int cash { get; set; }
        [Key]
        public int subsidiary { get; set; }
        [Key]
        public int employee { get; set; }
        [Key]
        public DateTime initial_time { get; set; }
        public DateTime final_time { get; set; }
        public decimal initial_cash { get; set; }
        public decimal final_cash { get; set; }

    }
}