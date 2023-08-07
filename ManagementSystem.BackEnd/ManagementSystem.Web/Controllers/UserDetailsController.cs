using ManagementSystem.Data.DbContext;
using ManagementSystem.Mapping.DTOs;
using ManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ManagementSystem.Web.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _service;

        public UserDetailsController(IUserDetailsService service) 
        {
            _service = service;
        }


        [HttpPost("api/createUser")]
        public ActionResult<UserDetailsDto> Create([FromBody] UserDetailsDto userDto) 
        { 
            var _user = _service.Create(userDto);
            return Ok(_user);
        }

        [HttpPost("api/updateUser")]
        public ActionResult<UserDetailsDto> Update([FromBody] UserDetailsDto userDto)
        {
            var _user = _service.Update(userDto);
            return Ok(_user);
        }

        [HttpGet("api/getUserDetails/{Id:int}")]
        public ActionResult<UserDetailsDto> Get(int Id)
        {
            var _user = _service.Get(Id);
            return Ok(_user);
        }

    }
}
