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
    public class LogInController : ApiController
    {
        LogInRepository repository;
        public LogInController()
        {
            repository = new LogInRepository();
        }
        public LogInResponse Get(string username, string password)
        {
            return repository.attempLogIn(username, password);
        }
    }
}
