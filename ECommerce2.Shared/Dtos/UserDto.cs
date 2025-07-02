namespace ECommerce2.Shared.Dtos
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Cpf { get; set; } = string.Empty;
		public string AddressCep { get; set; } = string.Empty;
		public string AddressUf { get; set; } = string.Empty;
		public string AddressLocality { get; set; } = string.Empty;
		public string AddressNeighborhood { get; set; } = string.Empty;
		public string AddressStreet { get; set; } = string.Empty;
		public string AddressNumber { get; set; } = string.Empty;
		public string AddressComplement { get; set; } = string.Empty;
	}
}
