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
    public class MicrophonesTypesDataAccess : IMicrophonesTypesDataAccess
    {
        private readonly AppSettings _appSettings;

        public MicrophonesTypesDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<MicrophonesTypes>> GetMicrophonesTypes()
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var c = await cnn.QueryAsync<MicrophonesTypes>("dbo.getMicrophonesTypes",
                commandType: CommandType.StoredProcedure);

                return c.ToList();
            }
        }

    }
}

