using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalData.Proxy
{
    public interface IFiscalDataProxy
    {
        DataTable GetAllFiscalData();
        DataTable GetFiscalDataById(long id);
    }
}
