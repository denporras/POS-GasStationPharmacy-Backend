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
    public class MedicinesbySubsidiariesController : ApiController
    {
        /**
        * Controller that does all the HTTP requests of medicines by subsidiaries
        */
        MedicinesbySubsidiariesRepository repository;
        public MedicinesbySubsidiariesController()
        {
            repository = new MedicinesbySubsidiariesRepository();
        }
        /**
       * GET request that get all medicines by subsidiaries
       */ 
        public List<medicine_by_subsidiary> Get()
        {
            return repository.GetAllMedicinesbySubsidiaries();
        }
        /**
     * GET request that get one medicine by subsidiary
     */ 
        public medicine_by_subsidiary Get(int idm, int ids)
        {
            return repository.GetMedicinebySubsidiaryById(idm, ids);
        }
        /**
       * GET request that get one medicine by subsidiary
       */ 
        public List<medicine_by_subsidiary> Get(int id, String type)
        {
            if (type.Equals("m"))
            {
                return repository.GetMedicinebySubsidiaryByMedicine(id);
            }
            else 
            {
                return repository.GetMedicinebySubsidiaryBySubsidiary(id);
            }
        }
        /**
       * POST request that inserts a medicine by subsidiary
       */
        public Response Post(medicine_by_subsidiary ms)
        {
           return repository.insertMedicinebySubsidiary(ms);
        }
        /**
     * PUT request that updates a medicine by subsidiary
     */ 
        public Response Put(int idm, int ids, medicine_by_subsidiary ms)
        {
            return repository.updateMedicinebySubsidiary(idm, ids, ms);
        }
        /**
        * DELETE request that disable a medicine by subsidiary
        */ 
        public Response Delete(int idm, int ids)
        {
            return repository.deleteMedicinebySubsidiary(idm, ids);
        }
    }
}
