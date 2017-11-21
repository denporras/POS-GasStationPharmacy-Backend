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
    * Controller that does all the HTTP requests of subsidiaries
    */
    public class SubsidiariesController : ApiController
    {
        SubsidiariesRepository repository;
        public SubsidiariesController()
        {
            repository = new SubsidiariesRepository();
        }
        /**
        * GET request that get all subsidiaries
        */
        public List<subsidiary> Get()
        {
            return repository.GetAllRoles();
        }
        /**
        * GET request that get one subsidiary
        */
        public subsidiary Get(int id)
        {
            return repository.GetSubsidiary(id);
        }
        /**
        * POST request that inserts a subsidiary
        */
        public Response Post(subsidiary sub)
        {
            return repository.insertSubsidiary(sub);
        }
        /**
        * PUT request that updates a subsidiary
        */
        public Response Put(int id, subsidiary sub)
        {
            return repository.updateSubsidiary(id, sub);
        }
        /**
        * DELETE request that disable a subsidiary
        */  
        public Response Delete(int id)
        {
            return repository.deleteSubsidiary(id);
        }
    }
}
