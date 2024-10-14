using ServiceContracts.DTOs;
using ServiceContracts.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Tests.Unit
{
    public class UserServiceTests
    {
        private readonly IUsersService _usersService;
        public UserServiceTests()
        {
            _usersService = new UsersService();
        }

        #region AddUser
        [Fact]
        public void AddUser_ShouldThrowException_WhenUserIsNull()
        {
            //Arrange
            UserDto userDto = null;

            //Act
            var response=()=>_usersService.AddUser(userDto);

            //Assert
            Assert.Throws<ArgumentNullException>(response);
        }

        [Fact]
        public void AddUser_ShouldThrowException_WhenUserFirstNameOrEmailIsNull()
        {
            //Arrange
            UserDto userDto1 = new()
            {
                Email = "test@test.com",
                Avatar = "test"
            };
            UserDto userDto2 = new()
            {
                FirstName = "test",
                Avatar = "test"
            };

            //Act
            var response1 = () => _usersService.AddUser(userDto1);
            var response2 = () => _usersService.AddUser(userDto1);

            //Assert
            Assert.Throws<ArgumentException>(response1);
            Assert.Throws<ArgumentException>(response2);
        }

        [Fact]
        public void AddUser_ShouldReturnProperUser_WhenEverythingIsOK()
        {
            //Arrange
            UserDto userDto = new()
            {
                FirstName="test",
                Email = "test@test.com",
                Avatar = "test"
            };

            //Act
            var response = _usersService.AddUser(userDto);

            //Assert
            Assert.NotNull(response);
        }
        #endregion
    }
}
