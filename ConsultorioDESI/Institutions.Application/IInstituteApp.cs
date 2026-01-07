using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institute.Domain;
using Common.Domain;

namespace Institutions.Application
{
    public interface IInstituteApp
    {
        IEnumerable<InstituteObj> GetAllInstitutions(out OperationResult result);
        InstituteObj GetInstitutionById(long id, out OperationResult result);
        //InstituteObj SaveOrUpdateInstitutions(InstituteObj obj);
    }
}
