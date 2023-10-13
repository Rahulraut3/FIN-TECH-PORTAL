using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBS_DALayer.Models;
using IBS_RSLayer;
using System.Collections;
using System.Net.Http;
using Newtonsoft.Json;
using IBS_EXLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace IBS_UILayer.Controllers
{
    [Authorize]
    public class InterestCalculationController : Controller
    {
        private IConfiguration Config;
        private string BaseUrl = "InterestCalculationApi/";

        HttpClient Client;

        //Constructore to Initialize Instances
        public InterestCalculationController(IConfiguration config)
        {
            Config = config;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetSection("ConfigSetting:UrlData").Value);
        }


        /// <summary>
        /// Gets Executed when Admin Wants to Calculate interest
        /// </summary>
        /// <returns>View for entering Account no</returns>
        [HttpGet]
        public IActionResult CalculateInterest()
        {
            return View();
        }



        /// <summary>
        /// Calculates interest with seperate interest % for both type of account holder
        /// </summary>
        /// <param name="AccountNumber">Account Number to determine the Account type of Customer</param>
        /// <returns>Updated balance of customer view</returns>
        [HttpPost]
        public async Task<IActionResult> CalculateInterest(int AccountNumber)
        {
            try
            {
                AccountDetail accountDetail = new AccountDetail();

                var res = Client.GetAsync(BaseUrl + "CalculateInterest/" + AccountNumber).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    accountDetail = JsonConvert.DeserializeObject<AccountDetail>(response);
                }
                else
                {
                    ViewBag.AccError = "Account Not Found!";
                    return View();
                }
                return View("CalculatedInterest", accountDetail);
            }
            catch (InterestCalculationException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return View();
        }
        

    }
}