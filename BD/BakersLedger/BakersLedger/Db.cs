using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BakersLedger
{
    public class Db
    {
        private string? _connString = null;

        public Db(string connString, out string? exMessage)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();

                _connString = connString;

                exMessage = null;
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }
        }

        public DataTable RetrieveAll(string cmdText)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            var dataTable = new DataTable();

            using (var cmd = new NpgsqlCommand(cmdText, conn))
            {
                try
                {
                    dataTable.Load(cmd.ExecuteReader());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return dataTable;
        }
    }
}
