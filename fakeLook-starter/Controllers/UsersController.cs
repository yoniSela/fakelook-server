using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly UserRepository _repository;
        private ITokenService _tokenService { get; }


        public UsersController(UserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;

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

        [HttpPost]
        [Route("SaveUser")]
        public void Add(User item)
        {
            _repository.Add(item);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _repository.FindItem(user);
            if (dbUser == null) return Problem("user not in system");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }


        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp([FromBody] User user)
        {
            var dbUser = _repository.Post(user);
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }

        [HttpGet]
        [Route("GetToken")]
        public string SignUp(string token)
        {
            return _tokenService.GetPayload(token);
        }


    }
}
