using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
       
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        [Route("ById")]
        [ResponseType(typeof(User))]
        public JsonResult ById(int id)
        {
            return new JsonResult(_repository.GetById(id));
        }

        [HttpGet]
        [Route("All")]
        [ResponseType(typeof(ICollection<User>))]
        public JsonResult All()
        {
            return new JsonResult(_repository.GetAll());
        }

       
    }
}
