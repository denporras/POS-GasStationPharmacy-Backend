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
    public class MedicinesController : ApiController
    {
           MedicinesRepository repository;
        public MedicinesController()
        {
            repository = new MedicinesRepository();
        }
        public List<medicine> Get()
        {
            return repository.GetAllMedicines();
        }
        public medicine Get(int id)
        {
            return repository.GetMedicineById(id);
        }
        public void Post(medicine med)
        {
            repository.insertMedicine(med);
        }
        public void Put(int id, medicine med)
        {
            repository.updateMedicine(id, med);
        }
        public void Delete(int id)
        {
            repository.deleteMedicine(id);
        }
    }
}
