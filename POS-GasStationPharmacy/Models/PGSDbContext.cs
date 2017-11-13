using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Models
{
    public class PGSDbContext : DbContext
    {
        public PGSDbContext() : base(nameOrConnectionString: "DefaultConnection") { }
    }
}