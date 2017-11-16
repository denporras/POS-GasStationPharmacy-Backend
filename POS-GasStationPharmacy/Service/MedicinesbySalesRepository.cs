﻿using NpgsqlTypes;
using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class MedicinesbySalesRepository
    {
         PGSDbContext _context;
        public MedicinesbySalesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<medicine_by_sale> GetAllMedicinesbySales()
        {
            var query = "SELECT * FROM getmedicines_by_sales()";
            List<medicine_by_sale> ms = _context.Database.SqlQuery<medicine_by_sale>(query).ToList();
            return ms;
        }

        public medicine_by_sale GetMedicinebySaleById (int idm, int ids)
        {
            var query = "SELECT * FROM getmedicine_by_sale(" + ids +","+ idm + ");";
            medicine_by_sale ms = _context.Database.SqlQuery<medicine_by_sale>(query).FirstOrDefault();
            return ms;
        }

        public medicine_by_sale GetMedicinebySaleBySale(int id)
        {
            var query = "SELECT * FROM getmedicine_by_sale_by_sale(" + id + ");";
            medicine_by_sale ms = _context.Database.SqlQuery<medicine_by_sale>(query).FirstOrDefault();
            return ms;
        }

        public medicine_by_sale GetMedicinebySaleByMedicine(int id)
        {
            var query = "SELECT * FROM getmedicine_by_sale_by_medicine(" + id + ");";
            medicine_by_sale ms = _context.Database.SqlQuery<medicine_by_sale>(query).FirstOrDefault();
            return ms;
        }

        public void insertMedicinebySale(medicine_by_sale ms)
        {
            var query = "SELECT addmedicine_by_sale(" + ms.sale + "," + ms.medicine + "," + ms.price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + ms.quantity + ");";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateMedicinebySale(int idm, int ids, medicine_by_sale ms)
        {
            var query = "SELECT updatemedicine_by_sale(" + ids + "," + idm + "," + ms.price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + ms.quantity + "');";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteMedicinebySale(int idm, int ids)
        {
            var query = "SELECT deletemedicine_by_sale(" + ids + "," + idm + ");";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}