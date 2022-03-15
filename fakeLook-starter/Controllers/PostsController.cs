using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repository;

        public PostsController(IPostRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        [Route("ById")]
        [ResponseType(typeof(Post))]
        public JsonResult ById(int id)
        {
            return new JsonResult(_repository.GetById(id));
        }

        [HttpGet]
        [Route("All")]
        [ResponseType(typeof(ICollection<Post>))]
        public JsonResult All()
        {
            var posts = _repository.GetAll();
            return new JsonResult(posts);
        }
        [HttpGet]
        [Route("ByPredicate")]
        public JsonResult GetByPredicate(Func<Post, bool> predicate)
        {
            return new JsonResult(_repository.GetByPredicate(predicate));

        }
        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(Post post)
        {
            return new JsonResult(await _repository.Add(post));
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<JsonResult> Edit(Post post)
        {
            return new JsonResult(await _repository.Edit(post));
        }


    }
}



