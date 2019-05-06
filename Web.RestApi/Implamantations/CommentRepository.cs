using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class CommentRepository:Repository<Comment>,ICommentRepository
    {
        private readonly AppDataContext _context;
        public CommentRepository(AppDataContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentsByTaskId(long id)
        {
            return _context.Comments.OrderBy(p => p.CommentDate);
        }
    }
}
