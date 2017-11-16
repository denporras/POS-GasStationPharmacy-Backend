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
        public Response Post(company cop)
        {
            return repository.insertCompany(cop);
        }
        public Response Put(int id, company cop)
        {
            return repository.updateCompany(id, cop);
        }
        public Response Delete(int id)
        {
            return repository.deleteCompany(id);
        }
    }
}
