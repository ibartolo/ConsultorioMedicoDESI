using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using FiscalData.Domain;
namespace FiscalData.Messages
{
    public class FiscalDataMessage
    {
        
    }

    public class FiscalDataObjListResponse()
    {
        public List<FiscalDataObj> FiscalDatas { get; set; }
        public OperationResult Result { get; set; }
    }

    public class FiscalDataObjResponse()
    {
        public FiscalDataObj FiscalData { get; set; }
        public OperationResult Result { get; set; }
    }
}
