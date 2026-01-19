using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treatment.Domain;
using Common.Domain;

namespace Treatment.Application
{
    public interface ITreatmentApp
    {
        List<TreatmentObj> GetAllTreatments(out OperationResult result);
        TreatmentObj GetTreatmentById(long id, out OperationResult result);
    }
}
