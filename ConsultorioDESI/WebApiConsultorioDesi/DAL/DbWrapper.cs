using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.DAL
{
	public partial class DbWrapper : BaseDbWrapper
    {
        protected override string SQLConnectionString { get; }
        protected override TimeSpan SQLCommandTimeOut { get; }

        public DbWrapper()
        {
            SQLConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cCon"].ToString();
            SQLCommandTimeOut = TimeSpan.FromSeconds(15);
        }
    }
}