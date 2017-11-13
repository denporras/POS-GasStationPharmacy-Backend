using NpgsqlTypes;
using POS_GasStationPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_GasStationPharmacy.Service
{
    public class ClientsRepository
    {
        PGSDbContext _context;
        public ClientsRepository()
        {
            _context = new PGSDbContext();
        }

        public client GetClientById (int id_client)
        {
            var query = "SELECT * FROM getClient(" + id_client + ");";
            client cli = _context.Database.SqlQuery<client>(query).FirstOrDefault();
            return cli;
        }
    }
}