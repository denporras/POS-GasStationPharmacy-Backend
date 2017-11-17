using Npgsql;
using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class MedicinesbySubsidiariesRepository
    {
         PGSDbContext _context;
        public MedicinesbySubsidiariesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<medicine_by_subsidiary> GetAllMedicinesbySubsidiaries()
        {
            var query = "SELECT * FROM getmedicines_by_subsidiaries()";
            List<medicine_by_subsidiary> ms = _context.Database.SqlQuery<medicine_by_subsidiary>(query).ToList();
            return ms;
        }

        public medicine_by_subsidiary GetMedicinebySubsidiaryById (int idm, int ids)
        {
            var query = "SELECT * FROM getmedicine_by_subsidiary(" + idm +","+ ids + ");";
            medicine_by_subsidiary ms = _context.Database.SqlQuery<medicine_by_subsidiary>(query).FirstOrDefault();
            return ms;
        }

        public List<medicine_by_subsidiary> GetMedicinebySubsidiaryBySubsidiary(int id)
        {
            var query = "SELECT * FROM getmedicine_by_subsidiary_by_subsidiary(" + id + ");";
            List<medicine_by_subsidiary> ms = _context.Database.SqlQuery<medicine_by_subsidiary>(query).ToList();
            return ms;
        }

        public List<medicine_by_subsidiary> GetMedicinebySubsidiaryByMedicine(int id)
        {
            var query = "SELECT * FROM getmedicine_by_subsidiary_by_medicine(" + id + ");";
            List<medicine_by_subsidiary> ms = _context.Database.SqlQuery<medicine_by_subsidiary>(query).ToList();
            return ms;
        }

        public Response insertMedicinebySubsidiary(medicine_by_subsidiary ms)
        {
            
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT addmedicine_by_subsidiary(" + ms.medicine + "," + ms.subsidiary + "," + ms.quantity + "," + ms.stock_promedio + "," + ms.stock_minimo + ");";
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

        public Response updateMedicinebySubsidiary(int idm, int ids, medicine_by_subsidiary ms)
        {
           
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatemedicine_by_subsidiary(" + idm + "," + ids + "," + ms.quantity + "," + ms.stock_promedio + "," + ms.stock_minimo + "');";
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

        public Response deleteMedicinebySubsidiary(int idm, int ids)
        {
           
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletemedicine_by_subsidiary(" + idm + "," + ids + ");";
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