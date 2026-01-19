using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;
using Common.Domain;

namespace User.Messages
{
    public class UserMessage
    {
        
    }

    public class UserObjListResponse()
    {
        public List<UserObj> users { get; set; }
        public OperationResult result { get; set; }
    }

    public class UserObjResponse()
    {
        public UserObj user { get; set; }
        public OperationResult result { get; set; }
    }
}
