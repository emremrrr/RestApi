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
    public class TestController : ControllerBase
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public TestController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        [Route("TestGet")]
        public object TestGet()
        {
            return _assignmentRepository.Get();
        }
    }
}