using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
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

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("ById")]
        [ResponseType(typeof(User))]
        public JsonResult ById(int id)
        {
            return new JsonResult(_repository.GetById(id));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("ByUsername")]
        [ResponseType(typeof(User))]
        public JsonResult ByName(string name)
        {
            return new JsonResult(_repository.GetByName(name));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("All")]
        [ResponseType(typeof(ICollection<User>))]
        public JsonResult All()
        {
            return new JsonResult(_repository.GetAll());
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("SaveUser")]
        public void Add(User item)
        {
            _repository.Add(item);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Login")]
        public IActionResult Login([Microsoft.AspNetCore.Mvc.FromBody] User user)
        {
            var dbUser = _repository.FindItem(user);
            if (dbUser == null) return Problem("user not in system");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("SignUp")]
        public IActionResult SignUp([Microsoft.AspNetCore.Mvc.FromBody] User user)
        {
            var dbUser = _repository.Post(user);
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetToken")]
        public string SignUp(string token)
        {
            try
            {
                return _tokenService.GetPayload(token);
            } catch
            {
                return "Error";
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("Edit")]
        public async Task<JsonResult> Edit(User user)
        {
            return new JsonResult(await _repository.Edit(user));
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetDIct")]
        public async Task<JsonResult> GetDIct()
        {
            return new JsonResult(_repository.GetUserNames());
        }

    }
}
