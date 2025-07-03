using ECommerce.Api.Data.Entities;
using ECommerce.Server.Data;
using ECommerce2.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentTicketController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PaymentTicketController> _logger;

        public PaymentTicketController(AppDbContext context, ILogger<PaymentTicketController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PaymentTicketDto paymentTicketDto)
        {
            try
            {
				var newTicket = new PaymentTicket
				{
					Id = Guid.NewGuid(),
					Bank = paymentTicketDto.Bank,
					Agency = paymentTicketDto.Agency,
					AccountNumber = paymentTicketDto.AccountNumber,
					Wallet = paymentTicketDto.Wallet,

					BeneficiaryName = paymentTicketDto.BeneficiaryName,
					BeneficiaryCprf = paymentTicketDto.BeneficiaryCprf,
					BeneficiaryAddressCep = paymentTicketDto.BeneficiaryAddressCep,
					BeneficiaryAddressUf = paymentTicketDto.BeneficiaryAddressUf,
					BeneficiaryAddressLocality = paymentTicketDto.BeneficiaryAddressLocality,
					BeneficiaryAddressNeighborhood = paymentTicketDto.BeneficiaryAddressNeighborhood,
					BeneficiaryAddressStreet = paymentTicketDto.BeneficiaryAddressStreet,
					BeneficiaryAddressNumber = paymentTicketDto.BeneficiaryAddressNumber,
					BeneficiaryAddresscomplement = paymentTicketDto.BeneficiaryAddresscomplement,

					TicketCreated = paymentTicketDto.TicketCreated.ToUniversalTime(),
					TicketDueDate = paymentTicketDto.TicketDueDate.ToUniversalTime(),
					TicketDocument = paymentTicketDto.TicketDocument,
					TicketNumber = paymentTicketDto.TicketNumber,
					TicketTitle = paymentTicketDto.TicketTitle,
					TicketValue = paymentTicketDto.TicketValue,
					TicketInstruction = paymentTicketDto.TicketInstruction,

					PayerName = paymentTicketDto.PayerName,
					PayerCprf = paymentTicketDto.PayerCprf,
					PayerAddressCep = paymentTicketDto.PayerAddressCep,
					PayerAddressUf = paymentTicketDto.PayerAddressUf,
					PayerAddressLocality = paymentTicketDto.PayerAddressLocality,
					PayerAddressNeighborhood = paymentTicketDto.PayerAddressNeighborhood,
					PayerAddressStreet = paymentTicketDto.PayerAddressStreet,
					PayerAddressNumber = paymentTicketDto.PayerAddressNumber,
					PayerAddresscomplement = paymentTicketDto.PayerAddresscomplement
				};

				await _context.PaymentTickets.AddAsync(newTicket);
				await _context.SaveChangesAsync();

				return Ok();
			}
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
				Console.WriteLine($"InnerException: {ex.InnerException}");
				throw;
			}
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
