using Common.Domain;
using Consultation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Application
{
    public interface IConsultationApp
    {
        IEnumerable<ConsultationObj> GetAllConsultations(out OperationResult result);
        ConsultationObj GetConsultationById(long id, out OperationResult result);

    }
}
