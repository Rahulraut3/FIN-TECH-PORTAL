using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using IBS_DALayer.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using IBS_EXLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace IBS_UILayer.Controllers
{
    [Authorize]
    public class TransactionReportController : Controller
    {
        private IConfiguration Config;
        private string BaseUrl = "TransactionReportApi/";

        HttpClient Client;
        //Constructor To initialize Instances
        public TransactionReportController(IConfiguration config)
        {
            Config = config;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetSection("ConfigSetting:UrlData").Value);
        }



        /// <summary>
        /// Displays all Transaction To Admin
        /// </summary>
        /// <returns>List of Transactions Made by Customer</returns>
        [HttpGet]
        public async Task<IActionResult> ShowAllTransaction()
        {
            try
            {
                List<TransactionReport> transactions = new List<TransactionReport>();
                var response = Client.GetAsync(BaseUrl + "ShowAllTransaction").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    transactions = JsonConvert.DeserializeObject<List<TransactionReport>>(responsedata);
                }

                return View(transactions);
            }
            catch (TransactionReportException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("ShowAllTransaction");
        }

        /// <summary>
        /// This Function gets Executed when Admin wants to see Transaction Details of Customer
        /// </summary>
        /// <returns>View To take in Account Number</returns>
        [HttpGet]
        public IActionResult TransactionByAccNo()
        {
            return View();
        }



        /// <summary>
        /// Displays the Transaction Of a Customer
        /// </summary>
        /// <param name="AccountNumber">Account No for Confirmation of Csutomer</param>
        /// <returns>List of Trnsactions done by a specific Customer View</returns>
        [HttpPost]
        public async Task<IActionResult> TransactionByAccNo(int AccountNumber)
        {
            try
            {
                List<TransactionReport> transactions = new List<TransactionReport>();
                var response = Client.GetAsync(BaseUrl + "TransactionByAccNo/" + AccountNumber).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    transactions = JsonConvert.DeserializeObject<List<TransactionReport>>(responsedata);
                }
                else
                {
                    ViewBag.AccError = "Account Not Found!";
                    return View();
                }

                return View("ShowAllTransaction", transactions);
            }
            catch (TransactionReportException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return View();
        }



        /// <summary>
        /// Displays Transactions done by Customer to Customer 
        /// </summary>
        /// <returns>Transaction Details view</returns>
        [HttpGet]
        public async Task<IActionResult> TransactionForUser()
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                List<TransactionReport> transactions = new List<TransactionReport>();
                var response = Client.GetAsync(BaseUrl + "TransactionByAccNo/" + AccountNumber).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    transactions = JsonConvert.DeserializeObject<List<TransactionReport>>(responsedata);
                }

                return View("TransactionForUser", transactions);
            }
            catch (TransactionReportException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("TransactionForUser");

        }

        /// <summary>
        /// Displays Transaction Details of Fixed type Customer
        /// </summary>
        /// <returns>List Of Fixed Customer Transactions</returns>
        [HttpGet]
        public async Task<IActionResult> TransactionForFixedUser()
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                List<TransactionReport> transactions = new List<TransactionReport>();
                var response = Client.GetAsync(BaseUrl + "TransactionByAccNo/" + AccountNumber).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    transactions = JsonConvert.DeserializeObject<List<TransactionReport>>(responsedata);
                }

                return View("TransactionForFixedUser", transactions);
            }
            catch (TransactionReportException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("TransactionForFixedUser");
        }

    }
}
