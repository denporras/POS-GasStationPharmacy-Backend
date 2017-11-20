using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace POS_GasStationPharmacy.Models
{
    public class sale_by_payment_type
    {
        public List<sale> credit { get; set; }
        public List<sale> cash { get; set; }
    }
}