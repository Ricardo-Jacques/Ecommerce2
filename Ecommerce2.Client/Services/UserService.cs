using ECommerce2.Client.Interfaces;
using ECommerce2.Shared.Dtos;
using System.Net.Http;
using System.Net.Http.Json;

namespace ECommerce2.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto> GetLoggedUser(string email)
        {
            try
            {
				var encodedEmail = Uri.EscapeDataString(email);
				var response = await _httpClient.GetAsync($"User/get-logged-user/{encodedEmail}");
				if (!response.IsSuccessStatusCode)
				{
					var errorContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Erro na requisição:");
					Console.WriteLine(errorContent);
				}

				var user = await response.Content.ReadFromJsonAsync<UserDto>();

                return user ?? new UserDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
                return new UserDto();
            }
        }
    }
}
