using ECommerce2.Client.Interfaces;
using ECommerce2.Shared.Dtos;
using System.Net.Http.Json;

namespace ECommerce2.Client.Services
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;

		public AuthService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> Login(string email, string password)
		{
			try
			{
				var encodedEmail = Uri.EscapeDataString(email);
				var response = await _httpClient.GetAsync($"Auth/login/{encodedEmail}/{password}");
				if (!response.IsSuccessStatusCode)
				{
					var errorContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Erro na requisição:");
					Console.WriteLine(errorContent);
				}

				var result = await response.Content.ReadAsStringAsync();

				return bool.Parse(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
				return false;
			}
		}
	}
}
