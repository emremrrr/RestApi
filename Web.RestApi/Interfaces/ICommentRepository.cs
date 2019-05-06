using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public interface ICommentRepository:IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByTaskId(long id);
    }
}
