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
    public class OrchestrateTypesController : ControllerBase
    {
        private IOrchestrateTypesDataAccess _orchestrateTypesDataAccess;
        public OrchestrateTypesController(IOrchestrateTypesDataAccess orchestrateTypesDataAccess)
        {
            _orchestrateTypesDataAccess = orchestrateTypesDataAccess;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orchestrateTypes = await _orchestrateTypesDataAccess.GetOrchestrateTypes();
            return Ok(orchestrateTypes);
        }
    }
}