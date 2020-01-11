using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MusicOnlineStore.Helpers;
using MusicOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.DataAccess
{
    public class GuitarsTypesDataAccess : IGuitarsTypesDataAccess
    {
        private readonly AppSettings _appSettings;

        public GuitarsTypesDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<GuitarsTypes>> GetGuitarsTypes()
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var c = await cnn.QueryAsync<GuitarsTypes>("dbo.getGuitarsTypes",
                commandType: CommandType.StoredProcedure);

                return c.ToList();
            }
        }

    }
}
