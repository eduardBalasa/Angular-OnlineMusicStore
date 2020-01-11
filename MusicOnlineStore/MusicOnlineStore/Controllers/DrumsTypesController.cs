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
    public class DrumsTypesController : ControllerBase
    {
        private IDrumsTypesDataAccess _drumsTypesDataAccess;
        public DrumsTypesController(IDrumsTypesDataAccess drumsTypesDataAccess)
        {
            _drumsTypesDataAccess = drumsTypesDataAccess;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drumsTypes = await _drumsTypesDataAccess.GetDrumsTypes();
            return Ok(drumsTypes);
        }
    }
}