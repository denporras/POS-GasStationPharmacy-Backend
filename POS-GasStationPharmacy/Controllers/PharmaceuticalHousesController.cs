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
    public class PharmaceuticalHousesController : ApiController
    {
        /**
        * Controller that does all the HTTP requests of pharmaceutical_house
        */ 
         PharmaceuticalHousesRepository repository;
        public PharmaceuticalHousesController()
        {
            repository = new PharmaceuticalHousesRepository();
        }
        /**
        * GET request that get all pharmaceutical houses
        */ 
        public List<pharmaceutical_house> Get()
        {
            return repository.GetAllPharmaceuticalHouses();
        }
        /**
       * GET request that get one pharmaceutical house
       */ 
        public pharmaceutical_house Get(int id)
        {
            return repository.GetPharmaceuticalHousebyId(id);
        }

        /**
       * POST request that inserts a pharmaceutical house
       */
        public Response Post(pharmaceutical_house ph)
        {
            return repository.AddPharmaceuticalHouse(ph);
        }

        /**
       * PUT request that updates a pharmaceutical house
       */
        public Response Put(int id, pharmaceutical_house ph)
        {
            return repository.UpdatePharmaceuticalHouse(id, ph);
        }
        /**
         * DELETE request that disable a pharmaceutical house
         */ 
        public Response Delete(int id)
        {
            return repository.DeletePharmaceuticalHouse(id);
        }
         
	}
}