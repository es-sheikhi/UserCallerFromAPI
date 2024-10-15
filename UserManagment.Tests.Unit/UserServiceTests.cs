using Entities;
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
        public void AddUser_ShouldThrowException_WhenUserIdIsNotValid()
        {
            //Arrange
            UserDto userDto = new()
            {
                Id = 0,
                FirstName = "test",
                Email = "test@test.com",
                Avatar = "test"
            };

            //Act
            var response = () => _usersService.AddUser(userDto);

            //Assert
            Assert.Throws<ArgumentException>(response);
        }

        [Fact]
        public void AddUser_ShouldThrowException_WhenUserFirstNameOrEmailIsNull()
        {
            //Arrange
            UserDto userDto1 = new()
            {
                Id = 1,
                Email = "test@test.com",
                Avatar = "test"
            };
            UserDto userDto2 = new()
            {
                Id = 1,
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
                Id = (new Random()).Next(),
                FirstName = "test",
                Email = "test@test.com",
                Avatar = "test"
            };

            //Act
            var response = _usersService.AddUser(userDto);

            //Assert
            Assert.NotNull(response);
        }
        #endregion

        #region DeleteUser
        [Fact]
        public void DeleteUser_ShouldReturnFalse_WhenIdIsNotFound()
        {
            //Arrange
            int id = -1;

            //Act
            var response = _usersService.DeleteUser(id);

            //Assert
            Assert.False(response);
        }
        [Fact]
        public void DeleteUser_ShouldReturnTrue_WhenIdIsFound()
        {
            //Arrange
            UserDto userDto = new()
            {
                Id = (new Random()).Next(),
                FirstName = "test",
                Email = "test@test.com",
                Avatar = "test"
            };

            //Act
            _usersService.AddUser(userDto);
            var response = _usersService.DeleteUser(userDto.Id);

            //Assert
            Assert.True(response);
        }
        #endregion

        #region GetAllUsers
        [Fact]
        public void GetAllPersons_ShouldBeEmpty_WhenNothingIsAdded()
        {
            //Arrange

            //Act
            var userList = _usersService.GetAllUsers();

            //Assert
            Assert.Empty(userList);
        }

        [Fact]
        public void GetAllPersons_ShouldNotBeNull_WhenSomethingIsAdded()
        {
            //Arrange
            UserDto userDto = new()
            {
                Id = (new Random()).Next(),
                FirstName = "test",
                Email = "test@test.com",
                Avatar = "test"
            };

            //Act
            var response = _usersService.AddUser(userDto);
            var userList = _usersService.GetAllUsers();

            //Assert
            Assert.NotEmpty(userList);
        }
        #endregion

        #region GetPersonByPersonId
        [Fact]
        public void GetUserByUserId_ShouldReturnNull_WhenUserIdIsNotValid()
        {
            //Arrange
            int id = 0;

            //Act
            var response = _usersService.GetUserById(id);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetUserByUserId_ShouldReturnProperUser_WhenUserIdIsValid()
        {
            //Arrange
            UserDto userDto = new()
            {
                Id = (new Random()).Next(),
                FirstName = "test",
                Email = "test@test.com",
                Avatar = "test"
            };

            //act
            _usersService.AddUser(userDto);
            var response = _usersService.GetUserById(userDto.Id);

            //Assert
            Assert.NotNull(response);
        }

        #endregion
    }
}
