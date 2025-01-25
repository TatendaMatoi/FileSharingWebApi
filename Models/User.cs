using System.Text.Json.Serialization;
using FileSharingWebApi.Utilities;

namespace FileSharingWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public void SetPassword(string password, PasswordHasher passwordHasher)
        {
            var (passwordHash, passwordSalt) = passwordHasher.HashPassword(password);
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public bool VerifyPassword(string password, PasswordHasher passwordHasher)
        {
            return passwordHasher.VerifyPasswordHash(password, PasswordHash, PasswordSalt);
        }
    }


}
