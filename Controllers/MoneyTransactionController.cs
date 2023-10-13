using Microsoft.AspNetCore.Mvc;
using IBS_DALayer.Models;
using IBS_RSLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using IBS_EXLayer;
using Microsoft.Extensions.Configuration;

namespace IBS_UILayer.Controllers
{
    [Authorize]
    public class MoneyTransactionController : Controller
    {

        private IConfiguration Config;
        private string BaseUrl = "MoneyTransactionApi/";
        HttpClient Client;

        //Constructor to Initialize instances
        public MoneyTransactionController(IConfiguration config)
        {
            Config = config;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetSection("ConfigSetting:UrlData").Value);
        }



        /// <summary>
        /// This Functions gets Called when Customer wants to deposit Money 
        /// </summary>
        /// <returns>View for Deposit amount</returns>
        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }



        /// <summary>
        /// Posts the deposit amount to backend and updates the balance
        /// </summary>
        /// <param name="Amount">Amount to be deposited(int)</param>
        /// <returns>Updated Balance View</returns>
        [HttpPost]
        public async Task<IActionResult> Deposit(int Amount)
        {
            try
            {
                if(Amount<100)                  //Basic Validation
                {
                    ViewBag.Amount = "Amount must be greater than 100";
                    return View();
                }
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                AccountDetail accountDetail = new AccountDetail();
                var res = Client.GetAsync(BaseUrl + "Deposit/" + AccountNumber + "," + Amount).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    accountDetail = JsonConvert.DeserializeObject<AccountDetail>(response);
                }
                return View("TransactionDone", accountDetail);          
            }
            catch (MoneyTransactionException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("Deposit");     //Back to Function
        }



        /// <summary>
        /// This Functions gets Called when Customer wants to Withdrawal Money 
        /// </summary>
        /// <returns>View for Withdrawal amount</returns>
        [HttpGet]
        public IActionResult Withdrawal()
        {
            return View();
        }




        /// <summary>
        /// Posts the deposit amount to backend and updates the balance
        /// </summary>
        /// <param name="Amount">Amount to be Withdarwed(int)</param>
        /// <returns>Updated Balance View</returns>
        [HttpPost]
        public async Task<IActionResult> Withdrawal( int Amount)
        {
            try
            {
                if (Amount < 100)
                {
                    ViewBag.Amount = "Amount must be greater than 100";
                    return View();
                }
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                AccountDetail accountDetail = new AccountDetail();
                var res = Client.GetAsync(BaseUrl + "Withdrawal/" + AccountNumber + "," + Amount).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    accountDetail = JsonConvert.DeserializeObject<AccountDetail>(response);
                }
                else
                {
                    ViewBag.Amount = "Insufficient balance! minimum balance limit is 3000";
                    return View();
                }
                return View("TransactionDone", accountDetail);          //Successfull transaction view
            }
            catch (MoneyTransactionException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("Withdrawal");
        }



        /// <summary>
        /// This Functions gets Called when Customer wants to Perform Money Transfer
        /// </summary>
        /// <returns>View for Moeny Transfer</returns>
        [HttpGet]
        public IActionResult MoneyTransfer()
        {
            return View();
        }



        /// <summary>
        /// Posts the deposit amount to backend and updates the balance
        /// </summary>
        /// <param name="Amount">Amount to be Withdarwed(int)</param>
        /// <returns>Updated Balance View</returns>
        [HttpPost]
        public async Task<IActionResult> MoneyTransfer(int Amount, int RecipientAccountNumber)
        {
            try
            {
                if (Amount < 100)
                {
                    ViewBag.Amount = "Amount must be greater than 100";
                    return View();
                }
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                AccountDetail accountDetail = new AccountDetail();
                var res = Client.GetAsync(BaseUrl + "MoneyTransfer/" + AccountNumber + "," + Amount + "," + RecipientAccountNumber).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    accountDetail = JsonConvert.DeserializeObject<AccountDetail>(response);
                }
                else
                {
                    ViewBag.Amount = "Insufficient balance! or Account not found";
                    return View();
                }
                return View("TransactionDone", accountDetail);
            }
            catch (MoneyTransactionException ex)
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
        /// Displays the Balance
        /// </summary>
        /// <returns>View for Account Balance</returns>
        [HttpGet]
        public async Task<IActionResult> CheckBalance()
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                AccountDetail accountDetail = new AccountDetail();

                var res = Client.GetAsync(BaseUrl + "CheckBalance/" + AccountNumber).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    accountDetail = JsonConvert.DeserializeObject<AccountDetail>(response);
                }
                return View("ShowBalance", accountDetail);
            }
            catch (MoneyTransactionException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("CheckBalance");

        }


        /// <summary>
        /// To Display Balance For Fixed Account
        /// </summary>
        /// <returns> View to Display Balance</returns>
        [HttpGet]
        public async Task<IActionResult> CheckBalanceForFixed()
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                AccountDetail accountDetail = new AccountDetail();

                var res = Client.GetAsync(BaseUrl + "CheckBalance/" + AccountNumber).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    accountDetail = JsonConvert.DeserializeObject<AccountDetail>(response);
                }

                return View("CheckBalanceForFixed", accountDetail);
            }
            catch (MoneyTransactionException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("CheckBalanceForFixed");

        }
    }
}
