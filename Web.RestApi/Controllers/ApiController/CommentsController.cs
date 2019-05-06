using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.RestApi;

namespace Web.RestApi.Controllers.ApiController
{
    [Produces("application/json")]
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }



        [HttpPost]
        [Route("GetCommentsByTaskId")]
        public async Task<IEnumerable<Comment>> GetCommentsByTaskId([FromBody] Assignment param)
        {
            return await Task.FromResult(_commentRepository.GetCommentsByTaskId(param.ID));
        }



        // POST: api/Comments
        [HttpPost]
        [Route("SaveComment")]
        public async Task<IActionResult> SaveComment([FromBody]Comment param)
        {
            param.CommentDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _commentRepository.Add(param);
            _commentRepository.Save();
            return CreatedAtAction("GetComment", new { id = (param as Comment).ID }, param);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = _commentRepository.GetById(id) ;
            if (comment == null)
            {
                return NotFound();
            }

            _commentRepository.Remove(id);
             _commentRepository.Save();

            return Ok(comment);
        }

    }
}