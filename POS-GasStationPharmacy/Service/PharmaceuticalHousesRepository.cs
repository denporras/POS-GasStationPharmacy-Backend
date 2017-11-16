using Npgsql;
using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace POS_GasStationPharmacy.Service
{
    public class PharmaceuticalHousesRepository
    {
        PGSDbContext _context;
        public PharmaceuticalHousesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<pharmaceutical_house> GetAllPharmaceuticalHouses()
        {
            var query = "SELECT * FROM getPharmaceuticalHouses();";
            List<pharmaceutical_house> pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).ToList();
            return pharma;
        }

        public pharmaceutical_house GetPharmaceuticalHousebyId(int id)
        {
            var query = "SELECT * FROM getPharmaceuticalHouse("+ id +");";
            pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();
            return pharma;
        }

        public Response AddPharmaceuticalHouse(pharmaceutical_house ph) 
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT addpharmaceuticalhouse('" + ph.name + "');";
                pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;
        }

        public Response UpdatePharmaceuticalHouse(int id, pharmaceutical_house ph)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatepharmaceuticalhouse(" + id + ",'" + ph.name + "');";
                pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;

        }

        public Response DeletePharmaceuticalHouse(int id)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletepharmaceuticalhouse(" + id + ");";
                pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();
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