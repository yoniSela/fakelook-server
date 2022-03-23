using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _repository;
        public TagsController(ITagRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("ById")]
        [ResponseType(typeof(Tag))]
        public JsonResult ById(int id)
        {
            return new JsonResult(_repository.GetById(id));
        }


        [HttpGet]
        [Route("All")]
        [ResponseType(typeof(ICollection<Tag>))]
        public JsonResult All()
        {
            var tags = _repository.GetAll();
            return new JsonResult(tags);
        }

        [HttpGet]
        [Route("ByPredicate")]
        public JsonResult GetByPredicate(Func<Tag, bool> predicate)
        {
            return new JsonResult(_repository.GetByPredicate(predicate));

        }
        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(Tag tag)
        {
            return new JsonResult(await _repository.Add(tag));
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<JsonResult> Edit(Tag tag)
        {
            return new JsonResult(await _repository.Edit(tag));
        }

        [HttpGet]
        [Route("ByPost")]
        public async Task<JsonResult> ByPostId(int id)
        {
            return new JsonResult(_repository.GetByPost(id));
        }

        [HttpGet]
        [Route("ByComment")]
        public async Task<JsonResult> ByCommentId(int id)
        {
            return new JsonResult(_repository.GetByComment(id));
        }




    }
}
