using CrystalDecisions.CrystalReports.Engine;
using POS_GasStationPharmacy.Models;
using POS_GasStationPharmacy.Service;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using CrystalDecisions.Shared;
using System.Web;
using System;

namespace POS_GasStationPharmacy.Controllers
{
    public class ReportsController : ApiController
    {
        ReportsRepository repository;
        PGSDbContext _context; // DataBase object
        ReportDocument cryRpt; // crystal report object

        public ReportsController()
        {
            repository = new ReportsRepository();
            _context = new PGSDbContext();
            cryRpt = new ReportDocument(); // instanciar crystal report 
        }
        public HttpResponseMessage Get(int id, DateTime initial, DateTime final, int subsidairy, int cashier)
        {
            string fileName = "";
            int flag = 1;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Content = new StringContent("The report isn't available");
            System.Diagnostics.Debug.WriteLine("Nombre " +" NOOOOOOOOOOO" + " VERGAAAAAAAAAAA");

            if (id == 1)
            {
                fileName = "BestSelling";
                System.Diagnostics.Debug.WriteLine(" VERGAAAAAAAAAAA 11111111111111111");
            }
            else if (id == 2)
            {
                fileName = "LowInv";
                System.Diagnostics.Debug.WriteLine(" VERGAAAAAAAAAAA 3333333333");
            }
            else if (id == 3)
            {
                fileName = "LowInv";
                System.Diagnostics.Debug.WriteLine(" VERGAAAAAAAAAAA 3333333333");
            }
            else if (id == 4)
            {
                fileName = "LowInv";
                System.Diagnostics.Debug.WriteLine(" VERGAAAAAAAAAAA 3333333333");
            }
            else if (id == 5)
            {
                fileName = "LowInv";
                System.Diagnostics.Debug.WriteLine(" VERGAAAAAAAAAAA 3333333333");
            }

            else
            {
                flag = 0;
            }

            if (flag == 1)
            {
                System.Diagnostics.Debug.WriteLine("Nombre "+fileName+" VERGAAAAAAAAAAA");

                bool ready = CreatePDF(fileName + ".rpt", id, initial, final, subsidairy, cashier);

                if (ready == true)
                {

                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(new FileStream(HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"), FileMode.Open, FileAccess.Read));
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = fileName + ".pdf";
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                }
            }


            return response;
        }

        // Function used to create the pdf of the crystal repor
        private bool CreatePDF(string rptFileName, int id, DateTime initial, DateTime final, int subsidairy, int cashier)
        {
           
            cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + rptFileName));

            if (id == 1)
            {
                cryRpt.SetParameterValue("Inidate", "2017-01-01");
                cryRpt.SetParameterValue("Fidate", "2017-12-01");
            }

            
            //CREATE THE PDF FILE USING CRYSTAL REPORT AND SAVE IN SERVER
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + rptFileName));
            return true;
        }
    }
        
}
