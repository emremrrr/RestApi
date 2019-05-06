using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class AssigmentRepository : Repository<Assignment>,IAssignmentRepository
    {
        private readonly AppDataContext _context;
        public AssigmentRepository(AppDataContext context):base(context)
        {
            _context = context;
        }
        public IEnumerable<object> GetAssignments()
        {
            var assignments= _context.Assignments.Select(a => new { a.AssingTo,  a.Description, a.ID, a.TaskClosedDate, a.TaskCreatedDate,  a.TaskTitle, a.AssignmentStatus.AssignmentStatusDisplayName,a.Company.CompanyName ,a.Comment}).AsEnumerable();
            return assignments;
        }

        public IEnumerable<object> GetTaskByCompanyId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
