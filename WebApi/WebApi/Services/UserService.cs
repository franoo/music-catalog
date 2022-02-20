using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IUserService
    {
        UserDTO VerifyUser(LoginRequest login);
        string HashPassword(string password);
    }
        public class UserService: IUserService
    {
        private DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserDTO VerifyUser(LoginRequest login) {

            //string passwordHash = this.HashPassword(login.Password);

            User user = _context.Users.SingleOrDefault(x => x.Username == login.Username);
            if (user != null && ValidatePassword(login.Password, user.PasswordSalt, user.PasswordHash))
            {
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            var saltString = Convert.ToBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");
            ValidatePassword(password, saltString, hashed);
            return hashed;
        }
        private bool ValidatePassword(string password, string salt, string hash)
        {
            var saltByte = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            if (hashed == hash)
            {
                Console.WriteLine("Hashed: zgodne");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
