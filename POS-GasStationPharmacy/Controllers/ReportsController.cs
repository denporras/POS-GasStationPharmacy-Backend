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
    public class ReportsController : ApiController
    {
         ReportsRepository repository;
         public ReportsController()
        {
            repository = new ReportsRepository();
        }
        public report Get(report rep)
        {
            return repository.GetReports(rep);
        }
    }
}
