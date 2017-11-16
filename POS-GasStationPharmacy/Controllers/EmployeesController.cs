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
    public class EmployeesController : ApiController
    {
        EmployeesRepository repository;
        public EmployeesController()
        {
            repository = new EmployeesRepository();
        }
        public List<employee> Get()
        {
            return repository.GetEmployees();
        }
        public employee Get(int id)
        {
            return repository.GetEmployeeById(id);
        }
        public Response Post(employee emp)
        {
            return repository.insertEmployee(emp);
        }
        public Response Put(int id, employee emp)
        {
            return repository.updateEmployee(id, emp);
        }
        public Response Delete(int id)
        {
            return repository.deleteEmployee(id);
        }
    }
}
