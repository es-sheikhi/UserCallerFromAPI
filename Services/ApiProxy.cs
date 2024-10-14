using ServiceContracts.DTOs;
using ServiceContracts.Extensions;
using ServiceContracts.Models;
using ServiceContracts.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApiProxy : IApiProxy
    {
        public async Task<List<UserDto>> GetUsersDataAsync(string url)
        {
            if(url == null)
            {
                throw new ArgumentNullException(nameof(url));   
            }
            using (HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage httpResponse=await client.GetAsync(url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result=await httpResponse.Content.ReadFromJsonAsync<Result>();
                    var userList = result?.data?.Select(c => c.ToUserDto());
                    return userList?.ToList()??new List<UserDto>();
                }
                else
                {
                    throw new ArgumentException("Something has happend!");
                }
            }
        }
    }
}
