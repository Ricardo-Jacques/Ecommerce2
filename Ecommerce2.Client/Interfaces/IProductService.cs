using ECommerce2.Shared.Dtos;
namespace ECommerce2.Client.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> Get(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();        
    }
}
