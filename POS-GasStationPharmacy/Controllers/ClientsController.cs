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
    public class ClientsController : ApiController
    {
        ClientsRepository repository;
        public ClientsController()
        {
            repository = new ClientsRepository();
        }
        public List<client> Get()
        {
            return repository.GetAllClients();
        }
        public client Get(int id)
        {
            return repository.GetClientById(id);
        }
        public void Post(client cli)
        {
            repository.insertClient(cli);
        }
        public void Put(int id, client cli)
        {
            repository.updateClient(id, cli);
        }
        public void Delete(int id)
        {
            repository.deleteClient(id);
        }
    }
}
