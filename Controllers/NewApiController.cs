using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using corsTesting.Models;


namespace corsTesting.Controllers
{
    [EnableCors]
    [Route("api/[controller]/[action]")]
    public class NewApiController : ControllerBase
    {
        private readonly flutterprodContext _context;
        public NewApiController(flutterprodContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> getCors(string val){
        var data = new { message = val };

        return new JsonResult(data);
        }

        // public async Task<ActionResult> getProd(){
        //     return _context.Products.OrderByDescending(q => q.ProductId).ToList();
        // }

        public ActionResult<List<Product>> getProd(){
            return  _context.Products.ToList();
        }

        // public async Task<ActionResult<Product>> postProd(Product prod)
        // {
        //     // _context.Products.Add(wow);
        //     // await _context.SaveChangesAsync();

        //     //return CreatedAtAction("getProduct", new {id = prod.ProductId}, prod);
        //     return Ok();
        // }

        //[HttPost("postprod")]
        public async Task<IActionResult> postprod(Product prod)
        {
            // prod.Productname = "New val";
            // prod.Status = "Married";

            if(prod == null)
            {
                return BadRequest("Invalid JSON data");
            }

            if(string.IsNullOrEmpty(prod.Productname)){
                return BadRequest("Productname cannot be null or empty");
            }

            _context.Products.Add(prod);
            _context.SaveChanges();

            return CreatedAtAction("getProduct", new {id = prod.ProductId}, prod);
            //return Ok("Product added succesfully");
        }

        public async Task<IActionResult> updateProd(Product prod)
        {
            if(prod != null){
                _context.Products.Update(prod);
                _context.SaveChanges();
            }

            return Ok(prod);
        }

        public IActionResult getProduct(int id)
        {
            var productRes = _context.Products.FindAsync(id);

            if(productRes == null)
            {
                return BadRequest("The value is not found");
            }

            return Ok(productRes);
        }

        public IActionResult deleteProd(int id){
            //_context.Products.Remove(_context.Products.Find(id));
            var productRes = _context.Products.Where(element => element.ProductId == id).FirstOrDefault();
            _context.Products.Remove(productRes);
            _context.SaveChanges();

            return Ok();
        }

        public ActionResult<List<Product>> getProdActive(){
            var productRes = _context.Products.Where(element => element.Status == "Active" && element.Stock != 0).ToList();
            return Ok(productRes);
        }

        public ActionResult<List<Product>> getProdOutOfStock(){
            var productRes = _context.Products.Where(element => element.Stock <= 0).ToList();
            return Ok(productRes);
        }

        // public async TaskActionResult<List<Dean>> getDeans(){
        //     return  _context.Deans.ToList();
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Product>>> getprod()
        // {
        //     return _context.Products.OrderByDescending(q => q.ProductId).ToListAsync();
        // }
    }
}