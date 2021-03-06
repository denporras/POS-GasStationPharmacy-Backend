﻿using Npgsql;
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
        /**
        * GET request that get all employees
        */ 
        public List<employee> GetEmployees()
        {
            var query = "SELECT * FROM getEmployees();";
            List<employee> emp = _context.Database.SqlQuery<employee>(query).ToList();
            return emp;
        }
        /**
        * GET request that get one employee
        */ 
        public employee GetEmployeeById(int id_employee)
        {
            var query = "SELECT * FROM getEmployee(" + id_employee + ");";
            employee emp = _context.Database.SqlQuery<employee>(query).FirstOrDefault();
            return emp;
        }
        /**
        * POST request that inserts a employee
        */
        public Response insertEmployee(employee emp)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT insertEmployee(" + emp.id_employee + ", '" + emp.first_name + "', '" + emp.second_name + "'" +
            ", '" + emp.first_last_name + "', '" + emp.second_last_name + "', '" + emp.birthdate.ToString("MM/dd/yyyy") + "', '" + emp.user_name + "'" +
            ", '" + emp.password + "', '" + emp.phone + "', '" + emp.residence + "', " + emp.role + ", " + emp.subsidiary + ")";
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
        * PUT request that updates a employee
        */ 
        public Response updateEmployee(int id_employee, employee emp)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT updateEmployee(" + id_employee + ", '" + emp.first_name + "', '" + emp.second_name + "'" +
           ", '" + emp.first_last_name + "', '" + emp.second_last_name + "', '" + emp.birthdate.ToString("MM/dd/yyyy") + "', '" + emp.user_name + "'" +
           ", '" + emp.password + "', '" + emp.phone + "', '" + emp.residence + "', " + emp.role + ", " + emp.subsidiary + ")";
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
        * DELETE request that disable a employee
        */ 
        public Response deleteEmployee(int id_employee)
        {
            Response res = new Response();
            res.success = true;
            res.code = "1";
            res.message = "SUCCESSFUL";
            try
            {
                var query = "SELECT deleteEmployee(" + id_employee + ")";
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