using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication1.Models.Repository
{
    public abstract class BaseRepository
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public BaseRepository()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        }

        public BaseRepository(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                this._connectionString = connectionString;
            }
        }

		public DbConnection GetOpenConnection()
		{
			var cnn = CreateRealConnection();
			return new StackExchange.Profiling.Data.ProfiledDbConnection(cnn, MiniProfiler.Current);
		}

		private DbConnection CreateRealConnection()
		{
			var conn = new SqlConnection(this.ConnectionString);
			return conn;
		}
    }
}