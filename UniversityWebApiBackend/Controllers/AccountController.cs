using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebApiBackend.DataAccess;
using UniversityWebApiBackend.Helpers;
using UniversityWebApiBackend.Models.DataModels;

namespace UniversityWebApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;
        public AccountController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        // Examples: Change users in DB
        private IEnumerable<Users> Logins = new List<Users>()
        {
            new Users()
            {
                Id = 1,
                Email = "zijaham_link@hotmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new Users()
            {
                Id = 2,
                Email = "pepe_minecraft@hotmail.com",
                Name = "User1",
                Password = "pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var token = new UserTokens();

                // Search a user in context with LINQ
                var searchUser = (from user in _context.Users
                                 where user.Name == userLogins.UserName && user.Password == userLogins.Password
                                 select user).FirstOrDefault();

                Console.WriteLine($"User found: {searchUser}");

                // var valid = Logins.Any(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                if (searchUser != null)
                {
                    //var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                    
                    token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Account/Password");
                }
                return Ok(token);
            }
            catch(Exception ex)
            {
                throw new Exception("Get token Error",ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
