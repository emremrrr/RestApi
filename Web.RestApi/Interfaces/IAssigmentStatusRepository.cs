using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public interface IAssigmentStatusRepository : IRepository<AssignmentStatus>  
    {
        IEnumerable<AssignmentStatus> AssignmentStatusses();
    }
}
