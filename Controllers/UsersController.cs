using FileSharingWebApi.Models;
using FileSharingWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace FileSharingWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly FileSharingDbContext _context;
        public UsersController(FileSharingDbContext context)
        {
            _context = context;
        }
    }
}
