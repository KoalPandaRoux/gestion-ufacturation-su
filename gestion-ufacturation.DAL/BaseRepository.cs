using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_ufacturation.DAL
{
    public class BaseRepository
    {
        private static string connectionString = "server=localhost;user=root;database=gestion-facturation;password=";
        protected MySqlConnection connection = new MySqlConnection(connectionString);
    }
}
