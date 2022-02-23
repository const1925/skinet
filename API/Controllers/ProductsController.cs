using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
//using API.Data;
//using API.Entities;
using Infrastructure.Data;
using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers

{
    [ApiController]
    
    [Route("api/[controller]")]
    /*[Route("api/[controller]")]*/

    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
     
        public ProductsController (StoreContext context)
        {

            _context = context;

        }

        [HttpGet]
        //public string GetProducts()
        //public ActionResult<List<Product>> GetProducts()
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //return "this will be a list of products";

            //var products = _context.Products.ToList();
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        //public string GetProduct(int id)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //return "single product";
            return await _context.Products.FindAsync(id);
        }
    
    }
}