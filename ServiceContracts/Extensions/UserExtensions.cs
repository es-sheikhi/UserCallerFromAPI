using Entities;
using ServiceContracts.DTOs;
using ServiceContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToUserDto(this UserInfo userInfo)
        {
            return new UserDto
            {
                Avatar = userInfo.avatar,
                Email = userInfo.email,
                FirstName = userInfo.first_name,
                Id = userInfo.id,
                LastName = userInfo.last_name,
            };
        }

        public static User ToUser(this UserDto userDto)
        {
            return new User
            {
                Avatar = userDto.Avatar,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserId = userDto.Id
            };
        }
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Avatar = user.Avatar,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.UserId
            };
        }
    }
}
