using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using fakeLook_starter.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Route("ByQuery")]
        [ResponseType(typeof(ICollection<Post>))]
        public JsonResult ByQuery(Query query)
        {
            var res = _repository.GetByPredicate((post) =>
            {
                bool date = query.CheckDates(post.Date, query.MaxDate, query.MinDate);
                bool user = query.PostBy(post.UserId, query.PublisherId);
                bool tags = query.conatinTags(post.Tags, query.FilterTags);
                //bool Usertags = query.conatinTags(post.UserTaggedPost, query.FilterUserTags);
                return date && user && tags;
            });
            Console.WriteLine(res);
            //var posts = _repository.GetByQuery(query);
            return new JsonResult(res.ToList());
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



