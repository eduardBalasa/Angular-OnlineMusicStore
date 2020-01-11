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
    public class ProductsDataAccess : IProductsDataAccess
    {
        private readonly AppSettings _appSettings;

        public ProductsDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<Products>> GetProducts()
        {
            using (var cnn = new SqlConnection(_appSettings.ConnectionString))
            {
                var c = await cnn.QueryAsync<Products>("dbo.getProducts",
                commandType: CommandType.StoredProcedure);

                return c.ToList();
            }
        }
    }
}
