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
    public class CompaniesController : ApiController
    {
        CompaniesRepository repository;
        public CompaniesController()
        {
            repository = new CompaniesRepository();
        }
        public List<company> Get()
        {
            return repository.GetAllCompanies();
        }
        public company Get(int id)
        {
            return repository.GetCompany(id);
        }
        public void Post(company cop)
        {
            repository.insertCompany(cop);
        }
        public void Put(int id, company cop)
        {
            repository.updateCompany(id, cop);
        }
        public void Delete(int id)
        {
            repository.deleteCompany(id);
        }
    }
}
