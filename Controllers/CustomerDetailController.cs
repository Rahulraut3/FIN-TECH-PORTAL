using Microsoft.AspNetCore.Mvc;
using IBS_DALayer.Models;
using IBS_RSLayer;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using IBS_EXLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace IBS_UILayer.Controllers
{
    [Authorize]
    public class CustomerDetailController : Controller
    {
        private IConfiguration Config;
        string BaseUrl = "CustomerDetailApi/";

        HttpClient Client;

        //Constructore to Initialize Interface instances as well as other instances
        public CustomerDetailController(IConfiguration config)
        {
            Config = config;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(config.GetSection("ConfigSetting:UrlData").Value);
        }


        /// <summary>
        /// This Function Gets Executed when Saving type Customer wishes to change his/her password
        /// </summary>
        /// <returns>View of Password change</returns>
        [HttpGet] 
        public IActionResult ChangePassForSaving()
        {
            return View();
        }


        /// <summary>
        /// Posts the entered password to bakcend to update the password fot Saving type Customer
        /// </summary>
        /// <param name="usr">Object of User Class</param>
        /// <returns>View for Successfull Password Change</returns>
        /// <exception cref="CustomerDetailsException">Throws Exception if Any Server Error Occurs</exception>
        [HttpPost]
        public async Task<IActionResult> ChangePassForSaving(User usr)
        {
            try
            {
                string Result = "";
                usr.UserId = (int)HttpContext.Session.GetInt32("UserId");
                var response = Client.GetAsync(BaseUrl + "ChangePassword/" + usr.UserId + "," + usr.Password).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    Result = JsonConvert.ToString(responsedata);
                }
                return View("ChangePassDone");   //Succcessfull View
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("ChangePassForSaving");     //View for Saving Customer Password Change
        }

        /// <summary>
        /// This Function Gets Executed when Fixed type Customer wishes to change his/her password
        /// </summary>
        /// <returns>View of Password change</returns>
        [HttpGet]
        public IActionResult ChangePassForFixed()
        {
            return View();
        }



        /// <summary>
        /// Posts the entered password to bakcend to update the password fot Fixed type Customer
        /// </summary>
        /// <param name="usr">Object of User Class</param>
        /// <returns>View for Successfull Password Change</returns>
        /// <exception cref="CustomerDetailsException">Throws Exception if Any Server Error Occurs</exception>
        [HttpPost]
        public async Task<IActionResult> ChangePassForFixed(User usr)
        {
            try
            {
                string Result = "";
                usr.UserId = (int)HttpContext.Session.GetInt32("UserId");
                var response = Client.GetAsync(BaseUrl + "ChangePassword/" + usr.UserId + "," + usr.Password).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsedata = await response.Content.ReadAsStringAsync();
                    Result = JsonConvert.ToString(responsedata);
                }
                return View("PasswordChanged");             //Successfull View
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("ChangePassForFixed");      //View for Password Change
        }



        /// <summary>
        /// This Function Shows All the Customer Details to Admin
        /// </summary>
        /// <returns>View For List of Customer Details </returns>
        [HttpGet]
        public async Task<IActionResult> DisplayCustomerDetailsForAdmin()
        {
            try
            {
                List<CustomerAllDetail> lst = new List<CustomerAllDetail>();
                var res = await Client.GetAsync(BaseUrl + "AllCustomerDetail/");

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string resp = await res.Content.ReadAsStringAsync();
                    lst = JsonConvert.DeserializeObject<List<CustomerAllDetail>>(resp);
                }
                return View(lst);        //List of Customer Details
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("DisplayCustomerDetailsForAdmin");    //Back to Same Function

        }




        /// <summary>
        /// This Function Gets executed to Get Customer Details by Account no
        /// </summary>
        /// <returns>View for Taking Account No</returns>
        [HttpGet]
        public IActionResult CustomerDetailByAccNoForAdmin()
        {
            return View();
        }


        /// <summary>
        /// This Functions Posts and validate the Account no From BackEnd
        /// </summary>
        /// <param name="AccountNumber">Account No of Customer</param>
        /// <returns>View With All the Details of a specific Customer</returns>
        [HttpPost]
        public async Task<IActionResult> CustomerDetailByAccNoForAdmin(int AccountNumber)
        {
            try
            {
                CustomerAllDetail cust = new CustomerAllDetail();

                var res = await Client.GetAsync(BaseUrl + "CustomerDetail/" + AccountNumber);

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string resp = await res.Content.ReadAsStringAsync();
                    cust = JsonConvert.DeserializeObject<CustomerAllDetail>(resp);
                }
                else
                {
                    ViewBag.AccError = "Account Not Found!";            //Shows Message if Account Not Found
                    return View();
                }
                return View("CustomerDetailByAccNo", cust);
            }
            catch (CustomerDetailsException ex)
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
        /// This Function Displays all the Customer Details To Admin
        /// </summary>
        /// <returns>View Containing List of all the Customer Details</returns>
        [HttpGet]
        public async Task<IActionResult> DisplayCustomerDetail()
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");

                CustomerAllDetail lst = new CustomerAllDetail();

                var res = await Client.GetAsync(BaseUrl + "CustomerDetail/" + AccountNumber);

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string resp = await res.Content.ReadAsStringAsync();
                    lst = JsonConvert.DeserializeObject<CustomerAllDetail>(resp);
                }

                return View(lst);           //List of Customers
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("DisplayCustomerDetail");

        }
        


        /// <summary>
        /// This Function Gets Executed when Customer wishes to edit his personal details
        /// </summary>
        /// <param name="AccountNumber">Account Number for Confirmation of Customer</param>
        /// <returns>View Containing Personal Details of Customer</returns>
        [HttpGet]
        public async Task<IActionResult> EditPersonalDetail(int AccountNumber)
        {
            PersonalDetail pdetail = new PersonalDetail();
            try
            {
                var res = Client.GetAsync(BaseUrl + "GetPersonalDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    pdetail = JsonConvert.DeserializeObject<PersonalDetail>(resp);
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(pdetail);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditPersonalDetail");

        }


        /// <summary>
        /// Posts the Entered Personal Details back to Data base
        /// </summary>
        /// <param name="perUpdate">Edited Personal Details </param>
        /// <returns>Updated View of Personal Details</returns>
        [HttpPost]
        public async Task<IActionResult> EditPersonalDetail(PersonalDetail perUpdate)
        {
            try
            {
                /* This Was Done by Using MultiPart For Fetching All the details and posting it back=
                 * 
                 * 
                //PersonalDetail pdetail = new PersonalDetail();
                //int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                //var res = Client.GetAsync(BaseUrl + "GetPersonalDetailById/" + AccountNumber).Result;
                //if (res.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var resp = await res.Content.ReadAsStringAsync();
                //    pdetail = JsonConvert.DeserializeObject<PersonalDetail>(resp);
                //}

                //MultipartFormDataContent mcon = new MultipartFormDataContent();
                //mcon.Add(new StringContent(pdetail.CustomerId.ToString()), "CustomerId");
                //mcon.Add(new StringContent(AccountNumber.ToString()), "AccountNumber");
                //mcon.Add(new StringContent(perUpdate.CustomerName.ToString()), "CustomerName");
                //mcon.Add(new StringContent(perUpdate.Dob.ToString()), "Dob");
                //mcon.Add(new StringContent(perUpdate.PhoneNumber.ToString()), "PhoneNumber");
                //mcon.Add(new StringContent(perUpdate.Email.ToString()), "Email");
                //mcon.Add(new StringContent(pdetail.Pan.ToString()), "Pan");
                //mcon.Add(new StringContent(pdetail.Aadhar.ToString()), "Aadhar");
                //mcon.Add(new StringContent(perUpdate.Address.ToString()), "Address");
                //res = Client.PutAsync(BaseUrl + "UpdatePersonalDetail/", mcon).Result;


                ================ENDS HERE=======================*/


                var res = await Client.PostAsJsonAsync(BaseUrl + "UpdatePersonalDetail", perUpdate);   //Using PostAsJsonAsync for Update Functionality
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("DisplayCustomerDetail");       //Edited View
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(perUpdate);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditPersonalDetail");              //Non-Edited View
        }



        /// <summary>
        /// Displays the Nominee Details with Editing Enabled
        /// </summary>
        /// <param name="AccountNumber">Account Number For Confirmation of Customert</param>
        /// <returns>View of Nominee Details</returns>
        [HttpGet] 
        public async Task<IActionResult> EditNomineeDetails(int AccountNumber)
        {
            try
            {
                NomineeDetail nominee = new NomineeDetail();

                var res = Client.GetAsync(BaseUrl + "GetNomineeDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    nominee = JsonConvert.DeserializeObject<NomineeDetail>(resp);
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(nominee);           //Nominee Details View
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditNomineeDetails");      //Editing Disabled View of Nominee Details
        }


        /// <summary>
        /// Posts the Entered Nominee Details back to Data base
        /// </summary>
        /// <param name="NomUpdate">Edited Nominee Details</param>
        /// <returns>Updated Nominee Details View</returns>

        [HttpPost]
        public async Task<IActionResult> EditNomineeDetails(NomineeDetail NomUpdate)
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                NomineeDetail nominee = new NomineeDetail();
                var res = Client.GetAsync(BaseUrl + "GetNomineeDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    nominee = JsonConvert.DeserializeObject<NomineeDetail>(resp);
                }

                MultipartFormDataContent mcon = new MultipartFormDataContent();
                mcon.Add(new StringContent(nominee.NomineeId.ToString()), "NomineeId");
                mcon.Add(new StringContent(AccountNumber.ToString()), "AccountNumber");
                mcon.Add(new StringContent(NomUpdate.NomineeName.ToString()), "NomineeName");
                mcon.Add(new StringContent(nominee.Relation.ToString()), "Relation");
                mcon.Add(new StringContent(NomUpdate.PhoneNumber.ToString()), "PhoneNumber");
                mcon.Add(new StringContent(NomUpdate.NomineeAddress.ToString()), "NomineeAddress");

                res = Client.PutAsync(BaseUrl + "UpdateNomineeDetail/", mcon).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("DisplayCustomerDetail");           //Edited Customer Details
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(nominee);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditNomineeDetails");                  //Non Edited Customer Details

        }

        //-------------For Fixed User-----------------------


        /// <summary>
        /// Displays the Customer Details of Fixed user
        /// </summary>
        /// <returns>View of List of Customer having Fixed account</returns>
        [HttpGet]
        public async Task<IActionResult> DisplayCustomerDetailForFixed()
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");

                CustomerAllDetail lst = new CustomerAllDetail();

                var res = await Client.GetAsync(BaseUrl + "CustomerDetail/" + AccountNumber);

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string resp = await res.Content.ReadAsStringAsync();
                    lst = JsonConvert.DeserializeObject<CustomerAllDetail>(resp);
                }

                return View(lst);           //List of Fixed users
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("DisplayCustomerDetailForFixed");       //Back to Function

        }


        /// <summary>
        /// Function to edit Personal details for Fixed user
        /// </summary>
        /// <param name="AccountNumber">Account No for Confirmation of Customer</param>
        /// <returns>Editing mode enabled view</returns>
        [HttpGet]
        public async Task<IActionResult> EditPersonalDetailForFixed(int AccountNumber)
        {
            try
            {
                PersonalDetail pdetail = new PersonalDetail();

                var res = Client.GetAsync(BaseUrl + "GetPersonalDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    pdetail = JsonConvert.DeserializeObject<PersonalDetail>(resp);
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(pdetail);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditPersonalDetailForFixed");   //Back to function

        }


        /// <summary>
        /// Posts the updated personal detail for fixed Customer
        /// </summary>
        /// <param name="perUpdate">Updated Personal Details</param>
        /// <returns>Updated View for Personal Detail of fixed Customer</returns>
        [HttpPost]
        public async Task<IActionResult> EditPersonalDetailForFixed(PersonalDetail perUpdate)
        {
            try
            {
                //This part is to show how its done using MultiPart Content
                PersonalDetail pdetail = new PersonalDetail();
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                var res = Client.GetAsync(BaseUrl + "GetPersonalDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    pdetail = JsonConvert.DeserializeObject<PersonalDetail>(resp);
                }

                MultipartFormDataContent mcon = new MultipartFormDataContent();
                mcon.Add(new StringContent(pdetail.CustomerId.ToString()), "CustomerId");
                mcon.Add(new StringContent(AccountNumber.ToString()), "AccountNumber");
                mcon.Add(new StringContent(perUpdate.CustomerName.ToString()), "CustomerName");
                mcon.Add(new StringContent(perUpdate.Dob.ToString()), "Dob");
                mcon.Add(new StringContent(perUpdate.PhoneNumber.ToString()), "PhoneNumber");
                mcon.Add(new StringContent(perUpdate.Email.ToString()), "Email");
                mcon.Add(new StringContent(pdetail.Pan.ToString()), "Pan");
                mcon.Add(new StringContent(pdetail.Aadhar.ToString()), "Aadhar");
                mcon.Add(new StringContent(perUpdate.Address.ToString()), "Address");

                res = Client.PutAsync(BaseUrl + "UpdatePersonalDetail/", mcon).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("DisplayCustomerDetailForFixed");   //Updated Personal Details View
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(perUpdate);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }   
            return RedirectToAction("EditPersonalDetailForFixed");          //Back to Function
        }


        /// <summary>
        /// Function allows to edit the nominee detail for fixed user
        /// </summary>
        /// <param name="AccountNumber">Account no to confirm the customer</param>
        /// <returns>Editing Enabled View of Nominee Detail</returns>
        [HttpGet]
        public async Task<IActionResult> EditNomineeDetailsForFixed(int AccountNumber)
        {
            try
            {
                NomineeDetail nominee = new NomineeDetail();

                var res = Client.GetAsync(BaseUrl + "GetNomineeDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    nominee = JsonConvert.DeserializeObject<NomineeDetail>(resp);
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(nominee);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditNomineeDetailsForFixed");          //Back to Function
        }


        /// <summary>
        /// Updates the edited details in back end for Fixed Type
        /// </summary>
        /// <param name="NomUpdate">Updated Details of Nominee for Fixed</param>
        /// <returns>Updated Nominee Details View</returns>
        [HttpPost]
        public async Task<IActionResult> EditNomineeDetailsForFixed(NomineeDetail NomUpdate)
        {
            try
            {
                int AccountNumber = (int)HttpContext.Session.GetInt32("AccountNo");
                NomineeDetail nominee = new NomineeDetail();
                var res = Client.GetAsync(BaseUrl + "GetNomineeDetailById/" + AccountNumber).Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var resp = await res.Content.ReadAsStringAsync();
                    nominee = JsonConvert.DeserializeObject<NomineeDetail>(resp);
                }

                MultipartFormDataContent mcon = new MultipartFormDataContent();
                mcon.Add(new StringContent(nominee.NomineeId.ToString()), "NomineeId");
                mcon.Add(new StringContent(AccountNumber.ToString()), "AccountNumber");
                mcon.Add(new StringContent(NomUpdate.NomineeName.ToString()), "NomineeName");
                mcon.Add(new StringContent(nominee.Relation.ToString()), "Relation");
                mcon.Add(new StringContent(NomUpdate.PhoneNumber.ToString()), "PhoneNumber");
                mcon.Add(new StringContent(NomUpdate.NomineeAddress.ToString()), "NomineeAddress");

                res = Client.PutAsync(BaseUrl + "UpdateNomineeDetail/", mcon).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("DisplayCustomerDetailForFixed");       //Updated View
                }
                else
                {
                    TempData["error"] = "invalid Url";
                }
                return View(nominee);
            }
            catch (CustomerDetailsException ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ExcError = ex.Message;
            }
            return RedirectToAction("EditNomineeDetailsForFixed");                  //Back to Function
        }
    }
}
