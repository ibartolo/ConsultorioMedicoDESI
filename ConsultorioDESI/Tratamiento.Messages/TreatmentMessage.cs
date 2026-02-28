using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Treatment.Domain;

namespace Treatment.Messages
{
    public class TreatmentMessage
    {
        
    }

    public class TreatmentObjListResponse()
    {
        public List<TreatmentObj> treatments { get; set; }
        public OperationResult result { get; set; }
    }

    public class TreatmentObjResponse()
    {
        public TreatmentObj treatment { get; set; }
        public OperationResult result { get; set; }
    }
}
