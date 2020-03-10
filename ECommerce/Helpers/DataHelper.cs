using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Helpers
{
    public class DataHelper
    {
        private string DbConnString { get; set; }
        public SqlConnection DbConn { get; set; }

        public DataHelper(IConfiguration iConfig)
        {
            DbConnString = iConfig.GetValue<string>("ConnectionStrings:ECommerceDatabase");
            DbConn = new SqlConnection(DbConnString);
        }
    }

}
