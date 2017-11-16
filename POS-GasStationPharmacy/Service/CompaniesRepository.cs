using Npgsql;
using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class CompaniesRepository
    {
        PGSDbContext _context;
        public CompaniesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<company> GetAllCompanies()
        {
            var query = "SELECT * FROM getCompanies();";
            List<company> pharma = _context.Database.SqlQuery<company>(query).ToList();
            return pharma;
        }

        public company GetCompany(int id_company)
        {
            var query = "SELECT * FROM getCompany(" + id_company + ");";
            company sub = _context.Database.SqlQuery<company>(query).FirstOrDefault();
            return sub;
        }

        public Response insertCompany(company cop)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT insertCompany(" + cop.id_company + ", '" + cop.name + "');";
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

        public Response updateCompany(int id_company, company cop)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updateCompany(" + id_company + ", '" + cop.name + "');";
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

        public Response deleteCompany(int id_company)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deleteCompany(" + id_company + ")";
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