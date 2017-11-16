using NpgsqlTypes;
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

        public medicine_by_subsidiary GetMedicinebySubsidiaryBySubsidiary(int id)
        {
            var query = "SELECT * FROM getmedicine_by_subsidiary_by_subsidiary(" + id + ");";
            medicine_by_subsidiary ms = _context.Database.SqlQuery<medicine_by_subsidiary>(query).FirstOrDefault();
            return ms;
        }

        public medicine_by_subsidiary GetMedicinebySubsidiaryByMedicine(int id)
        {
            var query = "SELECT * FROM getmedicine_by_subsidiary_by_medicine(" + id + ");";
            medicine_by_subsidiary ms = _context.Database.SqlQuery<medicine_by_subsidiary>(query).FirstOrDefault();
            return ms;
        }

        public void insertMedicinebySubsidiary(medicine_by_subsidiary ms)
        {
            var query = "SELECT addmedicine_by_subsidiary(" + ms.medicine + "," + ms.subsidiary + "," + ms.quantity + ");";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateMedicinebySubsidiary(int idm, int ids, medicine_by_subsidiary ms)
        {
            var query = "SELECT updatemedicine_by_subsidiary(" + idm + "," + ids + "," + ms.quantity + "');";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteMedicinebySubsidiary(int idm, int ids)
        {
            var query = "SELECT deletemedicine_by_subsidiary(" + idm + "," + ids + ");";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}