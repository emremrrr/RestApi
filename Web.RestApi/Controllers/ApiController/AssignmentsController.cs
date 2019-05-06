using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.RestApi;
using Newtonsoft.Json;

namespace Web.RestApi.Controllers.ApiController
{
    [Produces("application/json")]
    [Route("api/Assignments")]
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentsController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
            //_context = context;
        }

        // GET: api/Assignments
        [HttpPost]
        [Route("GetAssignments")]
        public async Task<object> GetAssignments() => await Task.FromResult<object>(_assignmentRepository.GetAssignments());


        // POST: api/Assignments
        [HttpPost]
        [Route("GetTaskByCompanyId")]
        public async Task<IEnumerable<object>> GetTaskByCompanyId([FromBody]Company company)
        {
            return await Task.FromResult<IEnumerable<object>>(null);
        }

        // POST: api/Assignments
        [HttpPost]
        [Route("PostAssignment")]
        public async Task<IActionResult> PostAssignment([FromBody]Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _assignmentRepository.Add(assignment);
            _assignmentRepository.Save();
            return CreatedAtAction("GetAssignment", new { id = 1 }, assignment);
        }

        [HttpPost]
        [Route("UapdateAssignment")]
        public async Task<IActionResult> UapdateAssignment([FromBody]Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assignment.AssignmentStatus.AssignmentStatusDisplayName == "Done")
                assignment.IsActive = false;
            else
                assignment.IsActive = true;

            _assignmentRepository.Update(assignment);
            _assignmentRepository.Save();
            return CreatedAtAction("GetAssignment", new { id = 1 }, assignment);
        }
        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = _assignmentRepository.GetById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            assignment.IsDeleted = true;
            assignment.IsActive = false;
            _assignmentRepository.Remove(id);
            _assignmentRepository.Save();
            return Ok(assignment);
        }

    }

}