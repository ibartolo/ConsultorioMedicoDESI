using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute.Proxy
{
    public interface IInstituteProxy
    {
        public DataTable GetAllInstitutions();
        public DataTable GetInstitutionById(long id);
    }
}
