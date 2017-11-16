using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;

namespace POS_GasStationPharmacy.Service
{
    public class ReportsRepository
    {
        public HttpResponseMessage Get(int id, DateTime initial, DateTime final, int subsidairy, int cashier)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //Hacer todo aqui Gabriel
            return response; //Cambiar 
        }
    }


}