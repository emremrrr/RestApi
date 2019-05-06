using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        private readonly AppDataContext _context;
        public CompanyRepository(AppDataContext context):base(context)
        {
            _context = context;
        }
    }
}
