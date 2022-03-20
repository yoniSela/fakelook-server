using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("likes")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeRepository _repository;
        public LikesController(ILikeRepository repository)
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
        [ResponseType(typeof(ICollection<Like>))]
        public JsonResult All()
        {
            var posts = _repository.GetAll();
            return new JsonResult(posts);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(Like like)
        {
            return new JsonResult(await _repository.Add(like));
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<JsonResult> Edit(Like like)
        {
            return new JsonResult(await _repository.Edit(like));
        }


    }
}
