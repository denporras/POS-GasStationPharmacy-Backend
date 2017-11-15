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
    public class CashRegistersController : ApiController
    {
           CashRegistersRepository repository;
           public CashRegistersController()
        {
            repository = new CashRegistersRepository();
        }

        public List<cash_register> Get()
        {
            return repository.GetAllCashRegisters();
        }

        public cash_register Get(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            return repository.GetCashRegisterbyId(cash, subsidiary, employee, initial_time);
        }

        public void Post(cash_register c)
        {
            repository.AddCashRegister(c);
        }


        public void Put(cash_register c)
        {
            repository.UpdateCashRegister(c);
        }
        public void Delete(int cash, int subsidiary, int employee, DateTime initial_time)
        {
            repository.DeleteCashRegister(cash, subsidiary, employee, initial_time);
        }
 
    }
}
