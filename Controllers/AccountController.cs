using System;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{

    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserRepository _repo;

        [HttpPost("Login")]
        public async Task<User> Login([FromBody]UserLogin creds)
        {
            if (!ModelState.IsValid) { throw new Exception("Invalid Credentials"); }
            User user = _repo.Login(creds);
            if (user == null) { throw new Exception("Invalid Credentials"); }
            user.SetClaims();
            await HttpContext.SignInAsync(user._principal);
            return user;
        }

        [HttpPost("Register")]
        public async Task<User> Register([FromBody]UserRegistration creds)
        {
            if (!ModelState.IsValid) { throw new Exception("Invalid Credentials"); }
            User user = _repo.Register(creds);
            if (user == null) { throw new Exception("Invalid Credentials"); }
            user.SetClaims();
            await HttpContext.SignInAsync(user._principal);
            return user;
        }

        [HttpDelete("Logout")]
        public async Task<bool> Logout()
        {
            await HttpContext.SignOutAsync();
            return true;
        }

        [Authorize]
        [HttpGet("Authenticate")]
        public User Authenticate()
        {
            var id = HttpContext.User.Identity.Name;
            return _repo.GetUserById(id);
        }

        public AccountController(UserRepository repo)
        {
            _repo = repo;
        }

    }
}