using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class LogInRepository
    {
        PGSDbContext _context;
        public LogInRepository()
        {
            _context = new PGSDbContext();
        }

        public LogInResponse attempLogIn(string user_name, string password)
        {
            LogInResponse res = new LogInResponse();
            res.success = false;
            res.message = "ERROR: User Invalid";
            employee emp = new employee();
            var query = "SELECT * FROM getEmployeeByUsername('" + user_name + "');";
            emp = _context.Database.SqlQuery<employee>(query).FirstOrDefault();
            if (emp != null)
            {
                res.message = "ERROR: Wrong Password";
                if (emp.password.Equals(password))
                {
                    res.success = true;
                    res.message = "LOGIN SUCCESSFUL";
                    res.information = emp;
                }
            }
            return res;
        }
    }
}