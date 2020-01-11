using MusicOnlineStore.Entities;
using MusicOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.DataAccess
{
    public interface IUserDataAccess
    {
        Task<List<User>> GetUsers();
        Task<string> InsertUser(RegisterModel user);
    }
}
