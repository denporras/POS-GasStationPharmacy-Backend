using Npgsql;
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
        /**
        * GET request that get all medicines by sale
        */ 
        public List<medicine_by_sale> GetAllMedicinesbySales()
        {
            var query = "SELECT * FROM getmedicines_by_sales()";
            List<medicine_by_sale> ms = _context.Database.SqlQuery<medicine_by_sale>(query).ToList();
            return ms;
        }
        /**
      * GET request that get one medicine by sale
      */ 
        public medicine_by_sale GetMedicinebySaleById (int idm, int ids)
        {
            var query = "SELECT * FROM getmedicine_by_sale(" + ids +","+ idm + ");";
            medicine_by_sale ms = _context.Database.SqlQuery<medicine_by_sale>(query).FirstOrDefault();
            return ms;
        }
        /**
      * GET request that get one medicine by sale
      */ 
        public List<medicine_by_sale> GetMedicinebySaleBySale(int id)
        {
            var query = "SELECT * FROM getmedicine_by_sale_by_sale(" + id + ");";
            List<medicine_by_sale> ms = _context.Database.SqlQuery<medicine_by_sale>(query).ToList();
            return ms;
        }
        /**
      * GET request that get one medicine by sale
      */ 
        public List<medicine_by_sale> GetMedicinebySaleByMedicine(int id)
        {
            var query = "SELECT * FROM getmedicine_by_sale_by_medicine(" + id + ");";
            List<medicine_by_sale> ms = _context.Database.SqlQuery<medicine_by_sale>(query).ToList();
            return ms;
        }
        /**
        * POST request that inserts a medicine by sale
       */
        public Response insertMedicinebySale(medicine_by_sale ms)
        {
           
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT addmedicine_by_sale(" + ms.sale + "," + ms.medicine + "," + ms.price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + ms.quantity + ");";
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
      * PUT request that updates a medicine by sale
      */ 
        public Response updateMedicinebySale(int idm, int ids, medicine_by_sale ms)
        {
           
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatemedicine_by_sale(" + ids + "," + idm + "," + ms.price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + ms.quantity + "');";
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
       * DELETE request that disable a medicine by sale
       */ 
        public Response deleteMedicinebySale(int idm, int ids)
        {
         
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletemedicine_by_sale(" + ids + "," + idm + ");";
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