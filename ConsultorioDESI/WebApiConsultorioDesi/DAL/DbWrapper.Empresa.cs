using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.DAL
{
	public partial class DbWrapper
	{
		public void GetAllEmpresa()
		{
			var response = GetObjects("GetAllEmpresa", System.Data.CommandType.StoredProcedure,
				new Func<System.Data.IDataReader, ObjEmpresa>((reader) =>
				{
					return new ObjEmpresa();
				}));
		}

    }
}