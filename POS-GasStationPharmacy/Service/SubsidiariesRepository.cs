using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class SubsidiariesRepository
    {
        PGSDbContext _context;
        public SubsidiariesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<subsidiary> GetAllRoles()
        {
            var query = "SELECT * FROM getSubsidiaries();";
            List<subsidiary> pharma = _context.Database.SqlQuery<subsidiary>(query).ToList();
            return pharma;
        }

        public subsidiary GetSubsidiary(int id_subsidiary)
        {
            var query = "SELECT * FROM getSubsidiary(" + id_subsidiary + ");";
            subsidiary sub = _context.Database.SqlQuery<subsidiary>(query).FirstOrDefault();
            return sub;
        }

        public void insertSubsidiary(subsidiary sub)
        {
            var query = "SELECT insertSubsidiary('" + sub.name + "', '" + sub.description + "', " + sub.company + ");";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateSubsidiary(int id_subsdiary, subsidiary sub)
        {
            var query = "SELECT updateSubsidiary(" + id_subsdiary + ", '" + sub.name + "', '" + sub.description + "', " + sub.company + ");";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteSubsidiary(int id_subsidiary)
        {
            var query = "SELECT deleteSubsidiary(" + id_subsidiary + ")";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}