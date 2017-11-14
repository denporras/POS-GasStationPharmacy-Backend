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
         PharmaceuticalHousesRepository repository;
        public PharmaceuticalHousesController()
        {
            repository = new PharmaceuticalHousesRepository();
        }

        public List<pharmaceutical_house> Get()
        {
            return repository.GetAllPharmaceuticalHouses();
        }

        public pharmaceutical_house Get(int id)
        {
            return repository.GetPharmaceuticalHousebyId(id);
        }

        public void Post(pharmaceutical_house ph)
        {
            repository.AddPharmaceuticalHouse(ph);
        }


        public void Put(int id, pharmaceutical_house ph)
        {
            repository.UpdatePharmaceuticalHouse(id, ph);
        }
        public void Delete(int id)
        {
            repository.DeletePharmaceuticalHouse(id);
        }
         
	}
}