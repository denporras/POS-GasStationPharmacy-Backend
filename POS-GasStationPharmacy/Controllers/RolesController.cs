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
        /**
        * Controller that does all the HTTP requests of roles
        */
        RolesRepository repository;
        public RolesController()
        {
            repository = new RolesRepository();
        }
        /**
        * GET request that get all roles
        */ 
        public List<role> Get()
        {
            return repository.GetAllRoles();
        }
        /**
        * GET request that get one role
        */
        public role Get(int id)
        {
            return repository.GetRole(id);
        }
        /**
        * POST request that inserts a role
        */ 
        public Response Post(role rol)
        {
            return repository.insertRole(rol);
        }
        /**
        * PUT request that updates a role
        */ 
        public Response Put(int id, role rol)
        {
            return repository.updateRole(id, rol);
        }
        /**
        * DELETE request that disable a role
        */  
        public Response Delete(int id)
        {
            return repository.deleteRole(id);
        }
    }
}
