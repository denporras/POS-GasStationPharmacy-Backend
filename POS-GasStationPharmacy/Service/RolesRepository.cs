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

        public role GetRole(int id_role)
        {
            var query = "SELECT * FROM getRole(" + id_role + ");";
            role _role = _context.Database.SqlQuery<role>(query).FirstOrDefault();
            return _role;
        }

        public void insertRole(role rol)
        {
            var query = "SELECT insertRole('" + rol.name + "', '" + rol.description + "');";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateRole(int id_role, role rol)
        {
            var query = "SELECT updateRole(" + id_role + ", '" + rol.name + "', '" + rol.description + "')";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteRole(int id_role)
        {
            var query = "SELECT deleteRole(" + id_role + ")";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

    }
}