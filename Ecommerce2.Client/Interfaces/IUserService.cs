using ECommerce2.Shared.Dtos;
namespace ECommerce2.Client.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetLoggedUser(string email);
    }
}
