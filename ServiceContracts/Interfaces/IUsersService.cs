﻿using ServiceContracts.DTOs;
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
        List<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        UserDto AddUser(UserDto user);
        bool DeleteUser(int id);
    }
}
