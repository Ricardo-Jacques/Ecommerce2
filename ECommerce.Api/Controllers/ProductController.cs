using ECommerce.Server.Data;
using ECommerce2.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(AppDbContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            var product = await _context.Products.Where(x => x.Id == id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Code = x.Code,
                    Photo = x.Photo
                }).FirstOrDefaultAsync();

            return Ok(product);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _context.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Code = x.Code,
                    Photo = x.Photo
                })
                .ToListAsync();

            return Ok(products);
        }
    }
}
