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
        /**
   * Controller that does all the HTTP requests of sales
   */ 
        SalesRepository repository;
        public SalesController()
        {
            repository = new SalesRepository();
        }
        /**
        * GET request that get all sales
        */ 
        public List<sale> Get()
        {
            return repository.GetAllSales();
        }

        /**
       * GET request that get sales by payment type
       */
        public sale_by_payment_type Get(int sub, int cash, DateTime date)
        {
            return repository.GetSalesByPaymentType(sub, cash, date);
        }
        /**
       * GET request that get one sales
       */ 
        public sale Get(int id)
        {
            return repository.GetSaleById(id);
        }
        /**
       * POST request that inserts a sale
       */
        public SalesResponse Post(sale sale)
        {
            return repository.insertSale(sale);
        }
        /**
       * PUT request that updates a sale
       */
        public Response Put(int id, sale sale)
        {
            return repository.updateSale(id, sale);
        }
        /**
         * DELETE request that disable a sale
         */ 
        public Response Delete(int id)
        {
            return repository.deleteSale(id);
        }
    }
}
