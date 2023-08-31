using APIBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookstoreController : ControllerBase
    {
        private readonly TodoContext _context;

        public bookstoreController(TodoContext context)
        {
            _context = context;

            foreach (Product x in _context.TodoProducts)
                _context.TodoProducts.Remove(x);
            _context.SaveChanges();

            _context.TodoProducts.Add(new Product { Id = "1", Name = "Sherlock Holmes 1", Price = 24, Quantity = 1, Category = "Crime", Img = "img1" });
            _context.TodoProducts.Add(new Product { Id = "2", Name = "O Mundo de Sofia", Price = 50, Quantity = 1, Category = "Aventrua", Img = "img2" });
            _context.TodoProducts.Add(new Product { Id = "3", Name = "Arsène Luín", Price = 20, Quantity = 2, Category = "Suspense", Img = "img3" });
            _context.TodoProducts.Add(new Product { Id = "4", Name = "Sherlock Holmes 2", Price = 10, Quantity = 1, Category = "action", Img = "img1" });
            _context.TodoProducts.Add(new Product { Id = "5", Name = "Sherlock Holmes 3", Price = 15, Quantity = 5, Category = "action", Img = "img1" });

            _context.SaveChanges();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.TodoProducts.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdut), new { id = product.Id }, product);
        }

        // GET: api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTodoItems()
        {
            return await _context.TodoProducts.ToListAsync();
        }

        // GET: api/bookstore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdut(int id)
        {
            var todoItem = await _context.TodoProducts.FindAsync(id.ToString());

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}