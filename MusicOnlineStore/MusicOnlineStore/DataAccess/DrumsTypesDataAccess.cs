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
    public class DrumsTypesDataAccess : IDrumsTypesDataAccess
    {
        private readonly AppSettings _appSettings;

        public DrumsTypesDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<DrumsTypes>> GetDrumsTypes()
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var c = await cnn.QueryAsync<DrumsTypes>("dbo.getDrumsTypes",
                commandType: CommandType.StoredProcedure);

                return c.ToList();
            }
        }

    }
}
