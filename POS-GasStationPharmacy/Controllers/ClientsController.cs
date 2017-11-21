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
    * Controller that does all the HTTP requests of Clients
    */
    public class ClientsController : ApiController
    {
        ClientsRepository repository;
        public ClientsController()
        {
            repository = new ClientsRepository();
        }
        /**
        * GET request that get all clients
        */ 
        public List<client> Get()
        {
            return repository.GetAllClients();
        }
        /**
        * GET request that get one client
        */ 
        public client Get(int id)
        {
            return repository.GetClientById(id);
        }
        /**
        * POST request that inserts a client
        */ 
        public Response Post(client cli)
        {
            return repository.insertClient(cli);
        }
        /**
        * PUT request that updates a client
        */ 
        public Response Put(int id, client cli)
        {
            return repository.updateClient(id, cli);
        }
        /**
        * DELETE request that disable a client
        */  
        public Response Delete(int id)
        {
            return repository.deleteClient(id);
        }
    }
}
