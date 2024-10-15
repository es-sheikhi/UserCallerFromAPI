using Entities;
using Repositories.Implementations;
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
        public UsersService()
        {
            _userRepository = new UserRepository();
        }
        public UserDto AddUser(UserDto userDto)
        {
            if(userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            if (userDto.FirstName == null || userDto.Email==null)
                throw new ArgumentException();

            if (userDto.Id <= 0)
                throw new ArgumentException(nameof(userDto.Id));

            _userRepository.AddUser(userDto);
            return userDto;
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<UserDto> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserDto GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
