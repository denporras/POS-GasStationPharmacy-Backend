using Npgsql;
using POS_GasStationPharmacy.Models;
using POS_GasStationPharmacy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class SalesRepository
    {
        PGSDbContext _context;
        public SalesRepository()
        {
            _context = new PGSDbContext();
        }
        /**
       * GET request that get all sales
       */ 
        public List<sale> GetAllSales()
        {
            MedicinesbySalesRepository msrep = new MedicinesbySalesRepository();
            var query = "SELECT * FROM getsales()";
            List<sale> sal = _context.Database.SqlQuery<sale>(query).ToList();
            for (int i = 0; i < sal.Count(); i++)
            {
                sal[i].medicines = msrep.GetMedicinebySaleBySale(sal[i].id_sale);
            }
            return sal;
        }

        /**
     * GET request that get sales by payment type
     */
        public sale_by_payment_type GetSalesByPaymentType(int sub, int cash, DateTime date)
        {
            MedicinesbySalesRepository msrep = new MedicinesbySalesRepository();
            sale_by_payment_type spt = new sale_by_payment_type();
            var query = "SELECT * FROM getsalebypayment("+ sub +","+ cash +","+ 1 + ",'" + date + "')";
                spt.credit = _context.Database.SqlQuery<sale>(query).ToList();
            var query2 = "SELECT * FROM getsalebypayment(" + sub + "," + cash + "," + 2 + ",'" + date + "')";
                spt.cash = _context.Database.SqlQuery<sale>(query2).ToList();
            for (int i = 0; i < spt.credit.Count(); i++)
            {
                spt.credit[i].medicines = msrep.GetMedicinebySaleBySale(spt.credit[i].id_sale);
            }
            for (int i = 0; i < spt.cash.Count(); i++)
            {
                spt.cash[i].medicines = msrep.GetMedicinebySaleBySale(spt.cash[i].id_sale);
            }
            return spt;
        }

        /**
     * GET request that get one sales
     */ 
        public sale GetSaleById (int id)
        {
            MedicinesbySalesRepository msrep = new MedicinesbySalesRepository();
            var query = "SELECT * FROM getsale(" + id + ");";
            sale sal = _context.Database.SqlQuery<sale>(query).FirstOrDefault();
            sal.medicines = msrep.GetMedicinebySaleBySale(sal.id_sale);
            return sal;
        }
        /**
     * POST request that inserts a sale
     */
        public SalesResponse insertSale(sale sal)
        {
            MedicinesbySalesRepository msrep = new MedicinesbySalesRepository();
            SalesResponse res = new SalesResponse();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            res.id_inserted = -1;
            try
            {
                var query = "SELECT addsale(" + sal.total.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",'" + sal.sale_date.ToString("yyyy-MM-dd HH:mm") + "'," + sal.client + "," + sal.payment_type + "," + sal.employee + "," + sal.subsidiary + "," + sal.cash + ");";
                _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
                   var query2 = "SELECT getlastsaleid();";
                res.id_inserted = _context.Database.SqlQuery<Int32>(query2).FirstOrDefault(); 
                for (int i = 0; i < sal.medicines.Count();i++)
                {       
                    sal.medicines[i].sale = res.id_inserted;
                    msrep.insertMedicinebySale(sal.medicines[i]);
                }
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
     * PUT request that updates a sale
     */
        public Response updateSale(int id, sale sal)
        {
            MedicinesbySalesRepository msrep = new MedicinesbySalesRepository();
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatesale(" + id + "," + sal.total.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",'" + sal.sale_date.ToString("yyyy-MM-dd HH:mm") + "'," + sal.client + "," + sal.payment_type + "," + sal.employee + "," + sal.subsidiary + "," + sal.cash + "');";
                _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
                for (int i = 0; i < sal.medicines.Count(); i++)
                {
                    msrep.updateMedicinebySale(sal.medicines[i].medicine, id, sal.medicines[i]);
                }
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
        * DELETE request that disable a sale
        */ 
        public Response deleteSale(int id)
        {
           
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletesale(" + id + ");";
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