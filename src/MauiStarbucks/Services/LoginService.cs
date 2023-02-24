using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiStarbucks.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<Models.UserInfo> Login(string userName, string password)
        {
            var userInfo = new List<Models.UserInfo>();
            var client = new HttpClient();

            string url = "https://wolfoip.zapto.org//WSUsers.asmx/GetUsersLoginJSON?userName=" + userName +"&password="+password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;


                userInfo = JsonConvert.DeserializeObject<List<Models.UserInfo>>(content);
                return await Task.FromResult(userInfo.FirstOrDefault());
            }
            else
            {
                return null;
            }

        }
    }
}
