using Npgsql;
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
        /**
        * GET request that get all subsidiaries
        */
        public List<subsidiary> GetAllRoles()
        {
            var query = "SELECT * FROM getSubsidiaries();";
            List<subsidiary> pharma = _context.Database.SqlQuery<subsidiary>(query).ToList();
            return pharma;
        }
        /**
        * GET request that get one subsidiary
        */
        public subsidiary GetSubsidiary(int id_subsidiary)
        {
            var query = "SELECT * FROM getSubsidiary(" + id_subsidiary + ");";
            subsidiary sub = _context.Database.SqlQuery<subsidiary>(query).FirstOrDefault();
            return sub;
        }
        /**
        * POST request that inserts a subsidiary
        */
        public Response insertSubsidiary(subsidiary sub)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT insertSubsidiary('" + sub.name + "', '" + sub.description + "', " + sub.company + ");";
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
        * PUT request that updates a subsidiary
        */
        public Response updateSubsidiary(int id_subsdiary, subsidiary sub)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updateSubsidiary(" + id_subsdiary + ", '" + sub.name + "', '" + sub.description + "', " + sub.company + ");";
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
        * DELETE request that disable a subsidiary
        */  
        public Response deleteSubsidiary(int id_subsidiary)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deleteSubsidiary(" + id_subsidiary + ")";
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