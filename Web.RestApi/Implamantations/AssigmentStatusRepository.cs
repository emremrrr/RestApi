using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class AssigmentStatusRepository : Repository<AssignmentStatus>, IAssigmentStatusRepository
    {
        private readonly AppDataContext _context;
        public AssigmentStatusRepository(AppDataContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<AssignmentStatus> AssignmentStatusses() => _context.AssignmentStatuses;
    }
}
