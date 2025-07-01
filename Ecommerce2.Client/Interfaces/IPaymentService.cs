using ECommerce2.Shared.Dtos;

namespace ECommerce2.Client.Interfaces
{
	public interface IPaymentTicketService
	{
		Task<bool> Post(PaymentTicketDto PaymentTicketDto);
		Task<bool> CreateNewTicket(PaymentTicketDto PaymentTicketDto);
	}
}
