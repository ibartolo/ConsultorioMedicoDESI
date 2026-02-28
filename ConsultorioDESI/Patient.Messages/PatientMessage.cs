using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Patient.Domain;

namespace Patient.Messages
{
    public class PatientMessage
    {

    }

    public class PatientObjListResponse()
    {
        public List<PatientObj> Patients { get; set; }
        public OperationResult Result { get; set; }
    }

    public class PatientObjResponse()
    {
        public PatientObj patient { get; set; }
        public OperationResult Result { get; set; }
    }
}
