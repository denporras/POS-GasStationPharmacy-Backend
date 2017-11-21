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
    * Controller that does all the HTTP requests of companies
    */
    public class CompaniesController : ApiController
    {
        CompaniesRepository repository;
        public CompaniesController()
        {
            repository = new CompaniesRepository();
        }
        /**
        * GET request that get all companies
        */ 
        public List<company> Get()
        {
            return repository.GetAllCompanies();
        }
        /**
        * GET request that get one company
        */ 
        public company Get(int id)
        {
            return repository.GetCompany(id);
        }
        /**
        * POST request that inserts a company
        */ 
        public Response Post(company cop)
        {
            return repository.insertCompany(cop);
        }
        /**
        * PUT request that updates a company
        */
        public Response Put(int id, company cop)
        {
            return repository.updateCompany(id, cop);
        }
        /**
        * DELETE request that disable a company
        */ 
        public Response Delete(int id)
        {
            return repository.deleteCompany(id);
        }
    }
}
