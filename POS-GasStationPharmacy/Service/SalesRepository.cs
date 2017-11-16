using NpgsqlTypes;
using POS_GasStationPharmacy.Models;
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

        public List<sale> GetAllSales()
        {
            var query = "SELECT * FROM getsales()";
            List<sale> sal = _context.Database.SqlQuery<sale>(query).ToList();
            return sal;
        }

        public sale GetSaleById (int id)
        {
            var query = "SELECT * FROM getsale(" + id + ");";
            sale sal = _context.Database.SqlQuery<sale>(query).FirstOrDefault();
            return sal;
        }

        public void insertSale(sale sal)
        {
            var query = "SELECT addsale(" + sal.total.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + sal.sale_date.ToString("yyyy-MM-dd HH:mm") + "," + sal.client + "," + sal.payment_type + "," + sal.employee + "," + sal.subsidiary + "," + sal.cash + ");";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateSale(int id, sale sal)
        {
            var query = "SELECT updatesale(" + id + ","+sal.total.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + sal.sale_date.ToString("yyyy-MM-dd HH:mm") + "," + sal.client + "," + sal.payment_type + "," + sal.employee + "," + sal.subsidiary + "," + sal.cash + "');";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteSale(int id)
        {
            var query = "SELECT deletesale(" + id + ");";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}