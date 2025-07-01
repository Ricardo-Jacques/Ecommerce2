namespace ECommerce2.Shared.Dtos
{
	public class PaymentTicketDto
	{
		public Guid Id { get; set; }
		//BankAccount
		public string Bank { get; set; } = string.Empty;
		public string Agency { get; set; } = string.Empty;
		public string AccountNumber { get; set; } = string.Empty;
		public string bank { get; set; } = string.Empty;
		public string Wallet { get; set; } = string.Empty;

		//Beneficiary
		public string BeneficiaryName { get; set; } = string.Empty;
		public string BeneficiaryCprf { get; set; } = string.Empty;
		public string BeneficiaryAddressCep { get; set; } = string.Empty;
		public string BeneficiaryAddressUf { get; set; } = string.Empty;
		public string BeneficiaryAddressLocality { get; set; } = string.Empty;
		public string BeneficiaryAddressNeighborhood { get; set; } = string.Empty;
		public string BeneficiaryAddressStreet { get; set; } = string.Empty;
		public string BeneficiaryAddressNumber { get; set; } = string.Empty;
		public string BeneficiaryAddresscomplement { get; set; } = string.Empty;

		//Ticket
		public DateTime TicketCreated { get; set; }
		public DateTime TicketDueDate { get; set; }
		public string TicketDocument { get; set; } = string.Empty;
		public string TicketNumber { get; set; } = string.Empty;
		public string TicketTitle { get; set; } = string.Empty;
		public double TicketValue { get; set; }
		public string TicketInstruction { get; set; } = string.Empty;

		//Payer
		public string PayerName { get; set; } = string.Empty;
		public string PayerCprf { get; set; } = string.Empty;
		public string PayerAddressCep { get; set; } = string.Empty;
		public string PayerAddressUf { get; set; } = string.Empty;
		public string PayerAddressLocality { get; set; } = string.Empty;
		public string PayerAddressNeighborhood { get; set; } = string.Empty;
		public string PayerAddressStreet { get; set; } = string.Empty;
		public string PayerAddressNumber { get; set; } = string.Empty;
		public string PayerAddresscomplement { get; set; } = string.Empty;
	}
}