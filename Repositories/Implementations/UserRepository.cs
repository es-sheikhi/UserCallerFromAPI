using Entities;
using Repositories.Interfaces;
using ServiceContracts.DTOs;
using ServiceContracts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository()
        {
            _context = new UserDbContext();
        }
        public UserDto AddUser(UserDto userDto)
        {
            User user = userDto.ToUser();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.ToUserDto();
        }

        public bool DeleteUser(int id)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserDto> GetAllUsersAsync()
        {
            var userList = _context.Users.Select(c => c.ToUserDto());
            return userList.ToList();
        }

        public UserDto GetUserById(int id)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                return user.ToUserDto();
            }
            return null;
        }
    }
}
