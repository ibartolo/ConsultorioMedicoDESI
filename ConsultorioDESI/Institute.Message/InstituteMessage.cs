using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institute.Domain;
using Common.Domain;
namespace Institute.Message
{
    public class InstituteMessage
    {
        
    }

    public class InstituteObjListResponse
    {
        public List<InstituteObj> institutions { get; set; }
        public OperationResult Result { get; set; }
    }

    public class InstituteObjResponse
    {
        public InstituteObj institute { get; set; }
        public OperationResult Result { get; set; }
    }
}
