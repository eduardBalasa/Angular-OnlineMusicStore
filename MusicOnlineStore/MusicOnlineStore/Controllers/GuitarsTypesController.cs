using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicOnlineStore.DataAccess;

namespace MusicOnlineStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuitarsTypesController : ControllerBase
    {
        private IGuitarsTypesDataAccess _guitarsTypesDataAccess;
        public GuitarsTypesController(IGuitarsTypesDataAccess guitarsTypesDataAccess)
        {
            _guitarsTypesDataAccess = guitarsTypesDataAccess;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guitarsTypes = await _guitarsTypesDataAccess.GetGuitarsTypes();
            return Ok(guitarsTypes);
        }
    }
}
