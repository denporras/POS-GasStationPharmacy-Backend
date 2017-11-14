using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace POS_GasStationPharmacy.Service
{
    public class PharmaceuticalHousesRepository
    {
        PGSDbContext _context;
        public PharmaceuticalHousesRepository()
        {
            _context = new PGSDbContext();
        }

        public List<pharmaceutical_house> GetAllPharmaceuticalHouses()
        {
            var query = "SELECT * FROM getPharmaceuticalHouses();";
            List<pharmaceutical_house> pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).ToList();
            return pharma;
        }

        public pharmaceutical_house GetPharmaceuticalHousebyId(int id)
        {
            var query = "SELECT * FROM getPharmaceuticalHouse("+ id +");";
            pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();
            return pharma;
        }

        public void AddPharmaceuticalHouse(pharmaceutical_house ph) {
            var query = "SELECT addpharmaceuticalhouse('" + ph.name + "');";
            pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();
           
        }

        public void UpdatePharmaceuticalHouse(int id, pharmaceutical_house ph)
        {
            var query = "SELECT updatepharmaceuticalhouse(" + id + ",'" + ph.name + "');";
            pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();

        }

        public void DeletePharmaceuticalHouse(int id)
        {
            var query = "SELECT deletepharmaceuticalhouse(" + id + ");";
            pharmaceutical_house pharma = _context.Database.SqlQuery<pharmaceutical_house>(query).FirstOrDefault();

        }



    }
}