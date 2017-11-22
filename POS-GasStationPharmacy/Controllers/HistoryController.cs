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
    public class HistoryController : ApiController
    {
        SalesRepository repository;
        public HistoryController()
        {
            repository = new SalesRepository();
        }
        public sale_by_payment_type Get(int sub, int cash, DateTime date)
        {
            return repository.GetSalesByPaymentType(sub, cash, date);
        }
    }
}
