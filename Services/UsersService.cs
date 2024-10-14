using Repositories.Interfaces;
using ServiceContracts.DTOs;
using ServiceContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        public UserDto AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
