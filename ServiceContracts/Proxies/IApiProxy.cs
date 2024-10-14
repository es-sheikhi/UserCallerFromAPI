
using Entities;
using ServiceContracts.DTOs;

namespace ServiceContracts.Proxies
{
    public interface IApiProxy
    {
        Task<List<UserDto>> GetUsersDataAsync(string url);
    }
}
