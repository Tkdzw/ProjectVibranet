using ManagementSystem.Mapping.DTOs;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpGet("api/getUser/{Id:int}")]
        public ActionResult<UserDto> GetUser(int Id)
        {
            var _user = _service.Get(Id);
            return Ok(_user);
        }

        [HttpPost("api/login")]
        public ActionResult<UserDto> Login(UserDto user)
        {
            var _user = _service.Login(user);
            return Ok(_user);
        }

    }
}
