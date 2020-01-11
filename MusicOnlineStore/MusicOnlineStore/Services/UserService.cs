using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MusicOnlineStore.DataAccess;
using MusicOnlineStore.Entities;
using MusicOnlineStore.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicOnlineStore.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
    }

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private IUserDataAccess _userDataAccess;
        private List<User> _users;
        public UserService(IOptions<AppSettings> appSettings, IUserDataAccess userDataAccess)
        {
            _appSettings = appSettings.Value;
            _userDataAccess = userDataAccess;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            _users = await _userDataAccess.GetUsers();
            var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            _users = await _userDataAccess.GetUsers();
            return _users.WithoutPasswords();
        }

        public async Task<User> GetById(int id)
        {
            _users = await _userDataAccess.GetUsers();
            var user = _users.FirstOrDefault(x => x.UserID == id);
            return user.WithoutPassword();
        }
    }
}
