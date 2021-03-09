using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sbs.Api.Data.Entities;
using Sbs.Api.Models;
using Sbs.Api.Repositories;
using System;
using System.Threading.Tasks;

namespace Sbs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ISbsDbRepository _repository;
        private readonly IMapper _mapper;

        public LoginController(ISbsDbRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public string[] Get()
        {
            return new[] { "Api is running" };
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> ValidateUser([FromBody] LoginModel loginModel)
        {
            var user = await _repository.ValidateUserAsync(loginModel);

            if (user == null)
                return BadRequest(new { Message = "Username or password is incorrect." });

            return Ok(new User
            {
                Id = user.Id,
                LoginName = user.LoginName,
                Name = user.Name
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel registerUser)
        {

            var user = _mapper.Map<User>(registerUser);

            if (!_repository.IsLoginNameExists(user.LoginName))
            {
                try
                {
                    // create user
                    _repository.Add<User>(user);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"/api/login/{user.LoginName}", registerUser);
                    }
                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
                }
            }

            return BadRequest(new { Message = "Login name already Exists." });
        }
    }
}
