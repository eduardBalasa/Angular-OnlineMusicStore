using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicOnlineStore.DataAccess;
using MusicOnlineStore.Models;

namespace MusicOnlineStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryDataAccess _categoryDataAccess;
        public CategoriesController(ICategoryDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryDataAccess.GetCategories();
            return Ok(categories);
        }
    }
}
