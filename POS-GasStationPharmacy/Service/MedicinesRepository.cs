using Npgsql;
using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace POS_GasStationPharmacy.Service
{
    public class MedicinesRepository
    {
        PGSDbContext _context;
        public MedicinesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<medicine> GetAllMedicines()
        {
            var query = "SELECT * FROM getmedicines()";
            List<medicine> med = _context.Database.SqlQuery<medicine>(query).ToList();
            return med;
        }

        public medicine GetMedicineById (int id)
        {
            var query = "SELECT * FROM getmedicine(" + id + ");";
            medicine med = _context.Database.SqlQuery<medicine>(query).FirstOrDefault();
            return med;
        }

        public Response insertMedicine(medicine med)
        {
         
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT addmedicine('" + med.name + "'," + med.price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + med.pharmaceutical_house + ");";
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

        public Response updateMedicine(int id, medicine med)
        {
           
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatemedicine(" + id + ", '" + med.name + "'," + med.price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + med.pharmaceutical_house + "');";
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

        public Response deleteMedicine(int id)
        {
          
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletemedicine(" + id + ");";
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