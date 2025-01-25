using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using FileSharingWebApi.Data;
using FileSharingWebApi.Models;
using FileSharingWebApi.Utilities;
using System.Security.Cryptography;

namespace FileSharingWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FileSharingDbContext _context;

        public AuthController(FileSharingDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Username is already taken");
            }

            var passwordHasher = new PasswordHasher();
            user.SetPassword(user.Password, passwordHasher);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


    }
}
