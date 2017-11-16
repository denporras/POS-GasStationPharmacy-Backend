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

        public List<client> GetAllClients()
        {
            var query = "SELECT * FROM getClients()";
            List<client> cli = _context.Database.SqlQuery<client>(query).ToList();
            return cli;
        }

        public client GetClientById (int id_client)
        {
            var query = "SELECT * FROM getClient(" + id_client + ");";
            client cli = _context.Database.SqlQuery<client>(query).FirstOrDefault();
            return cli;
        }

        public void insertClient(client cli)
        {
            var query = "SELECT insertClient(" + cli.id_client + ", '" + cli.first_name + "', '" + cli.second_name + "'" +
            ", '" + cli.first_last_name + "', '" + cli.second_last_name + "', '" + cli.birthdate.ToString("MM/dd/yyyy") + 
            "', '" + cli.phone + "', '" + cli.residence + "');";
            _context.Database.SqlQuery<Int32>(query).FirstOrDefault();
        }

        public void updateClient(int id_client, client cli)
        {
            var query = "SELECT updateClient(" + id_client + ", '" + cli.first_name + "', '" + cli.second_name + "'" +
            ", '" + cli.first_last_name + "', '" + cli.second_last_name + "', '" + cli.birthdate.ToString("MM/dd/yyyy") +
            "', '" + cli.phone + "', '" + cli.residence + "');";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }

        public void deleteClient(int id_client)
        {
            var query = "SELECT deleteClient(" + id_client + ");";
            _context.Database.SqlQuery<Boolean>(query).FirstOrDefault();
        }
    }
}