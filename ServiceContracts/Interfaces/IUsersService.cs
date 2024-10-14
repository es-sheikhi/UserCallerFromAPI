using ServiceContracts.DTOs;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Interfaces
{
    public interface IUsersService
    {
        List<UserDto> GetAllUsersAsync();
        UserDto GetUserById(int id);
        UserDto AddUser(UserDto user);
    }
}
