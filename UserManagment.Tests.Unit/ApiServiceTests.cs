using ServiceContracts.Proxies;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Tests.Unit
{
    public class ApiServiceTests
    {
        private readonly IApiProxy _apiService;
        public ApiServiceTests()
        {
            _apiService=new ApiProxy();
        }
        [Fact]
        public void GetUsersDataAsync_ShouldThrowException_WhenUrlIsNull()
        {
            //Arrange
            string url = null;

            //Act
            var response = () => _apiService.GetUsersDataAsync(url);

            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(response);
        }

        [Fact]
        public void GetUsersDataAsync_ShouldThrowException_WhenUrlIsInvalid()
        {
            //Arrange
            string url = "Wrong Url";

            //Act
            var response = () => _apiService.GetUsersDataAsync(url);

            //Assert
            Assert.ThrowsAsync<ArgumentException>(response);
        }

        [Fact]
        public void GetUsersDataAsync_ShouldReturnEmptyList_WhenUrlIsValidAndThereIsNoUser()
        {
            //Arrange
            string url = "https://reqres.in/api/users?page=3";

            //Act
            var response =_apiService.GetUsersDataAsync(url);

            //Assert
            Assert.Empty(response.Result);
        }

        [Fact]
        public void GetUsersDataAsync_ShouldReturnUserList_WhenUrlIsValidAndThereIsUser()
        {
            //Arrange
            string url = "https://reqres.in/api/users";

            //Act
            var response = _apiService.GetUsersDataAsync(url);

            //Assert
            Assert.NotEmpty(response.Result);
        }
    }
}
