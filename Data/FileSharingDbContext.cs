using Microsoft.EntityFrameworkCore;
using FileSharingWebApi.Models;

namespace FileSharingWebApi.Data
{
    public class FileSharingDbContext : DbContext
    {
        public FileSharingDbContext(DbContextOptions<FileSharingDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
