using Catalogs.Domain;
using Common.Domain;

namespace Catalogs.Messages
{
    public class CatalogsMessages
    {

    }

    public class CatalogsObjListResponse
    {
        public List<CatalogsObj> Companies { get; set; } 
        public OperationResult Result { get; set; } 
    }

    public class CatalogsObjResponse 
    {
        public CatalogsObj Company { get; set; }
        public OperationResult Result { get; set; }
    }
}
