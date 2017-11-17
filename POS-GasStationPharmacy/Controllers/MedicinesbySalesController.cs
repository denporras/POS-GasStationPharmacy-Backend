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
         MedicinesbySalesRepository repository;
         public MedicinesbySalesController()
        {
            repository = new MedicinesbySalesRepository();
        }
        public List<medicine_by_sale> Get()
        {
            return repository.GetAllMedicinesbySales();
        }
        public medicine_by_sale Get(int idm,int ids)
        {
            return repository.GetMedicinebySaleById(idm,ids);
        }

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
        public void Post(medicine_by_sale ms)
        {
            repository.insertMedicinebySale(ms);
        }
        public void Put(int idm,int ids, medicine_by_sale ms)
        {
            repository.updateMedicinebySale(idm,ids, ms);
        }
        public void Delete(int idm, int ids)
        {
            repository.deleteMedicinebySale(idm,ids);
        }
    }
}
