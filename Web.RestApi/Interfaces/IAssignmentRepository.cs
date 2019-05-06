using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public interface IAssignmentRepository:IRepository<Assignment>  
    {
        IEnumerable<object> GetAssignments();
        IEnumerable<object> GetTaskByCompanyId(long id);
    }
}
