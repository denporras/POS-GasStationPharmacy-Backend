using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class RolesRepository
    {
        PGSDbContext _context;
        public RolesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<role> GetAllRoles()
        {
            var query = "SELECT * FROM getRoles();";
            List<role> pharma = _context.Database.SqlQuery<role>(query).ToList();
            return pharma;
        }
    }
}