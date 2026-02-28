using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Proxy
{
    public interface IPatientProxy
    {
        public DataTable GetAllPatients();
        public DataTable GetPatientById(long id);
    }
}
