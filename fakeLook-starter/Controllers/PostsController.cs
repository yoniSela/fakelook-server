using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
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
            return new JsonResult(_repository.GetAll());
        }
        [HttpGet]
        [Route("ByPredicate")]
        public JsonResult GetByPredicate(Func<Post, bool> predicate)
        {
            return new JsonResult(_repository.GetByPredicate(predicate));

        }
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Post post)
        {
            return new JsonResult(_repository.Add(post));
        }
        [HttpPut]
        [Route("Edit")]
        public JsonResult Edit(Post post)
        {
            return new JsonResult(_repository.Edit(post));
        }
       

    }
}
