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
    * Controller that does all the HTTP requests of medicines
    */ 
    public class MedicinesController : ApiController
    {
           MedicinesRepository repository;
        public MedicinesController()
        {
            repository = new MedicinesRepository();
        }

        /**
         * GET request that get all medicines
         */ 
        public List<medicine> Get()
        {
            return repository.GetAllMedicines();
        }
        /**
        * GET request that get one medicine
        */ 
        public medicine Get(int id)
        {
            return repository.GetMedicineById(id);
        }

        /**
        * POST request that inserts a medicine
        */
        public Response Post(medicine med)
        {
            return repository.insertMedicine(med);
        }

        /**
       * PUT request that updates a medicine
       */ 
        public Response Put(int id, medicine med)
        {
            return repository.updateMedicine(id, med);
        }

        /**
         * DELETE request that disable a medicine
         */ 
        public Response Delete(int id)
        {
            return repository.deleteMedicine(id);
        }
    }
}
