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
    public class OrchestrateTypesDataAccess : IOrchestrateTypesDataAccess
    {
        private readonly AppSettings _appSettings;

        public OrchestrateTypesDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<OrchestrateTypes>> GetOrchestrateTypes()
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var c = await cnn.QueryAsync<OrchestrateTypes>("dbo.getOrchestrateTypes",
                commandType: CommandType.StoredProcedure);

                return c.ToList();
            }
        }

    }
}

