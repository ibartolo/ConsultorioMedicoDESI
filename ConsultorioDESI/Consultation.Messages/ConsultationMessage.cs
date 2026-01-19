using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Domain;
using Common.Domain;

namespace Consultation.Messages
{
    public class ConsultationMessage
    {

    }

    public class ConsultationObjListResponse() 
    {
        public List<ConsultationObj> Consultations { get; set; }
        public OperationResult Result { get; set; }
    }

    public class ConsultationObjResponse()
    {
        public ConsultationObj Consultation { get; set; }
        public OperationResult Result { get; set; }
    }

}
