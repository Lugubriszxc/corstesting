using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using corsTesting.Models;

namespace corsTesting.Controllers
{
    public class ProductApiController : Controller
    {
        private readonly flutterprodContext _context;

        public ProductApiController(flutterprodContext context)
        {
            _context = context;
        }

        // // GET: ProductApi
        // [HttpGet]
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Products.ToListAsync());
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getProd()
        {
            return await _context.Products.OrderByDescending(q => q.ProductId).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var prodRes = await _context.Products.FindAsync(id);

            if(prodRes == null)
            {
                return NotFound();
            }

            return prodRes;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> postProd(Product prod)
        {
            _context.Products.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getProduct", new {id = prod.ProductId}, prod);
        }

        // // GET: ProductApi/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var product = await _context.Products
        //         .FirstOrDefaultAsync(m => m.ProductId == id);
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(product);
        // }

        // // GET: ProductApi/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // POST: ProductApi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ProductId,Productname,Stock,Status")] Product product)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(product);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(product);
        // }

        // // GET: ProductApi/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var product = await _context.Products.FindAsync(id);
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(product);
        // }

        // // POST: ProductApi/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ProductId,Productname,Stock,Status")] Product product)
        // {
        //     if (id != product.ProductId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(product);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ProductExists(product.ProductId))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(product);
        // }

        // // GET: ProductApi/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var product = await _context.Products
        //         .FirstOrDefaultAsync(m => m.ProductId == id);
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(product);
        // }

        // // POST: ProductApi/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var product = await _context.Products.FindAsync(id);
        //     _context.Products.Remove(product);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool ProductExists(int id)
        // {
        //     return _context.Products.Any(e => e.ProductId == id);
        // }
    }
}
