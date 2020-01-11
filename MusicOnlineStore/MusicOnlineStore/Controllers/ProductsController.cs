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
    public class ProductsController : ControllerBase
    {
        private IProductsDataAccess _productsDataAccess;

        public ProductsController(IProductsDataAccess productsDataAccess)
        {
            _productsDataAccess = productsDataAccess;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productsDataAccess.GetProducts();
            return Ok(products);
        }
    }
}