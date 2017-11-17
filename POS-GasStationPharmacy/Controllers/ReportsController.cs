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
        public HttpResponseMessage Get(int id, DateTime initial, DateTime final, int subsidairy,  int company, int lowInv)
        {
            string fileName = "";
            int flag = 1;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Content = new StringContent("The report isn't available");
            System.Diagnostics.Debug.WriteLine("Nombre " +" NOOOOOOOOOOO" + " VERGAAAAAAAAAAA");

            if (id == 1)
            {
                fileName = "BestSelling";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName+ ".rpt"));
                cryRpt.SetParameterValue("Inidate", initial);
                cryRpt.SetParameterValue("Fidate", final);
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"));

               
            }
            else if (id == 2)
            {
                fileName = "MedBySubEm";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"));
                
            }
            else if (id == 3)
            {
                fileName = "LowInv";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.SetParameterValue("lowInv", lowInv);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"));
            }
            else if (id == 4)
            {
                fileName = "CashAVG";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.SetParameterValue("DateDay", initial);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"));
            }
            else if (id == 5)
            {
                fileName = "BillsDay";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
                cryRpt.SetParameterValue("Compa", company);

                cryRpt.SetParameterValue("DateDay", initial);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"));
            }

            else
            {
                flag = 0;
            }

            if (flag == 1)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(new FileStream(HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName + ".rpt"), FileMode.Open, FileAccess.Read));
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = fileName + ".pdf";
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
         
            }


            return response;
        }
    }
        
}
