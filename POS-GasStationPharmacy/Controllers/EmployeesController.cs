using POS_GasStationPharmacy.Models;
using POS_GasStationPharmacy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS_GasStationPharmacy.Controllers
{
    /**
    * Controller that does all the HTTP requests of employees
    */
    public class EmployeesController : ApiController
    {
        EmployeesRepository repository;
        public EmployeesController()
        {
            repository = new EmployeesRepository();
        }
        /**
        * GET request that get all employees
        */ 
        public List<employee> Get()
        {
            return repository.GetEmployees();
        }
        /**
        * GET request that get one employee
        */ 
        public employee Get(int id)
        {
            return repository.GetEmployeeById(id);
        }
        /**
        * POST request that inserts a employee
        */ 
        public Response Post(employee emp)
        {
            return repository.insertEmployee(emp);
        }
        /**
        * PUT request that updates a employee
        */ 
        public Response Put(int id, employee emp)
        {
            return repository.updateEmployee(id, emp);
        }
        /**
        * DELETE request that disable a employee
        */ 
        public Response Delete(int id)
        {
            return repository.deleteEmployee(id);
        }
    }
}
