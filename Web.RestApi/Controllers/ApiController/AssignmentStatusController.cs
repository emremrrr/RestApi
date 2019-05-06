using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.RestApi.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentStatusController : ControllerBase
    {
        private readonly IAssigmentStatusRepository _assigmentStatusRepository;

        public AssignmentStatusController( IAssigmentStatusRepository assigmentStatusRepository)
        {
            _assigmentStatusRepository = assigmentStatusRepository;
        }
        [HttpPost]
        [Route("GetAssignmentStatus")]
        public async Task<IEnumerable<AssignmentStatus>> GetAssignmentStatus() => await Task.FromResult(_assigmentStatusRepository.Get());
    }
}