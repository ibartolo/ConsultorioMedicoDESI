using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Proxy
{
    public interface ICatalogsProxy
    {
        public DataTable GetAllCompanies();
        public DataTable GetCompanyById(long id);
        //implemetar el metodo SaveOrUpdateCompany
        //public DataTable SaveOrUpdateCompany();
    }
}
