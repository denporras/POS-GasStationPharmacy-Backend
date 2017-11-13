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
    public class RolesController : ApiController
    {
        RolesRepository repository;
        public RolesController()
        {
            repository = new RolesRepository();
        }

        public List<role> Get()
        {
            return repository.GetAllRoles();
        }
    }
}
