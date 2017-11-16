using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace POS_GasStationPharmacy.Service
{
    public class CashRegistersRepository
    {
        PGSDbContext _context;
        public CashRegistersRepository()
        {
            _context = new PGSDbContext();
        }

        public List<cash_register> GetAllCashRegisters()
        {
            var query = "SELECT * FROM getcashregisters();";
            List<cash_register> pharma = _context.Database.SqlQuery<cash_register>(query).ToList();
            return pharma;
        }

        public cash_register GetCashRegisterbyId(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            var query = "SELECT * FROM getcashregister(" + cash + "," + subsidiary + ",'" + initial_time.ToString("yyyy-MM-dd HH:mm") + "'," + employee + ");";
            cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
            return pharma;
        }

        public void AddCashRegister(cash_register c)
        {
            var query = "SELECT addcashregister(" + c.cash + "," + c.subsidiary + ",'" + c.initial_time.ToString("yyyy-MM-dd HH:mm") + "'," + c.initial_cash.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + c.employee + ");";
            cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
           
        }

        public void UpdateCashRegister(cash_register c)
        {
            var query = "SELECT updatecashregister(" + c.cash + "," + c.subsidiary + ",'" + c.initial_time.ToString("yyyy-MM-dd HH:mm") + "'," + c.employee + ",'" + c.final_time.ToString("yyyy-MM-dd HH:mm") + "'," + c.final_cash.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ");";
            cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();

        }

        public void DeleteCashRegister(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            var query = "SELECT deletecashregister(" + cash + "," + subsidiary + ",'" + initial_time.ToString("yyy-mm-dd hh:mm") + "'," + employee + ");";
            cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();

        }
    }
}