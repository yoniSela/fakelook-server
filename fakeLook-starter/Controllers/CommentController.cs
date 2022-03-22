using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        public CommentController(ICommentRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        [Route("PostId")]
        public JsonResult PostId(int id)
        {
            return new JsonResult(_repository.GetByPostId(id));
        }
        [HttpGet]
        [Route("All")]
        [ResponseType(typeof(ICollection<Comment>))]
        public JsonResult All()
        {
            var comments = _repository.GetAll();
            return new JsonResult(comments);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(Comment comment)
        {
            return new JsonResult(await _repository.Add(comment));
        }
    }
}
