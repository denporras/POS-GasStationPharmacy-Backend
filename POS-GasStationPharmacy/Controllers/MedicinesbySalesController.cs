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
    public class MedicinesbySalesController : ApiController
    {
        /**
    * Controller that does all the HTTP requests of medicines by sales
    */ 
         MedicinesbySalesRepository repository;
         public MedicinesbySalesController()
        {
            repository = new MedicinesbySalesRepository();
        }
         /**
         * GET request that get all medicines by sale
         */ 
        public List<medicine_by_sale> Get()
        {
            return repository.GetAllMedicinesbySales();
        }
        /**
       * GET request that get one medicine by sale
       */ 
        public medicine_by_sale Get(int idm,int ids)
        {
            return repository.GetMedicinebySaleById(idm,ids);
        }
        /**
        * GET request that get one medicine by sale
        */ 
        public List<medicine_by_sale> Get(int id, String type)
        {
            if (type.Equals("m"))
            {
                return repository.GetMedicinebySaleByMedicine(id);
            }
            else
            {
                return repository.GetMedicinebySaleBySale(id);
            }
        }
        /**
         * POST request that inserts a medicine by sale
        */
        public Response Post(medicine_by_sale ms)
        {
            return repository.insertMedicinebySale(ms);
        }
        /**
        * PUT request that updates a medicine by sale
        */ 
        public Response Put(int idm,int ids, medicine_by_sale ms)
        {
            return repository.updateMedicinebySale(idm,ids, ms);
        }
        /**
        * DELETE request that disable a medicine by sale
        */ 
        public Response Delete(int idm, int ids)
        {
            return repository.deleteMedicinebySale(idm,ids);
        }
    }
}
