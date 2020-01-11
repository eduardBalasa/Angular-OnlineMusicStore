using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MusicOnlineStore.Entities;
using MusicOnlineStore.Helpers;
using MusicOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly AppSettings _appSettings;

        public UserDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<User>> GetUsers()
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var c = await cnn.QueryAsync<User>("dbo.getUsers",
                commandType: CommandType.StoredProcedure);

                return c.ToList();
            }
        }

        public async Task<string> InsertUser(RegisterModel user)
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Username", user.Username);
                p.Add("@FirstName", user.FirstName);
                p.Add("@LastName", user.LastName);
                p.Add("@Email", user.Email);
                p.Add("@Password", user.Password);
                p.Add("@Result", "result", direction: ParameterDirection.Output);
                await cnn.QueryAsync<string>(
                    "dbo.userRegistration",
                    p,
                    commandType: CommandType.StoredProcedure);

                var res = p.Get<string>("@Result");
                return res;
            }
        }
    }
}