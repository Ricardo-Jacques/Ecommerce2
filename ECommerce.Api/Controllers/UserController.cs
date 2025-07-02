using ECommerce.Server.Data;
using ECommerce2.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(AppDbContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("get-logged-user/{email}")]
        public async Task<ActionResult<UserDto>> GetLoggedUser(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email)
                .Select(x => new UserDto
                {
					Id = x.Id,
                    Email = x.Email,
					Name = x.Name,
					Cpf = x.Cpf,
					AddressCep = x.AddressCep,
					AddressUf = x.AddressUf,
					AddressLocality = x.AddressLocality,
					AddressNeighborhood = x.AddressNeighborhood,
					AddressStreet = x.AddressStreet,
					AddressNumber = x.AddressNumber,
					AddressComplement = x.AddressComplement

				}).FirstOrDefaultAsync();

            return Ok(user);
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
