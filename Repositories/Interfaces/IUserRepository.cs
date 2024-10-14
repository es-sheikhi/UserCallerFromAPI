using Entities;
using ServiceContracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<UserDto> GetAllUsersAsync();
        UserDto GetUserById(int id);
        UserDto AddUser(UserDto user);
        bool DeleteUser(int id);
    }
}
