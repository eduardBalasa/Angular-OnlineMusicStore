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
    public class MicrophonesTypesController : ControllerBase
    {
        private IMicrophonesTypesDataAccess _microphonesTypesDataAccess;
        public MicrophonesTypesController(IMicrophonesTypesDataAccess microphonesTypesDataAccess)
        {
            _microphonesTypesDataAccess = microphonesTypesDataAccess;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var microphonesTypes = await _microphonesTypesDataAccess.GetMicrophonesTypes();
            return Ok(microphonesTypes);
        }
    }
}