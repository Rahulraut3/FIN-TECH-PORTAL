using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBS_RSLayer;
using IBS_DALayer.Models;
using System.Collections.Generic;
using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace IBS_UILayer.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCreationApiController : ControllerBase
    {
        private ICustomerDb<AccountCreationRequest> AcrDb;
        private ICustomerDb<User> UserDb;
        private ICustomerDb<AccountDetail> AdDb;
        private ICustomerDb<BranchDetail> brachdb;

        public AccountCreationApiController(ICustomerDb<AccountCreationRequest> acrDb, ICustomerDb<User> userDb, ICustomerDb<AccountDetail> adDb, ICustomerDb<BranchDetail> brachdb)
        {
            AcrDb = acrDb;
            UserDb = userDb;
            AdDb = adDb;
            this.brachdb = brachdb;
        }


        /// <summary>
        /// Shows all pending request to admin for account Creation 
        /// </summary>
        /// <returns> All Request Details</returns>
        [HttpGet("ShowAllRequest")]
        public IActionResult ShowAllRequest()
        {
            try
            {
                IEnumerable<AccountCreationRequest> rec = AcrDb.ShowAll();
                return Ok(rec);
            }
            catch (Exception )
            {
                return BadRequest("No Request Found");
            }
        }


        /// <summary>
        /// Function to accept all request
        /// </summary>
        /// <param name="Request">Request Id for Accepting Request</param>
        /// <returns>User Details</returns>
        [HttpGet("Accept/{Request}")]
        public IActionResult Accept(int Request)
        {
            try
            {
                AccountCreationRequest AccReq = AcrDb.GetById(Request);
                if (AccReq != null)
                {
                    string MailId = AccReq.Email;
                    User user = UserDb.CreateUser(Request);

                    RequestAceptMail(MailId, AccReq.AccountType, AccReq.CustomerName, user.UserId, user.Password);
                    return Ok(user);

                }
                return BadRequest("Somthing went worng !");
            }
            catch (Exception)
            {
                return BadRequest("No Request Found");
            }
        }
        /// <summary>
        /// Sends a mail to the user with his user id and password
        /// </summary>
        /// <param name="CustomerMail">Customer's Email Id</param>
        /// <param name="AccountType">Customer's Account Type</param>
        /// <param name="CustomerName">Customer's Name</param>
        /// <param name="userId">Customer's User ID</param>
        /// <param name="password">Customer's Password</param>
        public void RequestAceptMail(string CustomerMail, string AccountType, string CustomerName, int userId, string password)
        {
            try
            {

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Internet Banking ", "IBSPvtLimited@gmail.com"));
                message.To.Add(new MailboxAddress("IBS Bank", CustomerMail));
                message.Subject = "Account update  for your IBS bank A/c ";
                message.Body = new TextPart("plain")
                {
                    Text = "Dear Customer ,\n Thankyou for choosing Internet Banking Service.\n \n" +
                    "Your Nomination request in respect to your below mentioned account is confirmed." +
                    "It has been executed in favour of the following :\n \n" +
                    "Account type - " + AccountType + "\n" +
                    "Customer Name - " + CustomerName + "\n" +
                    "Account Creation Date - " + DateTime.Now +
                    "\n \n Please note down your customer ID and password in a safe location as this will be " +
                    "used to Login to your portal.\n \n" +
                    "UserId - " + userId + "\n" +
                    "Password - " + password + "\n" +
                    "Kindly quote the above reference number in all future transactions.\n \n" +
                    "!! IMPORTANT !! \n" +
                    "Do not share your credentials with unknow identity ,\n IBS will never call you for your " +
                    " OTP Or Credentials information." +
                    "Please make sure you do not get scammed by scammers." +
                    "Have a pleasnt day ,\n \n" +
                    "Warm Regards ,\n" +
                    "INTERNET BANKING SYSTEM "

                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("IBSPvtLimited@gmail.com", "IBSPvtLimited@12345");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {
                throw new Exception("Unable to Send ");
            }


        }


        /// <summary>
        /// This Function Rejects the request of Account Creation 
        /// </summary>
        /// <param name="Request">Request Id</param>
        /// <returns>Ok Object Result Response</returns>
        [HttpGet("Reject/{Request}")]
        public IActionResult Reject(int Request)
        {
            try
            {
                AccountCreationRequest creationRequest = AcrDb.GetById(Request);
                creationRequest.Status = "Rejected";
                AcrDb.Update(creationRequest);
                return Ok("Rejected");
            }
            catch (Exception)
            {
                return BadRequest("Could not Reject Request");
            }
        }



        /// <summary>
        /// This Function is used For user login (Admin/Customer)
        /// </summary>
        /// <param name="UserId">User Id of Customer or admin</param>
        /// <param name="Password">Password of Customer or Admin</param>
        /// <returns>User </returns>
        [HttpGet("Login/{UserId},{Password}")]
        public IActionResult Login(int UserId,string Password)
        {
            try
            {
                User usr = UserDb.GetById(UserId);

                if (UserId == usr.UserId && Password.Equals(usr.Password))
                {
                    return Ok(usr);
                }
                else
                {
                    return NotFound("User Id or Password is wrong");
                }
            }
            catch (Exception)
            {
                return BadRequest("Invalid Entry");
            }
        }


        /// <summary>
        /// Fetches the Customer type from the database
        /// </summary>
        /// <param name="UserId">UserId to determine type of Customer</param>
        /// <returns>Account Details with Customer Type</returns>
        [HttpGet("CustomerType/{UserId}")]
        public IActionResult CustomerType(int UserId)
        {
            try
            {
                AccountDetail account = AdDb.GetAccountDetails(UserId);
                return Ok(account);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Entry");
            }
        }


        /// <summary>
        /// Sends the Data to backend and fetches the Branch Details from backend
        /// </summary>
        /// <param name="NewRec"> Newly Registered Details of Customer</param>
        /// <returns> Ok </returns>
        [HttpPost("Registration")]
        public IActionResult Registration(AccountCreationRequest NewRec)
        {
            try
            {
                BranchDetail brancdetail = brachdb.GetById(NewRec.BranchName);
                string ifsc = brancdetail.Ifsccode;
                NewRec.Ifsccode = ifsc;
                AcrDb.Add(NewRec);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }


}
