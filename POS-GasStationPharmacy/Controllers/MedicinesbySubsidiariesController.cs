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
           MedicinesbySubsidiariesRepository repository;
           public MedicinesbySubsidiariesController()
        {
            repository = new MedicinesbySubsidiariesRepository();
        }
        public List<medicine_by_subsidiary> Get()
        {
            return repository.GetAllMedicinesbySubsidiaries();
        }
        public medicine_by_subsidiary Get(int idm, int ids)
        {
            return repository.GetMedicinebySubsidiaryById(idm, ids);
        }

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
        public void Post(medicine_by_subsidiary ms)
        {
            repository.insertMedicinebySubsidiary(ms);
        }
        public void Put(int idm, int ids, medicine_by_subsidiary ms)
        {
            repository.updateMedicinebySubsidiary(idm, ids, ms);
        }
        public void Delete(int idm, int ids)
        {
            repository.deleteMedicinebySubsidiary(idm,ids);
        }
    }
}
