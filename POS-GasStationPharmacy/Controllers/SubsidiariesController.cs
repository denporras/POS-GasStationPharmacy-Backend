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
    public class SubsidiariesController : ApiController
    {
        SubsidiariesRepository repository;
        public SubsidiariesController()
        {
            repository = new SubsidiariesRepository();
        }
        public List<subsidiary> Get()
        {
            return repository.GetAllRoles();
        }
        public subsidiary Get(int id)
        {
            return repository.GetSubsidiary(id);
        }
        public Response Post(subsidiary sub)
        {
            return repository.insertSubsidiary(sub);
        }
        public Response Put(int id, subsidiary sub)
        {
            return repository.updateSubsidiary(id, sub);
        }
        public Response Delete(int id)
        {
            return repository.deleteSubsidiary(id);
        }
    }
}
