using ECommerce2.Client.Interfaces;
using ECommerce2.Shared.Dtos;
using System.Net.Http;
using System.Net.Http.Json;

namespace ECommerce2.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> Get(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Product/get/{id}");
                response.EnsureSuccessStatusCode();
                var products = await response.Content.ReadFromJsonAsync<ProductDto>();

                return products ?? new ProductDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
                return new ProductDto();
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync("Product/get-all");

                response.EnsureSuccessStatusCode();

                var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();

                return products ?? new List<ProductDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
                return new List<ProductDto>();
            }
        }
    }
}
