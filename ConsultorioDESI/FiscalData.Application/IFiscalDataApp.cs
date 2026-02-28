using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiscalData.Domain;
using Common.Domain;

namespace FiscalData.Application
{
    public interface IFiscalDataApp
    {
        List<FiscalDataObj> GetAllFiscalData(out OperationResult result);
        FiscalDataObj GetFiscalDataById(long id, out OperationResult result);
    }
}
