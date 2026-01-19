using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treatment.Proxy
{
    public interface ITreatmentProxy
    {
        DataTable GetAllTreatments();
        DataTable GetTreatmentById(long id);
    }
}
