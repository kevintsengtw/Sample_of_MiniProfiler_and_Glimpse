using Glimpse.Ado.AlternateType;
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

		public string ProviderName
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings["Northwind"].ProviderName;
			}
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

		public GlimpseDbConnection CreateGlimpseDbConnection()
		{
			return new GlimpseDbConnection(new SqlConnection(this.ConnectionString));
		}
	}
}