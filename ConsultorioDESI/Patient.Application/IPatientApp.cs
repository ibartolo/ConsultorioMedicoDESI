using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient.Domain;

namespace Patient.Application
{
    public interface IPatientApp
    {
        IEnumerable<PatientObj> GetAllPatients(out OperationResult result);
        PatientObj GetPatientById(long id, out OperationResult result);
    }
}
