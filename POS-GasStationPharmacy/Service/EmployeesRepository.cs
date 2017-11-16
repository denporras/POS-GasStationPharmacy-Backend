using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class EmployeesRepository
    {
        PGSDbContext _context;
        public EmployeesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<employee> GetEmployees()
        {
            var query = "SELECT * FROM getEmployees();";
            List<employee> emp = _context.Database.SqlQuery<employee>(query).ToList();
            return emp;
        }

        public employee GetEmployeeById(int id_employee)
        {
            var query = "SELECT * FROM getEmployee(" + id_employee + ");";
            employee emp = _context.Database.SqlQuery<employee>(query).FirstOrDefault();
            return emp;
        }

        public void insertEmployee(employee emp)
        {
            var query = "SELECT insertEmployee(" + emp.id_employee + ", '" + emp.first_name + "', '" + emp.second_name + "'"+
            ", '" + emp.first_last_name + "', '" + emp.second_last_name + "', '" + emp.birthdate.ToString("MM/dd/yyyy") + "', '" + emp.user_name + "'" +
            ", '" + emp.password + "', '" + emp.phone + "', '" + emp.residence + "', "+emp.role+", "+emp.subsidiary+")";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateEmployee(int id_employee, employee emp)
        {
            var query = "SELECT updateEmployee(" + id_employee + ", '" + emp.first_name + "', '" + emp.second_name + "'" +
           ", '" + emp.first_last_name + "', '" + emp.second_last_name + "', '" + emp.birthdate.ToString("MM/dd/yyyy") + "', '" + emp.user_name + "'" +
           ", '" + emp.password + "', '" + emp.phone + "', '" + emp.residence + "', " + emp.role + ", " + emp.subsidiary + ")";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteEmployee(int id_employee)
        {
            var query = "SELECT deleteEmployee(" + id_employee + ")";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}