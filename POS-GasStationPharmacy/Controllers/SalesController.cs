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
    public class SalesController : ApiController
    {
           SalesRepository repository;
        public SalesController()
        {
            repository = new SalesRepository();
        }
        public List<sale> Get()
        {
            return repository.GetAllSales();
        }
        public sale Get(int id)
        {
            return repository.GetSaleById(id);
        }
        public void Post(sale sale)
        {
            repository.insertSale(sale);
        }
        public void Put(int id, sale sale)
        {
            repository.updateSale(id, sale);
        }
        public void Delete(int id)
        {
            repository.deleteSale(id);
        }
    }
}
