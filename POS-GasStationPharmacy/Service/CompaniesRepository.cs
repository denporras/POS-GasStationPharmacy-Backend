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

        public void insertCompany(company cop)
        {
            var query = "SELECT insertCompany(" + cop.id_company + ", '" + cop.name + "');";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateCompany(int id_company, company cop)
        {
            var query = "SELECT updateCompany(" + id_company + ", '" + cop.name + "');";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteCompany(int id_company)
        {
            var query = "SELECT deleteCompany(" + id_company + ")";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}