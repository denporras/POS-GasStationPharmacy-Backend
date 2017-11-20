using Npgsql;
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
        /**
        * GET request that get all roles
        */ 
        public List<role> GetAllRoles()
        {
            var query = "SELECT * FROM getRoles();";
            List<role> pharma = _context.Database.SqlQuery<role>(query).ToList();
            return pharma;
        }
        /**
        * GET request that get one role
        */
        public role GetRole(int id_role)
        {
            var query = "SELECT * FROM getRole(" + id_role + ");";
            role _role = _context.Database.SqlQuery<role>(query).FirstOrDefault();
            return _role;
        }
        /**
        * POST request that inserts a role
        */ 
        public Response insertRole(role rol)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT insertRole('" + rol.name + "', '" + rol.description + "');";
                _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;
        }
        /**
        * PUT request that updates a role
        */ 
        public Response updateRole(int id_role, role rol)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updateRole(" + id_role + ", '" + rol.name + "', '" + rol.description + "')";
                _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;
        }
        /**
        * DELETE request that disable a role
        */  
        public Response deleteRole(int id_role)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deleteRole(" + id_role + ")";
                _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;
        }

    }
}