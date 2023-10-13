using IBS_DALayer.Models;
using IBS_EXLayer;
using IBS_RSLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace IBS_UILayer.BAServices
{
    public class AccountCreationService
    {
        private IConfiguration Config;
        private string BaseUrl = "AccountCreationApi/";

        HttpClient Client;

        public AccountCreationService(IConfiguration config)
        {
            Config = config;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetSection("ConfigSetting:UrlData").Value);

        }

        public bool Registration(AccountCreationRequest NewRec)
        {
            
            try
            {
                var rec = Client.PostAsJsonAsync(BaseUrl + "Registration", NewRec).Result;
                if (rec.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
               
            }
            catch (AccountCreationException)
            {
                throw new AccountCreationException("Something Went Wrong!!! Please Retry.");
            }
            catch (Exception)
            {
                throw new Exception("something Went Wrong");
            }
            return false;
        }
    }
}
