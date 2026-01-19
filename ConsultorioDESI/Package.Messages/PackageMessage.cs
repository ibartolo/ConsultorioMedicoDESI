using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Package.Domain;


namespace Package.Messages
{
    public class PackageMessage
    {
        
    }

    public class PackageObjListResponse
    {
        public List<PackageObj> packages { get; set; }
        public OperationResult result { get; set; }
    }

    public class PackageObjResponse
    {
        public PackageObj package { get; set; }
        public OperationResult result { get; set; }
    }
}
