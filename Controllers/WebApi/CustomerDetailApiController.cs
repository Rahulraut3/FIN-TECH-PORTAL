using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBS_RSLayer;
using IBS_DALayer.Models;
using System.Collections.Generic;
using System;

namespace IBS_UILayer.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailApiController : ControllerBase
    {
        private ICustomerDb<User> UserDb;
        private ICustomerDb<CustomerAllDetail> CustomerDb;
        private ICustomerDb<PersonalDetail> PersonalDb;
        private ICustomerDb<NomineeDetail> NomineeDb;

        public CustomerDetailApiController(ICustomerDb<User> userDb, ICustomerDb<CustomerAllDetail> customerDb, ICustomerDb<PersonalDetail> personalDb, ICustomerDb<NomineeDetail> nomineeDb)
        {
            UserDb = userDb;
            CustomerDb = customerDb;
            PersonalDb = personalDb;
            NomineeDb = nomineeDb;
        }

        /// <summary>
        /// To Change Password of user
        /// </summary>
        /// <param name="UserId">User Id to determine the type of user</param>
        /// <param name="Password">Password to authorize</param>
        /// <returns>Status OK</returns>
        [HttpGet("ChangePassword/{UserId},{Password}")]
        public IActionResult ChangePassword(int UserId, string Password)
        {
            try
            {
                User user = UserDb.GetById(UserId);
                user.Password = Password;
                UserDb.Update(user);
                return Ok("success");
            }
            catch (Exception)
            {
                return BadRequest("Invalid Entry"); 
            }
        }



        /// <summary>
        /// Displays the Customer Details by account number
        /// </summary>
        /// <param name="AccountNumber">Account number to get the type of Customer and details </param>
        /// <returns></returns>
        [HttpGet("CustomerDetail/{AccountNumber}")]
        public IActionResult ShowCustomerDetail(int AccountNumber)
        {
            
            CustomerAllDetail sd = null;
            try
            {
                sd = CustomerDb.ShowCustomerDetail(AccountNumber);   // calling join function of repoImp class

                if (sd != null )
                {
                    return Ok(sd);
                }
                else
                {
                    return BadRequest("record not found");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Functions Displays all Customer Details 
        /// </summary>
        /// <returns>List of Customer</returns>
        [HttpGet("AllCustomerDetail")]
        public IActionResult ShowCustomerDetailsForAdmin()
        {
            IEnumerable<CustomerAllDetail> customerAllDetails;

            try
            {
                customerAllDetails = CustomerDb.CustomerDetailsForAdmin();    // calling join function of repoImp class


                if (customerAllDetails != null)
                {
                    return Ok(customerAllDetails);
                }
                else
                {
                    return BadRequest("record not found");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        /// <summary>
        /// Function to fetch Personal detail of customer
        /// </summary>
        /// <param name="AccountNumber">Account number to Confirm the type and details</param>
        /// <returns>Personal Details of Customer</returns>
        [HttpGet("GetPersonalDetailById/{AccountNumber}")]
        public IActionResult GetPersonalDetailById(int AccountNumber)
        {
            
            PersonalDetail rec = null;
            try
            {
                if (AccountNumber != 0)
                {
                    rec = PersonalDb.GetByIdProcedure(AccountNumber);

                }
                else
                {
                    return BadRequest("invaid Entry");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(rec);

        }


        /// <summary>
        /// Function to update the personal details
        /// </summary>
        /// <param name="PerDetails">Updated Personal Details</param>
        /// <returns>Updated details</returns>
        [HttpPost("UpdatePersonalDetail")]
        public IActionResult UpdatePersonalDetail([FromBody] PersonalDetail PerDetails)
        {
            try
            {
                if (PerDetails != null)
                {
                    PersonalDb.Update(PerDetails);
                }
                else
                {
                    return BadRequest("invaid Entry");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("record updated successfully");
        }


        /// <summary>
        /// To Fetch Nominee Details of Customer 
        /// </summary>
        /// <param name="AccountNumber"> Account number to confirm the type of customer</param>
        /// <returns>Nominee details</returns>
        [HttpGet("GetNomineeDetailById/{AccountNumber}")]
        public IActionResult GetNomineeDetailById(int AccountNumber)
        {
            NomineeDetail rec = null;
            try
            {
                if (AccountNumber != 0)
                {
                    rec = NomineeDb.GetByIdProcedure(AccountNumber);
                }
                else
                {
                    return BadRequest("invaid Entry");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(rec);

        }


        /// <summary>
        /// To update Nominee Details
        /// </summary>
        /// <param name="NomDetails">Edited Nominee Details</param>
        /// <returns>Updated Nominee Details</returns>
        [HttpPut("UpdateNomineeDetail")]
        public IActionResult UpdateNomineeDetail([FromForm] NomineeDetail NomDetails)
        {
            try
            {
                if (NomDetails != null)
                {
                    NomineeDb.Update(NomDetails);
                }
                else
                {
                    return BadRequest("invaid Entry");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("record updated successfully");
        }
    }
}