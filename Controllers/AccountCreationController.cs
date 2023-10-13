using Microsoft.AspNetCore.Mvc;
using IBS_DALayer.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using IBS_RSLayer;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using Microsoft.AspNetCore.Http;
using IBS_EXLayer;
using System;
using System.Text;
using IBS_UILayer.BAServices;
using Microsoft.Extensions.Configuration;

namespace IBS_UILayer.Controllers
{
    [Authorize]
    public class AccountCreationController : Controller
    {
        private IConfiguration Config;
        private string BaseUrl = "AccountCreationApi/";
        private ICustomerDb<User> UserDb;
        private AccountCreationService Service;
        HttpClient Client;

        //Constructor to Initialize Instances of Interfaces as well as other classes
        public AccountCreationController(ICustomerDb<User> userDb, IConfiguration config, AccountCreationService service)
        {
            Config = config;
            UserDb = userDb;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetSection("ConfigSetting:UrlData").Value);   //Fetching the base URL 
            Service = service;
        }


        /// <summary>
        /// Get Function here is used For REGISTRATION of Customer via SignUp button
        /// </summary>
        /// <returns>View of Registration Form</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }


        /// <summary>
        /// Post Function here is used for Passing Values of Registration Form to Backend
        /// </summary>
        /// <param name="NewRec"> Object of AccountCreation Request to access passed values</param>
        /// <returns>Posts information to backend</returns>
        ///  <exception cref="AccountCreationException">Throws an Exception if Encountered with  Server Error</exception>
        [HttpPost]
        [AllowAnonymous] //--Authorization For Anonymous Users
        public IActionResult Registration(AccountCreationRequest NewRec)
        {
            int age = 0;
            age = DateTime.Now.Subtract(NewRec.Dob).Days;
            age = age / 365;
            try
            {
                if (NewRec.PhoneNumber.Length != 10)
                {
                    ViewBag.phError = "Invalid Phone Number ";        
                    return View(NewRec);
                }
                if (NewRec.Aadhar.Length != 12)
                {
                    ViewBag.AaError = "Invalid Aadhar Number ";
                    return View(NewRec);
                }
                if (NewRec.Pan.Length != 10)
                {
                    ViewBag.pnError = "Invalid Pan Number ";
                    return View(NewRec);
                }
                if(NewRec.AccountType.Equals("Saving"))
                {
                    if (NewRec.AccountBalance < 3000)
                    {
                        ViewBag.balError = "Minimum Amonunt must be 3000 ";
                        return View(NewRec);
                    }
                }
                else
                {
                    if (NewRec.AccountBalance < 50000)
                    {
                        ViewBag.balError = "Minimum Amonunt must be 50000 ";
                        return View(NewRec);
                    }
                }
               
                if (age < 18)
                {
                    ViewBag.ageError = "You are Not Eligible! (>=18) ";
                    return View(NewRec);
                }

                if (NewRec.NomPhoneNumber.Length != 10)
                {
                    ViewBag.nphError = "Invalid Phone Number";
                    return View(NewRec);
                }


                if(Service.Registration(NewRec))
                {
                    return RedirectToAction("Welcome");
                }
                return View(NewRec);
            }
            catch (AccountCreationException ex)   
            {                                              
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return View(NewRec);
        }

        /// <summary>
        /// On Successfull Registration of User this Function get Executed
        /// </summary>
        /// <returns>Successfull Registration Card View</returns>
        [AllowAnonymous]
        public IActionResult Welcome()
        {
            return View();
        }


        /// <summary>
        /// This Admin Functions Shows All the Registration Request To admin
        /// </summary>
        /// <returns>View For AccountCreationRequest</returns>
        /// <exception cref="AccountCreationException">Throws Exception if Any Server related Error Comes</exception>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowAllRequest()
        {
            try
            {
                List<AccountCreationRequest> requests = new List<AccountCreationRequest>();
                var response = Client.GetAsync(BaseUrl + "ShowAllRequest").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    requests = JsonConvert.DeserializeObject<List<AccountCreationRequest>>(responsedata);
                }

                return View(requests);
            }
            catch (AccountCreationException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("ShowAllRequest");
        }


        /// <summary>
        /// This Function Gets Executed when Admin Accepts an Account Creation Request
        /// </summary>
        /// <param name="ACrequest"></param>
        /// <returns>UserId and Password of Respected Customer</returns>
        /// <exception cref="AccountCreationException">Throws Exception if Any Server related Error Comes</exception>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Accept(int ACrequest)
        {
            try
            {
                User user = new User();
                var response = Client.GetAsync(BaseUrl + "Accept/" + ACrequest).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(responsedata);
                }

                return View(user);
            }
            catch (AccountCreationException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("Accept");
        }


        /// <summary>
        /// This Function Gets Executed when Admin Rejects Customer Account Request
        /// </summary>
        /// <param name="ACrequest"></param>
        /// <returns></returns>
        /// <exception cref="AccountCreationException"></exception>
        [Authorize]
        [HttpGet]
        public IActionResult Reject(int ACrequest)
        {
            try
            {
                var response = Client.GetAsync(BaseUrl + "Reject/" + ACrequest).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return View();
                }
                return RedirectToAction("ShowAllRequest");
            }
            catch (AccountCreationException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("Reject");

        }

        /// <summary>
        /// To Display the Login Page
        /// </summary>
        /// <returns>View of Login Page</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// This Posts the Credentials and checks it against the data base
        /// </summary>
        /// <param name="usr">Object of User Class</param>
        /// <returns>View of Saving Customer/Fixed Customer/Admin panel</returns>
        /// <exception cref="AccountCreationException">Throws an Exception if any server error occurs</exception>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User usr)
        {
            try
            {

                User user = UserDb.GetById(usr.UserId);
                if (user != null)
                {
                    if (user.UserId == usr.UserId && user.Password.Equals(usr.Password))
                    {
                        var userClaims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name,user.UserId.ToString())
                        };

                        var useridentity = new ClaimsIdentity(userClaims, "User identification");

                        var userprincipal = new ClaimsPrincipal(new[] { useridentity });

                        await HttpContext.SignInAsync(userprincipal);

                        if (user.UserType == "Admin")
                        {
                            HttpContext.Session.SetInt32("UserId", user.UserId);
                            HttpContext.Session.SetString("Password", user.Password.ToString());
                            HttpContext.Session.SetString("Type", user.UserType.ToString());
                            return RedirectToAction("AdminHome");    //Returns Admin Panel if user is Admin
                        }
                        else if (user.UserType == "Customer")
                        {
                            AccountDetail accountDetail = new AccountDetail();
                            var res = Client.GetAsync(BaseUrl + "CustomerType/" + user.UserId).Result;

                            if (res.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var responsedata = await res.Content.ReadAsStringAsync();
                                accountDetail = JsonConvert.DeserializeObject<AccountDetail>(responsedata);
                            }
                            if (accountDetail.AccountType == "Saving")
                            {
                                HttpContext.Session.SetInt32("UserId", user.UserId);
                                HttpContext.Session.SetString("Password", user.Password.ToString());
                                HttpContext.Session.SetString("Type", user.UserType.ToString());
                                HttpContext.Session.SetInt32("AccountNo", accountDetail.AccountNumber);

                                return RedirectToAction("SavingCustomerHome");      //Returns Saving Customer Panel if User has Savings Account
                            }
                            else
                            {
                                HttpContext.Session.SetInt32("UserId", user.UserId);
                                HttpContext.Session.SetString("Password", user.Password.ToString());
                                HttpContext.Session.SetString("Type", user.UserType.ToString());
                                HttpContext.Session.SetInt32("AccountNo", accountDetail.AccountNumber);
                                return RedirectToAction("FixedCustomerHome");       //Returns Fxied Customer Panel if user has Fixed Account
                            }
                        }
                        else
                        {
                            ViewBag.LoginError = "Invalid UserId or Password";
                            return View();                  //Returns Login View if UserId or password is wrong
                        }
                    }
                }
                else
                {
                    ViewBag.LoginError = "Invalid UserId or Password";
                    return View();                      //Returns Login View if UserId or password is wrong     
                }


            }
            catch (AccountCreationException ex)
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
        /// Logs Out Admin/Customer From their Respective Panel
        /// </summary>
        /// <returns>Login View</returns>
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }



        //---------Panels---------------\\\

        /// <summary>
        /// This Function Gets Executed if the user has Savings Account
        /// </summary>
        /// <returns>View of Savings Customer Panel</returns>
        public IActionResult SavingCustomerHome()
        {
            return View();
        }

        /// <summary>
        /// This Function Gets Executed if the user type has fixed Account  
        /// </summary>
        /// <returns>View of Fixed Customer panel</returns>
        public IActionResult FixedCustomerHome()
        {
            return View();
        }


        /// <summary>
        /// This Function gets Executed if the user type is Admin
        /// </summary>
        /// <returns>View of Admin Panel</returns>
        public IActionResult AdminHome()
        {
            return View();
        }



    }
}
