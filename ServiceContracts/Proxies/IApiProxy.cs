
using Entities;
using ServiceContracts.DTOs;

namespace ServiceContracts.Proxies
{
    public interface IApiProxy
    {
        List<UserDto> GetUsersDataAsync(string endPoint);
    }
}
