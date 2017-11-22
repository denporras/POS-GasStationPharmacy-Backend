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
        public HttpResponseMessage Get(int id, DateTime initial, DateTime final, int company)
        {
            string fileName = "";
            int flag = 1;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Content = new StringContent("The report isn't available");

            if (id == 1)
            {
                fileName = "BestSelling";

                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
             
                cryRpt.SetDatabaseLogon("grupomaravilla", "Maravilla0", "aa6eybgl4mgz1n.cpgbjsyapasj.us-east-2.rds.amazonaws.com", "POS_GasStationPharmacy", true);
           
                cryRpt.SetParameterValue("Fidate", final);
                cryRpt.SetParameterValue("Inidate", initial);
                cryRpt.SetParameterValue("Compa", company);

                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName));
            }
            else if (id == 2)
            {
                fileName = "MedBySubEm";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
                
                cryRpt.SetDatabaseLogon("grupomaravilla", "Maravilla0", "aa6eybgl4mgz1n.cpgbjsyapasj.us-east-2.rds.amazonaws.com", "POS_GasStationPharmacy", true);
              
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName));
            }
            else if (id == 3)
            {
                fileName = "LowInv";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
               
                cryRpt.SetDatabaseLogon("grupomaravilla", "Maravilla0", "aa6eybgl4mgz1n.cpgbjsyapasj.us-east-2.rds.amazonaws.com", "POS_GasStationPharmacy", true);
                
                cryRpt.SetParameterValue("Compa", company);

                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName));
            }
            else if (id == 4)
            {
                fileName = "CashAVG";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
               
                cryRpt.SetDatabaseLogon("grupomaravilla", "Maravilla0", "aa6eybgl4mgz1n.cpgbjsyapasj.us-east-2.rds.amazonaws.com", "POS_GasStationPharmacy", true);
              
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.SetParameterValue("DateDay", initial);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName));
            }
            else if (id == 5)
            {
                fileName = "BillsDay";
                cryRpt.Load(HttpContext.Current.Server.MapPath("~/Reports/" + fileName + ".rpt"));
              
                cryRpt.SetDatabaseLogon("grupomaravilla", "Maravilla0", "aa6eybgl4mgz1n.cpgbjsyapasj.us-east-2.rds.amazonaws.com", "POS_GasStationPharmacy", true);
                
                cryRpt.SetParameterValue("Compa", company);
                cryRpt.SetParameterValue("DateDay", initial);
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName));
            }
            //cryRpt.SetDatabaseLogon("grupomaravilla", "Maravilla0", "aa6eybgl4mgz1n.cpgbjsyapasj.us-east-2.rds.amazonaws.com", "POS_GasStationPharmacy", true);
            else
            {
                flag = 0;
            }

            if (flag == 1)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(new FileStream(HttpContext.Current.Server.MapPath("~/Reports/Reports_PDF/" + fileName), FileMode.Open, FileAccess.Read));
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
                response.Content.Headers.ContentDisposition.FileName = fileName + ".pdf";
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

            }


            return response;
        }
    }

}