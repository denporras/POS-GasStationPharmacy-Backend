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

        /**
        * GET request that get all cash registers
        */ 
        public List<cash_register> GetAllCashRegisters()
        {
            var query = "SELECT * FROM getcashregisters();";
            List<cash_register> pharma = _context.Database.SqlQuery<cash_register>(query).ToList();
            return pharma;
        }

        /**
        * GET request that get one cash register
        */ 
        public cash_register GetCashRegisterbyId(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            var query = "SELECT * FROM getcashregister(" + cash + "," + subsidiary + ",'" + initial_time.ToString("yyyy-MM-dd HH:mm") + "'," + employee + ");";
            cash_register pharma = _context.Database.SqlQuery<cash_register>(query).FirstOrDefault();
            return pharma;
        }

        /**
        * POST request that inserts a cash register
        */ 
        public Response AddCashRegister(cash_register c)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                         var query = "SELECT addcashregister(" + c.cash + "," + c.subsidiary + ",'" + c.initial_time.ToString("yyyy-MM-dd HH:mm") + "'," + c.initial_cash.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "," + c.employee + ");";
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
        * PUT request that updates a cash register
        */ 
        public Response UpdateCashRegister(cash_register c)
        {
           Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updatecashregister(" + c.cash + "," + c.subsidiary + ",'" + c.initial_time.ToString("yyyy-MM-dd HH:mm") + "'," + c.employee + ",'" + c.final_time.ToString("yyyy-MM-dd HH:mm") + "'," + c.final_cash.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ");";
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
        * DELETE request that disable a cash register
        */ 
        public Response DeleteCashRegister(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deletecashregister(" + cash + "," + subsidiary + ",'" + initial_time.ToString("yyy-mm-dd hh:mm") + "'," + employee + ");";
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
    }
}