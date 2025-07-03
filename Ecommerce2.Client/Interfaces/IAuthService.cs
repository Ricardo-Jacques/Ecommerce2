using ECommerce2.Shared.Dtos;
namespace ECommerce2.Client.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);
    }
}
