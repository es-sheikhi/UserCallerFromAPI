using Entities;
using ServiceContracts.DTOs;

namespace ServiceContracts.Adapters
{
    public interface IUserAdapter
    {
        User ConvertToUser(UserDto userDto);
    }
}
