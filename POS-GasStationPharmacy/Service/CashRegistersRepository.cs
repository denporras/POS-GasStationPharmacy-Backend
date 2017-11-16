using Npgsql;
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
            var query = "SELECT * FROM getcashregister(" + cash + "," + subsidiary + ",'" + initial_time.Year + "-" + initial_time.Month + "-" + initial_time.Day + "'," + employee + ");";
            cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
            return pharma;
        }

        public Response AddCashRegister(cash_register c)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT addcashregister(" + c.cash + "," + c.subsidiary + ",'" + c.initial_time.Year + "-" + c.initial_time.Month + "-" + c.initial_time.Day + "'," + c.initial_cash.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + c.employee + ");";
                cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;
           
        }

        public Response UpdateCashRegister(cash_register c)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatecashregister(" + c.cash + "," + c.subsidiary + ",'" + c.initial_time.Year + "-" + c.initial_time.Month + "-" + c.initial_time.Day + "'," + c.employee + ",'" + c.final_time.Year + "-" + c.final_time.Month + "-" + c.final_time.Day + "'," + c.final_cash.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ");";
                cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
            }
            catch (NpgsqlException ex)
            {
                res.success = false;
                res.code = ex.Code;
                res.message = ex.BaseMessage;
            }
            return res;

        }

        public Response DeleteCashRegister(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletecashregister(" + cash + "," + subsidiary + ",'" + initial_time.Year + "-" + initial_time.Month + "-" + initial_time.Day + "'," + employee + ");";
                cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
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