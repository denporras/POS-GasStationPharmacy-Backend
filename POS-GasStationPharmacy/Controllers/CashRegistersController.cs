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
    * Controller that does all the HTTP requests of cash register
    */ 
    public class CashRegistersController : ApiController
    {
           CashRegistersRepository repository;
           public CashRegistersController()
        {
            repository = new CashRegistersRepository();
        }
          /**
          * GET request that get all cash registers
          */ 
        public List<cash_register> Get()
        {
            return repository.GetAllCashRegisters();
        }

        /**
        * GET request that get one cash register
        */ 
        public cash_register Get(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            return repository.GetCashRegisterbyId(cash, subsidiary, employee, initial_time);
        }

        /**
        * POST request that inserts a cash register
        */ 
        public Response Post(cash_register c)
        {
            return repository.AddCashRegister(c);
        }

        /**
        * PUT request that updates a cash register
        */ 
        public Response Put(cash_register c)
        {
            return repository.UpdateCashRegister(c);
        }

        /**
         * DELETE request that disable a cash register
         */ 
        public Response Delete(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            return repository.DeleteCashRegister(cash, subsidiary, employee, initial_time);
        }
 
    }
}
