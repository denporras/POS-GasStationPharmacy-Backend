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
        public Response Post(medicine med)
        {
            return repository.insertMedicine(med);
        }
        public Response Put(int id, medicine med)
        {
            return repository.updateMedicine(id, med);
        }
        public Response Delete(int id)
        {
            return repository.deleteMedicine(id);
        }
    }
}
